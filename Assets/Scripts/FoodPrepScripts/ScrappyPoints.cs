using UnityEngine;

public class ScrappyPoints : MonoBehaviour
{
    public static int points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointUp()
    {
        Debug.Log("PointUp çalýþtý");
        points += 50;
        Debug.Log("points: " + points);
    }

    public void PointDown()
    {
        Debug.Log("PointDown çalýþtý");
        points -= 50;
        Debug.Log("points: " + points);
    }
}
