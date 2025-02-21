using TMPro;
using UnityEngine;

public class CustomerTimer : MonoBehaviour
{
    public float startTime = 60f;
    bool timerStarted = false;
    [SerializeField] TimerGraphics timerGraphics;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            if (startTime > 0)
            {
                startTime -= Time.deltaTime;
                timerGraphics.UpdateTimer();
            }
            //else
            //delete order tarzý bir þey
        }
    }
    

}
