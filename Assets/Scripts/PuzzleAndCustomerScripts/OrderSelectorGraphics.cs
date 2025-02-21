using UnityEngine;
using static PuzzleController;

public class OrderSelectorGraphics : MonoBehaviour
{
    [SerializeField] GameObject selector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selector.SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

   

    void MoveSelectorRight()
    {
        selector.GetComponent<Transform>().position += new Vector3(5, 0, 0);
    }

    void MoveSelectorLeft()
    {
        selector.GetComponent<Transform>().position += new Vector3(-5, 0, 0);
    }


    void ActivateSelector()
    {
        selector.SetActive(true);
    }

    void SelectorAfterDeletion()
    {
        if (OrderManagerPuzzle.deletedOrder != 0)
            MoveSelectorLeft();
    }

    private void OnEnable()
    {
        OrderManagerPuzzle.OnPuzzleRightArrow += MoveSelectorRight;
        OrderManagerPuzzle.OnPuzzleLeftArrow += MoveSelectorLeft;
        OrderManagerPuzzle.OnCustomerDeleted += SelectorAfterDeletion;
        //OrderManagerPuzzle.OnMakeCustomer += ActivateSelector;
    }

    void OnDisable()
    {
        OrderManagerPuzzle.OnPuzzleRightArrow -= MoveSelectorRight;
        OrderManagerPuzzle.OnPuzzleLeftArrow -= MoveSelectorLeft;
        OrderManagerPuzzle.OnCustomerDeleted -= SelectorAfterDeletion;
        //OrderManagerPuzzle.OnMakeCustomer -= ActivateSelector;
    }
}
