using UnityEngine;
using TMPro;

public class PointsText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    int points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        points = gameFlow.totalPoints;
        pointsText.text = "Points: " + points;
    }


}
