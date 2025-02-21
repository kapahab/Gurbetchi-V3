using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using Random = UnityEngine.Random;


public class PuzzleController : MonoBehaviour
{
    public delegate void PuzzleUp();
    public event PuzzleUp OnPuzzleUp;

    public delegate void PuzzleDown();
    public event PuzzleDown OnPuzzleDown;

    public delegate void PuzzleRight();
    public event PuzzleRight OnPuzzleRight;

    public delegate void PuzzleLeft();
    public event PuzzleLeft OnPuzzleLeft;

    public delegate void CheckColumn();
    public event CheckColumn OnCheckColumn;

    public delegate void ActivateOrder();
    public event ActivateOrder OnActivateOrder;

    List<int> totalRows = new List<int> { 2, 4, 1, 1, 2 };
    int totalColumns = 5; // bunlar birbirini tamamlayan listeler olabilir
    public List<int> currentRow; 
    public int currentColumn = 0;
    public List<int> correctRow;
    public List<int> correctEnteredRow = new List<int> { } ;


    [SerializeField] OrderMaker orderMaker;
    public List<bool> isColumnLocked = new List<bool> { };
    


    public bool isInOrder = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        currentRow = new List<int> { 1, 2, 1, 1, 1 };


        for (int i = 0; i < totalColumns; i++)
        {
            isColumnLocked.Add(false);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        /*
        if (orderID == OrderManagerPuzzle.onOrder && !isInOrder)
        {
            OnActivateOrder();
            Debug.Log("order being activated");
        }
        */


        if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (currentRow[currentColumn] > 0)
                {
                    if (!isColumnLocked[currentColumn])
                    {
                        OnPuzzleDown();
                        currentRow[currentColumn]--;
                    }
                }
                Debug.Log("when moved up row on column: " + currentColumn + "is: " + currentRow[currentColumn]);
            }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                if (currentRow[currentColumn] < totalRows[currentColumn])
                {
                    if (!isColumnLocked[currentColumn])
                    {
                        OnPuzzleUp();
                        currentRow[currentColumn]++;
                    }
                }
                Debug.Log("when moved down row on column: " + currentColumn + "is: " + currentRow[currentColumn]);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentColumn < totalColumns)
                {

                    OnPuzzleRight();
                    currentColumn++;

                }
                Debug.Log("on column: " + currentColumn);

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentColumn > 0)
                {

                    OnPuzzleLeft();
                    currentColumn--;

                }
                Debug.Log("on column: " + currentColumn);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnCheckColumn();
                Debug.Log("checking column");
            }

        
        /*
        if (enteredOrder[0] == correctRow[0]) //testing...
        {
            Debug.Log("order is correct");
            Destroy(transform.parent.gameObject);
        }
        */
    }

    /*
    void MakeCorrectRowTemp()
    {
        orderMaker.MakeOrder();
        Debug.Log("first correct ingredient: " + orderMaker.correctOrders[0]);
        Debug.Log("first correct ingredient: " + orderMaker.correctOrders[1]);
        Debug.Log("total columns is " + totalColumns);

        for (int i = 0; i < totalColumns; i++)
        {
            correctRow.Add(orderMaker.correctOrders[i]);
        }
    }
    */
    

}
