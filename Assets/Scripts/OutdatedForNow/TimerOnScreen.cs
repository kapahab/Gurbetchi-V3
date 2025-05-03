using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerOnScreen : MonoBehaviour
{
    [SerializeField]float ingredientScreenPos;
    [SerializeField] float customerScreenPos;
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, ingredientScreenPos);
    }

    void Update()
    {
        
    }

    void UpdateTimerPos()
    {
        if (gameFlow.screenSwitch)
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, ingredientScreenPos);
        else
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, customerScreenPos);

    }

    private void OnEnable()
    {
        EventManager.OnScreenSwitchToCustomer += UpdateTimerPos;
        OrderManagerPuzzle.OnScreenSwitchToIngredients += UpdateTimerPos;
    }

    private void OnDisable()
    {
        EventManager.OnScreenSwitchToCustomer += UpdateTimerPos;
        OrderManagerPuzzle.OnScreenSwitchToIngredients -= UpdateTimerPos;

    }
}


