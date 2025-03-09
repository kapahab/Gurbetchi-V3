using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleColor : MonoBehaviour
{
    [SerializeField] GameObject puzzleSelector;
    int closenessIndex;
    [SerializeField] PuzzleControllerV2 puzzleController;
    int currentColumn;
    List<int> correctRow;
    List<int> currentRow;
    Image selectorImage;
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
        selectorImage = puzzleSelector.GetComponent<Image>();
        selectorImage.material.color = Color.white; 
        if (closenessIndex == 0)
        {
            selectorImage.color = new Color(0, 1, 0);
        }
        else
        {
            selectorImage.color = new Color(closenessIndex / 1.5f, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnEnable()
    {
        PuzzleControllerV2.OnPuzzleUp += PuzzleIndicatorUp;
        PuzzleControllerV2.OnPuzzleDown += PuzzleIndicatorDown;
        PuzzleControllerV2.OnPuzzleLeft += PuzzleIndicatorLeft;
        PuzzleControllerV2.OnPuzzleRight += PuzzleIndicatorRight;
    }


    void OnDisable()
    {
        PuzzleControllerV2.OnPuzzleUp -= PuzzleIndicatorUp;
        PuzzleControllerV2.OnPuzzleDown -= PuzzleIndicatorDown;
        PuzzleControllerV2.OnPuzzleLeft -= PuzzleIndicatorLeft;
        PuzzleControllerV2.OnPuzzleRight -= PuzzleIndicatorRight;
    }
    
    public void PuzzleIndicatorLeft()
    {
        currentColumn = puzzleController.currentColumn;
        correctRow = puzzleController.correctRow;
        currentRow = puzzleController.currentRow;

        closenessIndex = Mathf.Abs(correctRow[currentColumn - 1] - currentRow[currentColumn-1]);
        if (closenessIndex == 0)
        {
            selectorImage.color = new Color(0, 1, 0);
        }
        else
        {
            selectorImage.color = new Color(closenessIndex / 1.5f, 0, 0);
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
            selectorImage.color = new Color(0, 1, 0);
        }
        else
        {
            selectorImage.color = new Color(closenessIndex / 1.5f, 0, 0);
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
            selectorImage.color = new Color(0, 1, 0);
        }
        else
        {
            selectorImage.color = new Color(closenessIndex / 1.5f, 0, 0);
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
            selectorImage.color = new Color(0, 1, 0);
        }
        else
        {
            selectorImage.color = new Color(closenessIndex / 1.5f, 0, 0);
        }
    }
}
