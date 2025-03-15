using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DayManager : MonoBehaviour
{
    bool dayStarted = false;

    float dayTimer = 0f;

    OrderManager orderManager;

    DayController dayController;

    [SerializeField] TextMeshProUGUI timeText; 
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orderManager = GetComponent<OrderManager>();
        dayController = GetComponent<DayController>();

        dayController.EndDay();

        StartCoroutine(StartDayDelayer(dayController.fadeTime));
        gameFlow.gameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (dayStarted)
        {
            dayTimer += Time.deltaTime;
            DayTimeUpdater();
            if (dayTimer >= 60f && orderManager.isShopEmpty) // bu kod þuan çalýþmayacak ama bunun gibi bir þey olmasýný istiyorum 
            {
                EndDay();
            }
        }
    }


    IEnumerator StartDayDelayer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dayStarted = true;
    }

    void DayTimeUpdater()
    {
        int minutes = Mathf.FloorToInt(dayTimer / 60);
        int seconds = Mathf.FloorToInt(dayTimer % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndDay()
    {
        dayStarted = false;
        gameFlow.gameStart = false;
        gameFlow.dayCount++;
        dayController.EndDay();
        StartCoroutine(StartDayDelayer(dayController.fadeTime));
        dayController.DayText();
        gameFlow.gameStart = true;
        dayStarted = true;
    }

}
