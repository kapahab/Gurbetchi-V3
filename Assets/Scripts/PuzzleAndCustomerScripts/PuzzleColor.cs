using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleColor : MonoBehaviour
{
    [SerializeField] GameObject puzzleSelector;
    int closenessIndex;
    [SerializeField] PuzzleController puzzleController;
    int currentColumn;
    List<int> correctRow;
    List<int> currentRow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created*/
    //abstract yapmak için: current row, correct row, game object
    void Start()
    {
        currentColumn = puzzleController.currentColumn;
        correctRow = puzzleController.correctRow;
        currentRow = puzzleController.currentRow;
        Debug.Log("current column: " + currentColumn);
        Debug.Log("correct row: " + correctRow[currentColumn]);
        Debug.Log("current row: " + currentRow[currentColumn]);
        closenessIndex = Mathf.Abs(correctRow[currentColumn] - currentRow[currentColumn]);
        if (closenessIndex == 0)
        {
            puzzleSelector.GetComponent<SpriteRenderer>().material.color = new Color(0, 1, 0);
        }
        else
        {
            puzzleSelector.GetComponent<SpriteRenderer>().material.color = new Color(closenessIndex / 1.5f, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnEnable()
    {
        puzzleController.OnPuzzleUp += PuzzleIndicatorUp;
        puzzleController.OnPuzzleDown += PuzzleIndicatorDown;
        puzzleController.OnPuzzleLeft += PuzzleIndicatorLeft;
        puzzleController.OnPuzzleRight += PuzzleIndicatorRight;
    }


    void OnDisable()
    {
        puzzleController.OnPuzzleUp -= PuzzleIndicatorUp;
        puzzleController.OnPuzzleDown -= PuzzleIndicatorDown;
        puzzleController.OnPuzzleLeft -= PuzzleIndicatorLeft;
        puzzleController.OnPuzzleRight -= PuzzleIndicatorRight;
    }
    
    public void PuzzleIndicatorLeft()
    {
        currentColumn = puzzleController.currentColumn;
        correctRow = puzzleController.correctRow;
        currentRow = puzzleController.currentRow;

        closenessIndex = Mathf.Abs(correctRow[currentColumn - 1] - currentRow[currentColumn-1]);
        if (closenessIndex == 0)
        {
            puzzleSelector.GetComponent<SpriteRenderer>().material.color = new Color(0, 1, 0);
        }
        else
        {
            puzzleSelector.GetComponent<SpriteRenderer>().material.color = new Color(closenessIndex / 1.5f, 0, 0);
        }
    }

    public void PuzzleIndicatorRight()
    {
        currentColumn = puzzleController.currentColumn;
        correctRow = puzzleController.correctRow;
        currentRow = puzzleController.currentRow;

        closenessIndex = Mathf.Abs(correctRow[currentColumn + 1] - currentRow[currentColumn + 1]);
        if (closenessIndex == 0)
        {
            puzzleSelector.GetComponent<SpriteRenderer>().material.color = new Color(0, 1, 0);
        }
        else
        {
            puzzleSelector.GetComponent<SpriteRenderer>().material.color = new Color(closenessIndex / 1.5f, 0, 0);
        }
    }

    public void PuzzleIndicatorUp()
    {
        currentColumn = puzzleController.currentColumn;
        correctRow = puzzleController.correctRow;
        currentRow = puzzleController.currentRow;

        closenessIndex = Mathf.Abs(correctRow[currentColumn] - currentRow[currentColumn] - 1);
        if (closenessIndex == 0)
        {
            puzzleSelector.GetComponent<SpriteRenderer>().material.color = new Color(0, 1, 0);
        }
        else
        {
            puzzleSelector.GetComponent<SpriteRenderer>().material.color = new Color(closenessIndex / 1.5f, 0, 0);
        }
    }

    public void PuzzleIndicatorDown()
    {
        currentColumn = puzzleController.currentColumn;
        correctRow = puzzleController.correctRow;
        currentRow = puzzleController.currentRow;

        closenessIndex = Mathf.Abs(correctRow[currentColumn] - currentRow[currentColumn] + 1);
        if (closenessIndex == 0)
        {
            puzzleSelector.GetComponent<SpriteRenderer>().material.color = new Color(0, 1, 0);
        }
        else
        {
            puzzleSelector.GetComponent<SpriteRenderer>().material.color = new Color(closenessIndex / 1.5f, 0, 0);
        }
    }
}
