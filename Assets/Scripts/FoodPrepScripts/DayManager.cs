using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System;

public class DayManager : MonoBehaviour
{
    bool dayStarted = false;

    public float dayTickingDownTime;

    [SerializeField]OrderManager orderManager;

    DayController dayController;

    [SerializeField] TextMeshProUGUI timeText;

    WinLoseCondition winLoseCondition;

    [SerializeField] CameraChangeController cameraChangeController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dayTickingDownTime = gameFlow.dayRemainingTime;
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

        if (dayTickingDownTime > 0f)
        {
            dayTickingDownTime -= Time.deltaTime;
            DayTimeUpdater();
        }
        else
        {
            dayTickingDownTime = 0f;
            DayTimeUpdater();
        }

        if (dayTickingDownTime <= 0f && orderManager.isShopEmpty)
        {
            dayTickingDownTime = gameFlow.dayRemainingTime;
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
        int minutes = Mathf.FloorToInt(dayTickingDownTime / 60);
        int seconds = Mathf.FloorToInt(dayTickingDownTime % 60);
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
            gameFlow.isCarbOnTable = false;
            cameraChangeController.CameraToFoodSpace();
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
