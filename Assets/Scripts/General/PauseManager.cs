using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void TimeStartAndStop()
    {
        if (!gameFlow.isGamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    
    void BannerMakerAndUnmaker()
    {
        if (!gameFlow.isGamePaused)
            pauseMenu.SetActive(true);
        else
            pauseMenu.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.OnPauseButtonPressed += TimeStartAndStop;
        EventManager.OnPauseButtonPressed += BannerMakerAndUnmaker;
    }

    private void OnDisable()
    {
        EventManager.OnPauseButtonPressed -= TimeStartAndStop;
        EventManager.OnPauseButtonPressed -= BannerMakerAndUnmaker;
    }


    public void ButtonContinue()
    {
        TimeStartAndStop();
        BannerMakerAndUnmaker();
        gameFlow.isGamePaused = false;
    }

    public void ButtonExit()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
