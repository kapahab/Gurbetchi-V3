using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Experimental.GlobalIllumination;


public class DayController : MonoBehaviour
{
    [SerializeField] Image dayEndBlackScreen;
    [SerializeField] TextMeshProUGUI[] dayEndText;
    [SerializeField] TextMeshProUGUI dayCounterOnScreen;
    public float fadeTime = 1f;
    public float holdTime = 0.5f;
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
        DayText();
        Fade(fadeTime, holdTime);
        
    }


    void Fade(float fadeTime, float holdTime = 0f, TweenCallback onComplete = null)
    {
        // sekans: siyah ekraný aç, bekle, yazýlarý aç, bekle, yazýlarý kapat, bekle, siyah ekraný kapat
        //4x fade, 3x wait


        Sequence fadeSequence = DOTween.Sequence();

        fadeSequence.Append(dayEndBlackScreen.DOFade(1f, fadeTime));


        if (holdTime > 0f)
        {
            fadeSequence.AppendInterval(holdTime);
        }


        for (int i = 0; i < dayEndText.Length; i++)
        {
            fadeSequence.Join(dayEndText[i].DOFade(1f, fadeTime));
        }

        if (holdTime > 0f)
        {
            fadeSequence.AppendInterval(holdTime);
        }


        for (int i = 0; i < dayEndText.Length; i++)
        {
            fadeSequence.Join(dayEndText[i].DOFade(0f, fadeTime));
        }

        if (holdTime > 0f)
        {
            fadeSequence.AppendInterval(holdTime);
        }



        fadeSequence.Append(dayEndBlackScreen.DOFade(0f, fadeTime));

 

        if (onComplete != null)
        {
            fadeSequence.AppendCallback(onComplete);
        }
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
