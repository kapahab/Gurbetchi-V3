using TMPro;
using UnityEngine;

public class CustomerTimer : MonoBehaviour
{
    public float startTime = 90f;
    public bool timerStarted = false;
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
            //delete order tarz� bir �ey
        }
    }

    public void ClockStopped()
    {
        startTime = 0f;
        timerStarted = false;
        timerGraphics.UpdateTimer();
    }


}
