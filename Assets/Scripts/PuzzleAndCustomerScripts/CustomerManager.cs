using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour //bu script bir sürü þey yapýyo, ayýrmak gerek
{
    bool isLoggerActive = true;
    public int orderID;
    public bool isInOrder = false;
    [SerializeField] GameObject puzzleScreenPrefab;
    [SerializeField] GameObject germanText;
    GameObject puzzleScreenInstance;
    [SerializeField] OrderMaker orderMaker;
    [SerializeField] CustomerTimer customerTimer;
    List<int> correctRow = new List<int> {};
    List<int> currentRow = new List<int> {};
    List<int> correctEnteredRow = new List<int> {};
    int totalColumns = 5;

    [SerializeField] GameObject[] completedCarb;
    [SerializeField] GameObject[] completedTopping;
    [SerializeField] GameObject[] completedSpice;
    [SerializeField] GameObject[] completedSauce;
    [SerializeField] GameObject[] completedDoner;

    PuzzleController puzzleController;

    public bool isPuzzleSolved = false;

    [SerializeField]CustomerPositioner customerPositioner;
    [SerializeField]PointsCustomer pointsCustomer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orderMaker.MakeOrder();
        //orderID = OrderManagerPuzzle.orderCount;
    }

    // Update is called once per frame
    void Update()
    {

        if (orderID == OrderManagerPuzzle.onOrder && !isInOrder && !OrderManagerPuzzle.selectingOrders && !OrderManagerPuzzle.foodOnCounter && !isPuzzleSolved)
        {
            //OnActivateOrder(); // burasý büyük ihtimalle buglý
            Debug.Log("orderID on customer manager " + orderID);
            GetPuzzleScreen();
            Debug.Log("order being activated");
        }

        if (orderID == OrderManagerPuzzle.onOrder && !isInOrder && !OrderManagerPuzzle.selectingOrders && OrderManagerPuzzle.foodOnCounter)
        {
            CombineList();
            
            if (OrderChecker(orderMaker.totalOrderList, gameFlow.totalPlayerList))
            {
                pointsCustomer.PointCalculator();
                OrderFinished();
            }
            else
            {
                gameFlow.totalPoints -= 500;
                OrderFinished();
            }
        }


        if (isInOrder)
        {
            if (puzzleScreenInstance == null)
            {
                PuzzleFinished();
            }
        }


        if (customerTimer.startTime < 0)
        {
            OrderFinished();
            gameFlow.totalPoints -= 500;
            Debug.Log("Order Timed Out!");
        }
    }

    void GetPuzzleScreen()
    {
        germanText.gameObject.SetActive(false);
        puzzleScreenInstance = Instantiate(puzzleScreenPrefab);
        puzzleController = puzzleScreenInstance.GetComponent<PuzzleController>();
        for (int i = 0; i < totalColumns; i++)
        {
            correctRow.Add(orderMaker.correctOrders[i]); // doðru sýralar ordermakerdan alýnýr
            puzzleController.correctRow.Add(orderMaker.correctOrders[i]); // doðru sýralar puzzle controllera aktarýlýr
            Debug.Log("correct row: " + correctRow[i]);

        }
        Debug.Log("correct row: " + puzzleScreenInstance.GetComponent<PuzzleController>().correctRow[0]);
        isInOrder = true;
    }

    void OrderFinished()
    {

        if (OrderManagerPuzzle.onOrder != 0)
        {
            OrderManagerPuzzle.onOrder--; // and order selector grapics to left
            OrderManagerPuzzle.activeOrder--;
        }

        if (OrderManagerPuzzle.orderCount != 0)
            OrderManagerPuzzle.orderCount--;
        

        OrderManagerPuzzle.deletedOrder = orderID;

        Debug.Log("On order: " + OrderManagerPuzzle.onOrder);
        Debug.Log("Order count: " + OrderManagerPuzzle.orderCount);
        isInOrder = false;
        OrderManagerPuzzle.selectingOrders = true;
        OrderManagerPuzzle.foodOnCounter = false; //should delete food graphics as well
        OrderManagerPuzzle.isCustomerReadjusted = false;
        Destroy(this.gameObject);   
    }

    void PuzzleFinished()
    {
        if (!isInOrder) return;  // Prevent multiple calls if already processed
        Debug.Log("when puzzle finished orderID: " + orderID);
        Debug.Log("when puzzle finished onOrder: " + OrderManagerPuzzle.onOrder);
        Debug.Log("PuzzleFinished called");
        completedCarb[correctRow[0]].SetActive(true);
        completedTopping[correctRow[1]].SetActive(true);
        completedSpice[correctRow[2]].SetActive(true);
        completedSauce[correctRow[3]].SetActive(true);
        completedDoner[correctRow[4]].SetActive(true);

        isInOrder = false;
        OrderManagerPuzzle.selectingOrders = true;
        OrderManagerPuzzle.onOrder = 0;
        isPuzzleSolved = true;
    }

    void CombineList() 
    { //null check eklemek lazým!!!!
        if (gameFlow.carbList.Count > 0)
            gameFlow.totalPlayerList.Add(gameFlow.carbList[0]);
        if (gameFlow.toppingList.Count > 0)
            gameFlow.totalPlayerList.Add(gameFlow.toppingList[0]);
        if (gameFlow.spiceList.Count > 0)
            gameFlow.totalPlayerList.Add(gameFlow.spiceList[0]);
        if (gameFlow.sauceList.Count > 0)
            gameFlow.totalPlayerList.Add(gameFlow.sauceList[0]);
        if (gameFlow.donerList.Count > 0)
            gameFlow.totalPlayerList.Add(gameFlow.donerList[0]);
        
    }

    private void IDReAdjuster() //nerede ve nasýl kullanýlýcaklarýný bul
    {
        Debug.Log("ID readjuster called");
        Debug.Log("orderID before: " + orderID);
        Debug.Log("deleted order: " + OrderManagerPuzzle.deletedOrder);
        if (orderID > OrderManagerPuzzle.deletedOrder)
        {
            orderID--;
            Debug.Log("orderID after: " + orderID);
            customerPositioner.PositionReAdjuster(); // bu kýsma kesinlikle daha iyi bir çözüm bulunmal
        } 

    }

    private void OnEnable()
    {
        OrderManagerPuzzle.OnCustomerDeleted += IDReAdjuster;
    }

    private void OnDisable()
    {
        OrderManagerPuzzle.OnCustomerDeleted -= IDReAdjuster;
    }

    bool OrderChecker(List<string> orderList, List<string> playerList) 
    {
        Debug.Log("Entered order checker");
        if (orderList.Count != playerList.Count)
        {
            Debug.Log("liste sayýlarý farklý");
            Debug.Log("order list count: " + orderList.Count);
            Debug.Log("player list count: " + playerList.Count);
            return false;
        }
        else
        {
            orderList.Sort();
            playerList.Sort();
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i] != playerList[i])
                {
                    return false;

                }
            }
            return true;
        }
    }

}
