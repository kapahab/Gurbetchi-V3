using System.Collections.Generic;
using UnityEngine;

public class PuzzleLogic : MonoBehaviour
{
    [SerializeField] PuzzleController puzzleController;
    [SerializeField] GameObject puzzleScreen;
    [SerializeField] GameObject germanText;
    [SerializeField] GameObject[] completedCarb;
    [SerializeField] GameObject[] completedTopping;
    [SerializeField] GameObject[] completedSpice;
    [SerializeField] GameObject[] completedSauce;
    [SerializeField] GameObject[] completedDoner;

    
    bool completionCheck = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnEnable()
    {
        puzzleController.OnCheckColumn += CheckColumn;
        //puzzleController.OnActivateOrder += OrderActivation;
    }


    void OnDisable()
    {
        puzzleController.OnCheckColumn -= CheckColumn;
        //puzzleController.OnActivateOrder -= OrderActivation;
    }

    private void DeactivatePuzzle()
    {
        //sadece puzzle prefabi yapmak için bura düzenlenmelidir
        Destroy(puzzleController.gameObject);

    }

    /*
    private void OrderActivation()
    {
        puzzleScreen.SetActive(true);
        germanText.SetActive(false);
        puzzleController.isInOrder = true;
    }
    */

    private void CheckColumn()
    {
        if (puzzleController.currentRow[puzzleController.currentColumn] == puzzleController.correctRow[puzzleController.currentColumn])
        {
            puzzleController.isColumnLocked[puzzleController.currentColumn] = true;
            puzzleController.correctEnteredRow.Add(puzzleController.currentRow[puzzleController.currentColumn]);
            if (PuzzleChecker())
                DeactivatePuzzle();
        
        }
        else
        {
            Debug.Log("Column is not correct");
        }
    }

    private bool PuzzleChecker()
    {
        for (int i = 0; i < puzzleController.isColumnLocked.Count; i++)
        {
            if (puzzleController.isColumnLocked[i] == false)
            {
                return false;
            }
        }
        return true;
    }


}
