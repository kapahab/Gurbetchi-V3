using System.Collections.Generic;
using UnityEngine;

public class CustomerPuzzleCallerDestroyer : MonoBehaviour
{
    [SerializeField] CustomerManager customerManager;

    PuzzleControllerV2 puzzleController;
    CorrectOrderSpawner correctOrderSpawner;

    [SerializeField] GameObject puzzleScreenPrefab;
    [SerializeField] GameObject germanText;
    GameObject puzzleScreenInstance;
    [SerializeField] OrderMaker orderMaker;
    [SerializeField] CustomerTimer customerTimer;
    List<int> correctRow = new List<int> { };
    List<int> currentRow = new List<int> { };
    List<int> correctEnteredRow = new List<int> { };
    [SerializeField] int totalColumns = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orderMaker.MakeOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPuzzleScreen()
    {
        germanText.gameObject.SetActive(false);
        //customerAnimationManager.PlayCustomerAnimation(); //test
        puzzleScreenInstance = Instantiate(puzzleScreenPrefab);
        puzzleController = puzzleScreenInstance.GetComponentInChildren<PuzzleControllerV2>();
        if (puzzleController == null)
            Debug.Log("puzzle controller is null");

        totalColumns = orderMaker.correctOrders.Count;
        puzzleController.totalColumns = totalColumns;
        puzzleController.rowTypeNumber = orderMaker.amountOfIngredients;
        for (int i = 0; i < totalColumns; i++)
        {
            correctRow.Add(orderMaker.correctOrders[i]); // doðru sýralar ordermakerdan alýnýr
            puzzleController.correctRow.Add(orderMaker.correctOrders[i]); // doðru sýralar puzzle controllera aktarýlýr
            Debug.Log("correct row: " + correctRow[i]);

        }
        //Debug.Log("correct row: " + puzzleScreenInstance.GetComponent<PuzzleController>().correctRow[0]);
        customerManager.isInPuzzle = true;
        puzzleController.PuzzleSpawner();
    }

    public void PuzzleFinished()
    {
        if (!customerManager.isInPuzzle) return;  // Prevent multiple calls if already processed
        Debug.Log("when puzzle finished orderID: " + customerManager.orderID);
        Debug.Log("when puzzle finished onOrder: " + OrderManagerPuzzle.onOrder);
        Debug.Log("PuzzleFinished called");

        correctOrderSpawner.InstantiateCorrectOrders();

        customerManager.isInPuzzle = false;
        OrderManagerPuzzle.selectingOrders = true;
        OrderManagerPuzzle.onOrder = 0;
        customerManager.isPuzzleSolved = true;
    }
}
