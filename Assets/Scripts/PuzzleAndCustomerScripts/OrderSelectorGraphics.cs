using UnityEngine;
using static PuzzleController;
using DG.Tweening;
using System.Collections;



public class OrderSelectorGraphics : MonoBehaviour
{
    [SerializeField] GameObject selector;
    [SerializeField] OrderManager orderManager;
    Transform selectorTransform;
    public float moveTime = 0.1f;
    bool enableMove = true;
    bool isActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectorTransform = selector.GetComponent<Transform>();
        selector.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!orderManager.isShopEmpty && !isActive)
        {
            selector.SetActive(true);
            isActive = true;
        }
        else if (orderManager.isShopEmpty && isActive)
        {
            selector.SetActive(false);
            isActive = false;
        }
    }

   

    void MoveSelectorRight()
    {

        selectorTransform.transform.DOBlendableMoveBy(new Vector3(5,0,0), moveTime).SetEase(Ease.OutBounce);

    }

    public void MoveSelectorLeft()
    {

        selectorTransform.transform.DOBlendableMoveBy(new Vector3(-5, 0, 0), moveTime).SetEase(Ease.OutBounce);

        
    }



    void ActivateSelector()
    {
        selector.SetActive(true);
    }

    void SelectorAfterDeletion()
    {
        if (OrderManagerPuzzle.activeOrder != 0) 
        {
            MoveSelectorLeft();
        }

    }

    private void OnEnable()
    {
        OrderManagerPuzzle.OnPuzzleRightArrow += MoveSelectorRight;
        OrderManagerPuzzle.OnPuzzleLeftArrow += MoveSelectorLeft;
        //OrderManagerPuzzle.OnCustomerDeleted += SelectorAfterDeletion;
        //OrderManagerPuzzle.OnMakeCustomer += ActivateSelector;
    }

    void OnDisable()
    {
        OrderManagerPuzzle.OnPuzzleRightArrow -= MoveSelectorRight;
        OrderManagerPuzzle.OnPuzzleLeftArrow -= MoveSelectorLeft;
        //OrderManagerPuzzle.OnCustomerDeleted -= SelectorAfterDeletion;
        //OrderManagerPuzzle.OnMakeCustomer -= ActivateSelector;
    }
}
