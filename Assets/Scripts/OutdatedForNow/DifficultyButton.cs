using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    [SerializeField] private int difficulty;
    [SerializeField] private GameObject titleScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {/*
        titleScreen.SetActive(true);
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " button was clicked");
        gameFlow.gameDifficulty = difficulty;
        gameFlow.gameStart = true;
        CloseTitle();
    }

    private void CloseTitle()
    {
        titleScreen.SetActive(false);
    }
}

