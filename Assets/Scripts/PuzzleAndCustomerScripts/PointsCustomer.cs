using UnityEngine;

public class PointsCustomer : MonoBehaviour
{
    int basePoint = 500;
    [SerializeField] CustomerTimer customerTimer;
    bool isCalculated = false;
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
        if (!isCalculated)
        {
            Debug.Log("entered point calculator so order is true");
            gameFlow.totalPoints += (basePoint * (int)Mathf.Round(customerTimer.startTime)) / 100;
            isCalculated = true;
        }
    }
}
