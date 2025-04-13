using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OrderManager : MonoBehaviour
{
    [SerializeField] GameObject easyOrderPrefab;
    List<GameObject> instantiatedObjects = new List<GameObject>();
    public static List<CustomerManager> customerManager = new List<CustomerManager>();
    [SerializeField] DayManager dayManager;


    float xOffset = 5f;
    int offsetMult; //should be controlled by ordercount
    public bool isShopEmpty = true;
    public bool firstOrder = true;


    [Header("Order Spawn Settings")]
    [Tooltip("Minimum time (in seconds) between customer orders.")]
    [SerializeField] private float minOrderTime = 30f;

    [Tooltip("Maximum time (in seconds) between customer orders.")]
    [SerializeField] private float maxOrderTime = 45f;

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
            if (!isOrderSystemActive && OrderManagerPuzzle.orderCount < 2 )
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
            if (firstOrder)
                waitTime = 5f;
            yield return new WaitForSeconds(waitTime);


            if (isOrderSystemActive && OrderManagerPuzzle.orderCount < 2 && dayManager.dayTickingDownTime > 0 && gameFlow.gameActive) // buraya day timer ekle ve day timer 60 olduðunda order generation durdur
            {
                firstOrder = false;
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

        newOrder.transform.position = new Vector3(-33f + (xOffset * (offsetMult)), -0.75f, 0);
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


    private void CustomerManagerReAdjust()
    {

        OrderSelectorGraphics orderSelectorGraphics = GetComponent<OrderSelectorGraphics>();


        if ((OrderManagerPuzzle.activeOrder >= OrderManagerPuzzle.deletedOrder) && OrderManagerPuzzle.activeOrder != 0)
        {
            orderSelectorGraphics.MoveSelectorLeft();
            OrderManagerPuzzle.activeOrder--;
        }

        if ((OrderManagerPuzzle.onOrder >= OrderManagerPuzzle.deletedOrder) && OrderManagerPuzzle.onOrder != 0)
        {
            OrderManagerPuzzle.onOrder--; // and order selector grapics to left
        }


        if (OrderManagerPuzzle.orderCount != 0)
            OrderManagerPuzzle.orderCount--;


        for (int i = 0; i< customerManager.Count; i++)
        {
            if (customerManager[i].orderID > OrderManagerPuzzle.deletedOrder)
            {
                customerManager[i].orderID--;
                customerManager[i].GetComponent<CustomerPositioner>().PositionReAdjuster();
                customerManager[i].GetComponent<CustomerAnimationManager>().UpdateOpenPuzzlePosition();
            }

        }



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
        OrderManagerPuzzle.OnCustomerDeleted += CustomerManagerReAdjust;
    }

    private void OnDisable()
    {
        OrderManagerPuzzle.OnCustomerDeleted -= ReAdjustList;
        OrderManagerPuzzle.OnCustomerDeleted -= CustomerManagerReAdjust;

    }



}

