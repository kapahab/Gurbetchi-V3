using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class PuzzleControllerV2 : MonoBehaviour
{
    public delegate void PuzzleUp();
    public static event PuzzleUp OnPuzzleUp;

    public delegate void PuzzleDown();
    public static event PuzzleDown OnPuzzleDown;

    public delegate void PuzzleRight();
    public static event PuzzleRight OnPuzzleRight;

    public delegate void PuzzleLeft();
    public static event PuzzleLeft OnPuzzleLeft;

    public delegate void CheckColumn();
    public static event CheckColumn OnCheckColumn;

    public delegate void ActivateOrder();
    public static event ActivateOrder OnActivateOrder;

    List<int> totalRows = new List<int>(); //reformat gerekli
    public int totalColumns; // bunlar birbirini tamamlayan listeler olabilir
    public List<int> currentRow = new List<int>();
    public int currentColumn = 0;
    public List<int> correctRow;
    public List<int> correctEnteredRow = new List<int> { };


    [SerializeField] OrderMaker orderMaker;
    public List<bool> isColumnLocked = new List<bool> { };



    public bool isInOrder = false;


    [SerializeField] GameObject[] puzzleColumns;

    List<GameObject> instantiatedPuzzleColumns = new List<GameObject>();
    List<PuzzleVerticalCounter> columnInfo = new List<PuzzleVerticalCounter>();
    int displacementY = 115;

    public List<int> rowTypeNumber = new List<int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    
    public void PuzzleSpawner()
    {
        for (int i = 0; i < totalColumns; i++)
        {
            Debug.Log("instantiating: " + i + " row");
            GameObject newColumn = (Instantiate(puzzleColumns[rowTypeNumber[i]], this.transform));
            instantiatedPuzzleColumns.Add(newColumn);
            PuzzleVerticalCounter newColumnInfo = instantiatedPuzzleColumns[i].GetComponent<PuzzleVerticalCounter>();
            columnInfo.Add(newColumnInfo);
            columnInfo[i].columnNumber = i;
            currentRow.Add(CurrentRowCalculator(i));
            totalRows.Add(columnInfo[i].transform.childCount);
        }




        for (int i = 0; i < totalColumns; i++)
        {
            StartCoroutine(DelayedStartYPos(i));
            StartYPos(i);
            isColumnLocked.Add(false);
        }

    }

    IEnumerator DelayedStartYPos(int i)
    {
        yield return new WaitForEndOfFrame(); // Wait until UI updates
        StartYPos(i);
    }

    void StartYPos(int i)
    {

        RectTransform rect = instantiatedPuzzleColumns[i].GetComponent<RectTransform>();
        int yOffsetDown = CurrentRowCalculator(i);
        Debug.Log("offset: " + yOffsetDown * displacementY);
        rect.anchoredPosition += new Vector2(0, (yOffsetDown * displacementY));
    }

    private int CurrentRowCalculator(int i)
    {
        return (columnInfo[i].transform.childCount - 1) / 2;
    }


    // Update is called once per frame
    public void Update()
    {


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if ((currentRow[currentColumn] > 0))
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

            if (isColumnLocked[currentColumn])
            {
                OnPuzzleRight();
                currentColumn++;
            }

        }

    }

}
