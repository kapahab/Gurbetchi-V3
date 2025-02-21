using UnityEngine;

public class PointsCustomer : MonoBehaviour
{
    int basePoint = 500;
    [SerializeField] CustomerTimer customerTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointCalculator()
    {
        gameFlow.totalPoints += (basePoint * (int)Mathf.Round(customerTimer.startTime))/100;
    }
}
