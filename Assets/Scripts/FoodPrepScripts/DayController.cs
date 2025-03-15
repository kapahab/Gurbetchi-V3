using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DayController : MonoBehaviour
{
    [SerializeField] Image dayEndBlackScreen;
    [SerializeField] TextMeshProUGUI[] dayEndText;
    [SerializeField] TextMeshProUGUI dayCounterOnScreen;
    public float fadeTime = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndDay()
    {
        FadeInScreen(fadeTime);
        StartCoroutine(Waiter(fadeTime));
        FadeOutScreen(fadeTime);
    }


    void FadeInScreen(float fadeInTime)
    {
        dayEndBlackScreen.DOFade(255f, fadeInTime);
        for (int i = 0; i < dayEndText.Length; i++)
        {
            dayEndText[i].DOFade(255f, fadeInTime);
        }
        StartCoroutine(Waiter(fadeInTime));
    }


    void FadeOutScreen(float fadeOutTime)
    {
        dayEndBlackScreen.DOFade(0f, fadeOutTime);
        for (int i = 0; i < dayEndText.Length; i++)
        {
            dayEndText[i].DOFade(0f, fadeOutTime);
        }
        StartCoroutine(Waiter(fadeOutTime));
    }

    IEnumerator Waiter(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
    }

    public void DayText()
    {
        dayCounterOnScreen.text =  gameFlow.dayCount.ToString();
    }



}
