using UnityEngine;

public class PlayerInputClearer : MonoBehaviour
{
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
        OrderManagerPuzzle.OnCustomerDeleted += ClearPlayerOrder;
    }

    private void OnDisable()
    {
        OrderManagerPuzzle.OnCustomerDeleted -= ClearPlayerOrder;
    }

    void ClearPlayerOrder()
    {
        gameFlow.totalPlayerList.Clear();
        gameFlow.carbList.Clear();
        gameFlow.toppingList.Clear();
        gameFlow.spiceList.Clear();
        gameFlow.sauceList.Clear();
        gameFlow.donerList.Clear();
    }
}
