using UnityEngine;

public class CameraChangeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraToCustomer()
    {
        Debug.Log("Camera to customer");
        Camera.main.transform.position = new Vector3(-30, 0, -10);
        gameFlow.screenSwitch = false;
    }

    public void CameraToFoodSpace()
    {
        Debug.Log("Camera to food space");
        Camera.main.transform.position = new Vector3(0, 0, -10);
        gameFlow.screenSwitch = true;
    }

    void OnEnable()
    {
        OrderManagerPuzzle.OnScreenSwitchToIngredients  += CameraToFoodSpace;
        EventManager.OnScreenSwitchToCustomer += CameraToCustomer;
    }

    void OnDisable()
    {
        OrderManagerPuzzle.OnScreenSwitchToIngredients -= CameraToFoodSpace;
        EventManager.OnScreenSwitchToCustomer -= CameraToCustomer;
    }
}
