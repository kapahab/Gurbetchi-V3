using System.Collections.Generic;
using UnityEngine;

public class CustomerPuzzleCallerDestroyer : MonoBehaviour
{
    [SerializeField] CustomerManager customerManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GetPuzzleScreen()
    {/*
        customerManager.germanText.gameObject.SetActive(false);
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
            correctRow.Add(orderMaker.correctOrders[i]); // do�ru s�ralar ordermakerdan al�n�r
            puzzleController.correctRow.Add(orderMaker.correctOrders[i]); // do�ru s�ralar puzzle controllera aktar�l�r
            Debug.Log("correct row: " + correctRow[i]);

        }
        //Debug.Log("correct row: " + puzzleScreenInstance.GetComponent<PuzzleController>().correctRow[0]);
        customerManager.isInPuzzle = true;
        puzzleController.PuzzleSpawner();*/
    }

    public void PuzzleFinished()
    {/*
        if (!customerManager.isInPuzzle) return;  // Prevent multiple calls if already processed
        Debug.Log("when puzzle finished orderID: " + customerManager.orderID);
        Debug.Log("when puzzle finished onOrder: " + OrderManagerPuzzle.onOrder);
        Debug.Log("PuzzleFinished called");

        correctOrderSpawner.InstantiateCorrectOrders();

        customerManager.isInPuzzle = false;
        OrderManagerPuzzle.selectingOrders = true;
        OrderManagerPuzzle.onOrder = 0;
        customerManager.isPuzzleSolved = true;*/
    }
}
