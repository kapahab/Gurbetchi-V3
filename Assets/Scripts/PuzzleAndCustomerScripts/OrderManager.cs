using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OrderManager : MonoBehaviour
{
    [SerializeField] GameObject easyOrderPrefab;
    List<GameObject> instantiatedObjects = new List<GameObject>();
    public static List<CustomerManager> customerManager = new List<CustomerManager>();

    float xOffset = 5f;
    int offsetMult; //should be controlled by ordercount
    public bool isShopEmpty = true;

    [Header("Order Spawn Settings")]
    [Tooltip("Minimum time (in seconds) between customer orders.")]
    [SerializeField] private float minOrderTime = 2.5f;

    [Tooltip("Maximum time (in seconds) between customer orders.")]
    [SerializeField] private float maxOrderTime = 5f;

    [Tooltip("Enable or disable order generation.")]
    private bool isOrderSystemActive = false; // Internal flag to manage coroutine state

    [SerializeField] Animator uiAnim;

    // Start is called before the first frame update
    void Start()
    {

        // Start checking for gameFlow.gameStart
        StartCoroutine(ManageOrderGeneration());
    }

    private void Update()
    {
        if (instantiatedObjects.Count > 0)
            isShopEmpty = false;
        else isShopEmpty = true;

    }


    IEnumerator ManageOrderGeneration()
    {
        while (true) // Keep this running indefinitely
        {
            if (!isOrderSystemActive && OrderManagerPuzzle.orderCount < 2)
            {
                // Start the order system when the game starts
                isOrderSystemActive = true;
                StartCoroutine(GenerateOrders());
            }
            else if (isOrderSystemActive && gameFlow.activeOrder > 2)
            {
                Debug.Log("Game stopped. Stopping order generation.");
                // Stop the order system when the game stops
                isOrderSystemActive = false;
            }

            yield return new WaitForSeconds(0.1f); // Check every 0.1 seconds
        }
    }

    IEnumerator GenerateOrders()
    {
        while (isOrderSystemActive)
        {
            // Wait for a random time between minOrderTime and maxOrderTime
            float waitTime = Random.Range(minOrderTime, maxOrderTime);
            yield return new WaitForSeconds(waitTime);

            if (isOrderSystemActive && OrderManagerPuzzle.orderCount < 2) // Double-check the flag before generating an order
            {
                offsetMult = OrderManagerPuzzle.orderCount;
                SpawnOrder();
                OrderManagerPuzzle.orderCount = instantiatedObjects.Count - 1;
                SetID();
                uiAnim.Play("customer_ui", 0, 0);
            }
        }
    }



    void SpawnOrder() //buradaki listeler silinen orderlarý desteklemesi için güncellenmeli
    {

        GameObject newOrder = Instantiate(easyOrderPrefab);
        instantiatedObjects.Add(newOrder);

        offsetMult = instantiatedObjects.Count - 1;

        newOrder.transform.position = new Vector3(-27.5f + (xOffset * (offsetMult)), -1.77f, 0);
        Debug.Log("object instantiated");
        Debug.Log("customer spawned at x: " + (5 + xOffset * (offsetMult)));

        CustomerManager newCustomer = instantiatedObjects[offsetMult].GetComponent<CustomerManager>();
        customerManager.Add(newCustomer);
        Debug.Log("amount of customerManagers: " + customerManager.Count);

    }

    void SetID() //bunu niye burada yapýyorum?
    {
        customerManager[OrderManagerPuzzle.orderCount].orderID = OrderManagerPuzzle.orderCount;
        Debug.Log("order id set to: " + OrderManagerPuzzle.orderCount);
    }

    void ReAdjustList()
    {
        instantiatedObjects.RemoveAt(OrderManagerPuzzle.deletedOrder);
        customerManager.RemoveAt(OrderManagerPuzzle.deletedOrder);
    }

    public bool IsPuzzleSolved(int index)
    {
        if (customerManager != null && customerManager.Count > index)
            return customerManager[index].isPuzzleSolved;
        else return true;
    }

    private void OnEnable()
    {
        OrderManagerPuzzle.OnCustomerDeleted += ReAdjustList;
    }

    private void OnDisable()
    {
        OrderManagerPuzzle.OnCustomerDeleted -= ReAdjustList;
    }
}

