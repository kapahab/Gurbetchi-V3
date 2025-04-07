using UnityEngine;

public class UIShutOff : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject foodNames;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void EnableFoodNames()
    {
        foodNames.SetActive(true);
    }

    void DisableFoodNames() 
    {
        foodNames.SetActive(false);
    }

}
