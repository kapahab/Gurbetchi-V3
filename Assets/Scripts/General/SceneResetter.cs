using UnityEngine;

public class SceneResetter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScene()
    {
        gameFlow.totalPlayerList.Clear();
        gameFlow.totalPoints = 0;
        gameFlow.dayCount = 1;
    }
}
