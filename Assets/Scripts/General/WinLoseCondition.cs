using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WinLoseCondition : MonoBehaviour //ayrica kaybetme ekrani buton fonksiyonlari icerir
{
    [SerializeField] GameObject loseScreen;
    public bool hasLost = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EndDayPointChecker()
    {
        if (gameFlow.totalPoints < 0)
        {
            LoseCondition();
        }
        else
            return;

 
    }

    void LoseCondition()
    {
        hasLost = true;
        StartCoroutine(LoseScreenActivator());
    }

    IEnumerator LoseScreenActivator()
    {
        loseScreen.SetActive(true);
        loseScreen.GetComponentInChildren<CanvasGroup>().alpha = 0;
        loseScreen.GetComponentInChildren<CanvasGroup>().DOFade(1f, 2f);
        yield return new WaitForSeconds(2f);
    }


    public void RetryButton()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void ExitButton()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
