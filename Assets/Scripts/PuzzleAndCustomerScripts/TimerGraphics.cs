using TMPro;
using UnityEngine;

public class TimerGraphics : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] CustomerTimer customerTimer;
    [SerializeField] CustomerManager customerManager;
    int offsetAmount = 300;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFlow.screenSwitch)
            timerText.gameObject.SetActive(false);
        else
            timerText.gameObject.SetActive(true);
    }

    public void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(customerTimer.startTime / 60);
        int seconds = Mathf.FloorToInt(customerTimer.startTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerPosition() // not needed
    {
/*
        timerText.transform.position = new Vector3(225+(customerManager.orderID * offsetAmount), -200, 0);*/
    }

    void EnableTimerUI()
    {/*
        timerText.gameObject.SetActive(true);*/
    }

    void DisableTimerUI()
    {/*
        timerText.gameObject.SetActive(false);*/
    }

    private void OnEnable()
    {
        OrderManagerPuzzle.OnCustomerDeleted += TimerPosition;
        EventManager.OnScreenSwitchToCustomer += EnableTimerUI;
        OrderManagerPuzzle.OnScreenSwitchToIngredients += DisableTimerUI;
    }

    private void OnDisable()
    {
        OrderManagerPuzzle.OnCustomerDeleted -= TimerPosition;
        EventManager.OnScreenSwitchToCustomer -= EnableTimerUI;
        OrderManagerPuzzle.OnScreenSwitchToIngredients -= DisableTimerUI;
    }
}
