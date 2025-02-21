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
        this.gameObject.transform.position = new Vector3(-27.5f + (5 * customerManager.orderID), -1.77f, 0);
    }

}
