using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour //bu script bir sürü þey yapýyo, ayýrmak gerek
{
    bool isLoggerActive = true;
    public int orderID;
    public bool isInPuzzle = false;
    [SerializeField] GameObject puzzleScreenPrefab;
    public GameObject germanText;
    GameObject puzzleScreenInstance;
    public OrderMaker orderMaker;
    [SerializeField] CustomerTimer customerTimer;
    List<int> correctRow = new List<int> {};
    List<int> currentRow = new List<int> {};
    List<int> correctEnteredRow = new List<int> {};
    [SerializeField] int totalColumns = 5;

    [SerializeField] GameObject[] completedCarb;
    [SerializeField] GameObject[] completedTopping;
    [SerializeField] GameObject[] completedSpice;
    [SerializeField] GameObject[] completedSauce;
    [SerializeField] GameObject[] completedDoner;

    PuzzleControllerV2 puzzleController;

    public bool isPuzzleSolved = false;

    [SerializeField]CustomerPositioner customerPositioner;
    [SerializeField]PointsCustomer pointsCustomer;
    [SerializeField] CustomerAnimationManager customerAnimationManager;
    [SerializeField] CustomerOrderComperator customerOrderComperator;
    [SerializeField] CustomerPuzzleCallerDestroyer customerPuzzleCallDestroy;
    [SerializeField]SpeechBubbleControl speechBubbleControl;

    CorrectOrderSpawner correctOrderSpawner;

    [SerializeField] SpriteRenderer customerSpriteRenderer;
    [SerializeField] SpriteRenderer[] deactivateAtEnd;
    [SerializeField] Sprite correctOrderCustomer;
    [SerializeField] Sprite incorrectOrderCustomer;

    bool isProcessingOrder = false;
    public bool inEndAnimation = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orderMaker.MakeOrder();
        correctOrderSpawner = GetComponentInChildren<CorrectOrderSpawner>();
        //orderID = OrderManagerPuzzle.orderCount;
    }

    // Update is called once per frame
    void Update()
    {

        if (customerTimer.startTime < 0)
        {
            if (!isProcessingOrder)
            {
                isProcessingOrder = true;
                if (puzzleController != null)
                    Destroy(puzzleController.gameObject);
                StartCoroutine(OrderFinished(false, true));
                gameFlow.totalPoints -= 250;
                Debug.Log("Order Timed Out!");
            }

        }

        if (orderID != OrderManagerPuzzle.onOrder || OrderManagerPuzzle.selectingOrders)
            return;

        if (!isInPuzzle)
        {
            if (!isPuzzleSolved && !OrderManagerPuzzle.foodOnCounter)
            {
                //OnActivateOrder(); // burasý büyük ihtimalle buglý
                Debug.Log("orderID on customer manager " + orderID);
                GetPuzzleScreen();
                Debug.Log("order being activated");
            }

            if (OrderManagerPuzzle.foodOnCounter & !isProcessingOrder)
            {
                customerOrderComperator.CombineList();

                if (customerOrderComperator.OrderChecker(orderMaker.totalOrderList, gameFlow.totalPlayerList))
                {
                    isProcessingOrder = true;
                    pointsCustomer.PointCalculator();
                    StartCoroutine(OrderFinished(true, false));
                }
                else
                {
                    isProcessingOrder = true;
                    gameFlow.totalPoints -= 250;
                    StartCoroutine(OrderFinished(false, false));
                }
            }
        }

        if (isInPuzzle)
        {
            if (puzzleScreenInstance == null)
            {
                PuzzleFinished();
            }
        }        
    }

    void GetPuzzleScreen()
    {
        germanText.gameObject.SetActive(false);
        customerAnimationManager.PlayCustomerAnimation(); //test
        
        PuzzleInstantiator();

        PuzzleCorrectOrdersSetter();

        //Debug.Log("correct row: " + puzzleScreenInstance.GetComponent<PuzzleController>().correctRow[0]);
        isInPuzzle = true;
        puzzleController.PuzzleSpawner();
    }


    void PuzzleInstantiator()
    {
        puzzleScreenInstance = Instantiate(puzzleScreenPrefab);
        puzzleController = puzzleScreenInstance.GetComponentInChildren<PuzzleControllerV2>();
        if (puzzleController == null)
            Debug.Log("puzzle controller is null");
    }

    void PuzzleCorrectOrdersSetter()
    {
        totalColumns = orderMaker.correctOrders.Count;
        puzzleController.totalColumns = totalColumns;
        puzzleController.rowTypeNumber = orderMaker.amountOfIngredients;
        for (int i = 0; i < totalColumns; i++)
        {
            correctRow.Add(orderMaker.correctOrders[i]); // doðru sýralar ordermakerdan alýnýr
            puzzleController.correctRow.Add(orderMaker.correctOrders[i]); // doðru sýralar puzzle controllera aktarýlýr
            Debug.Log("correct row: " + correctRow[i]);

        }
    }

    IEnumerator OrderFinished(bool isOrderTrue, bool isOrderTimedOut)
    {

        for (int i = 0; i < deactivateAtEnd.Length; i++)
            deactivateAtEnd[i].gameObject.SetActive(false);

        if (isOrderTrue)
            customerSpriteRenderer.sprite = correctOrderCustomer;
        else
            customerSpriteRenderer.sprite = incorrectOrderCustomer;
        germanText.SetActive(false);

        if (isPuzzleSolved)
            correctOrderSpawner.gameObject.SetActive(false);

        if (puzzleController != null)
            Destroy(puzzleController.transform.root.gameObject);

        if (isOrderTimedOut) 
        {
            if (orderID == OrderManagerPuzzle.onOrder)
            {
                OrderManagerPuzzle.selectingOrders = true;
                Debug.Log("should be kicked out of puzzle screen");
            }

            customerTimer.ClockStopped();
        }

        if (!isOrderTimedOut)
        {
            isInPuzzle = false;
            OrderManagerPuzzle.selectingOrders = true;
            OrderManagerPuzzle.foodOnCounter = false; //should delete food graphics as well
            customerTimer.timerStarted = false;
        }


        inEndAnimation = true;
        Debug.Log("In end animation: " + inEndAnimation);
        yield return new WaitForSeconds(2f);
        Debug.Log("OrderFinished yield run");



        Debug.Log("On order: " + OrderManagerPuzzle.onOrder);
        Debug.Log("Order count: " + OrderManagerPuzzle.orderCount);

        OrderManagerPuzzle.deletedOrder = orderID;
        OrderManagerPuzzle.isCustomerReadjusted = false;




        Destroy(this.gameObject);
    }



    void PuzzleFinished()
    {
        if (!isInPuzzle) return;  // Prevent multiple calls if already processed
        Debug.Log("when puzzle finished orderID: " + orderID);
        Debug.Log("when puzzle finished onOrder: " + OrderManagerPuzzle.onOrder);
        Debug.Log("PuzzleFinished called");
        customerAnimationManager.StopCustomerAnimation(); //test
        correctOrderSpawner.InstantiateCorrectOrders();

        speechBubbleControl.FixContentSizeFitter(); //bura çok saçma ve tekrar düþünülmeli
        speechBubbleControl.AdjustAlpha();
        speechBubbleControl.HideThoughtBubbles();

        isInPuzzle = false;
        OrderManagerPuzzle.selectingOrders = true;
        OrderManagerPuzzle.onOrder = 0;
        isPuzzleSolved = true;
    }

}
