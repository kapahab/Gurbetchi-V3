using UnityEngine;
using static PuzzleController;

public class OrderEventManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public delegate void SelectOrder();
    public static event SelectOrder OnOrderSelected;

    public delegate void FoodBroughtToCounter();
    public static event FoodBroughtToCounter OnFoodBroughtToCounter;

    public delegate void SelectToServeFood();
    public static event SelectToServeFood OnSelectToServeFood;

    public delegate void DeleteCustomer();
    public static event DeleteCustomer OnDeleteCustomer;

    public delegate void MakeCustomer();
    public static event MakeCustomer OnMakeCustomer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
