using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    [SerializeField] GameObject tutorialScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTutorialScreen()
    {
        if (tutorialScreen.activeSelf)
            tutorialScreen.SetActive(false);
        else tutorialScreen.SetActive(true);

    }

}
