using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System;

public class DayManager : MonoBehaviour
{
    bool dayStarted = false;


    [SerializeField]OrderManager orderManager;

    DayController dayController;

    [SerializeField] TextMeshProUGUI timeText;

    WinLoseCondition winLoseCondition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        winLoseCondition = GetComponent<WinLoseCondition>();
        dayController = GetComponent<DayController>();
        DayTimeActivator(false);

        dayController.EndDay();


        StartCoroutine(StartDayDelayer( (dayController.fadeTime*4) + (dayController.holdTime * 3)));


    }

    // Update is called once per frame
    void Update()
    {
        if (!dayStarted)
        {
            return;
        }

        if (gameFlow.dayRemainingTime > 0f)
        {
            gameFlow.dayRemainingTime -= Time.deltaTime;
            DayTimeUpdater();
        }
        else
        {
            gameFlow.dayRemainingTime = 0f;
            DayTimeUpdater();
        }

        if (gameFlow.dayRemainingTime <= 0f && orderManager.isShopEmpty)
        {
            gameFlow.dayRemainingTime = 90f;
            winLoseCondition.EndDayPointChecker();
            EndDay();
        }

    }


    IEnumerator StartDayDelayer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dayStarted = true;
        DayTimeActivator(true);
        gameFlow.gameActive = true;
    }

    void DayTimeUpdater()
    {
        int minutes = Mathf.FloorToInt(gameFlow.dayRemainingTime / 60);
        int seconds = Mathf.FloorToInt(gameFlow.dayRemainingTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DayTimeActivator(bool activation)
    {
        timeText.gameObject.SetActive(activation);
    }

    

    void EndDay()
    {
        if (!winLoseCondition.hasLost)
        {
            DayTimeActivator(false);
            dayStarted = false;
            gameFlow.gameActive = false;
            gameFlow.dayCount++;
            dayController.EndDay();
            StartCoroutine(StartDayDelayer((dayController.fadeTime * 4) + (dayController.holdTime * 3)));
            orderManager.firstOrder = true;
        }
        else
        {
            //LoseCondition
            DayTimeActivator(false);
            dayStarted = false;
            gameFlow.gameActive = false;
        }
    }


    void EndOfDayCalculator()
    {

    }

}
