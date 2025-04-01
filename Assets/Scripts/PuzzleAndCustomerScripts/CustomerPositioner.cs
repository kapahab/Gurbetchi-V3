using UnityEngine;

public class CustomerPositioner : MonoBehaviour
{
    [SerializeField]CustomerManager customerManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customerManager = GetComponent<CustomerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PositionReAdjuster() //this runs after orderID is recalculated
    {
        this.gameObject.transform.position = new Vector3(-33f +(5 * customerManager.orderID), -0.75f, 0);
    }

}
