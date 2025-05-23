using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using static OrderEventManager;
using static OrderManagerPuzzle;
using UnityEngine.SceneManagement;
using System.Collections;


public class OrderManagerPuzzle : MonoBehaviour //order screen input manager and some logic
{
    public delegate void PuzzleRightArrow();
    public static event PuzzleRightArrow OnPuzzleRightArrow;

    public delegate void PuzzleLeftArrow();
    public static event PuzzleLeftArrow OnPuzzleLeftArrow;

    public delegate void FoodSent();
    public static event FoodSent OnFoodSent;



    public delegate void ScreenSwitchToIngredients();
    public static event ScreenSwitchToIngredients OnScreenSwitchToIngredients;

    public delegate void CustomerDeleted(); //this event will use order count and orderID to readjust customer positions
    public static event CustomerDeleted OnCustomerDeleted;// also need to check if ID is larger than order count and readjust accordingly

    public static int orderCount = 0;
    public static int activeOrder = 0;
    public static int onOrder = 99;
    public static bool selectingOrders = true;
    float xOffset = 7.5f;
    int offsetMult = 0;
    int maxOrders = 2;
    int customerManagerIndex = 0;
    [SerializeField] GameObject easyOrderPrefab;

    List<GameObject> instantiatedObjects = new List<GameObject>();
    List<CustomerManager> customerManager = new List<CustomerManager>();

    public static bool foodOnCounter = false;

    public static int deletedOrder;

    public static bool isCustomerReadjusted = true;

    OrderManager orderManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orderManager = GetComponent<OrderManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFlow.gameActive)
        {
            if (gameFlow.foodSent) // buranın kameralı setupa geçmesi lazım
            {
                OnFoodSent();
                gameFlow.foodSent = false;
                if (gameFlow.carbList.Count != 0 || gameFlow.toppingList.Count != 0 || gameFlow.sauceList.Count != 0 || gameFlow.spiceList.Count != 0 || gameFlow.donerList.Count != 0)
                    foodOnCounter = true;
            }

            if (!isCustomerReadjusted)
            {
                OnCustomerDeleted();
                isCustomerReadjusted = true;
            }

            if (!gameFlow.screenSwitch)
            {
                if (selectingOrders)
                {

                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (activeOrder < orderCount)
                        {
                            OnPuzzleRightArrow();
                            activeOrder++;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (activeOrder > 0)
                        {
                            OnPuzzleLeftArrow();
                            activeOrder--;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Space)) //bura basitleştirilebilir, space'e basıldığında condition checkler 2 taraftan da yapılıyor
                                                         //sadece customer manager'dan yapılabilir
                    {
                        Debug.Log("function in order manager about animation is returning: " + orderManager.IsCustomerAnimating(activeOrder));
                        if (!orderManager.isShopEmpty && (!orderManager.IsPuzzleSolved(activeOrder) || foodOnCounter) && !orderManager.IsCustomerAnimating(activeOrder))
                        {
                            onOrder = activeOrder;
                            Debug.Log("when pressed space on order: " + onOrder);
                            selectingOrders = false;
                        }
                        else
                        {
                            Debug.Log("Puzzle is already solved or there is no customer");
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        StartCoroutine(WaitAndSwitchScreen());
                    }


                }
            }
        }
    }


    IEnumerator WaitAndSwitchScreen()
    {
        yield return new WaitForSeconds(0.01f);
        OnScreenSwitchToIngredients();
        //Camera.main.transform.position = new Vector3(0, 0, -10);
        //gameFlow.screenSwitch = true;
    }

}
