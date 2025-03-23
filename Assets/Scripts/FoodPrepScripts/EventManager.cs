using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void RegularInput();
    public static event RegularInput OnRegularInput;

    public delegate void DonerEnter();
    public static event DonerEnter OnDonerEnter;
    private bool inDonerMinigame = false;
    ScrappyInputGraphics darkenOthers;


    public delegate void DonerExit();
    public static event DonerExit OnDonerExit;

    public delegate void ServePlate();
    public static event ServePlate OnPlateServed;

    public delegate void PrepareOrder();
    public static event PrepareOrder OnOrderPrepared;

    public delegate void ScreenSwitchToCustomer();
    public static event ScreenSwitchToCustomer OnScreenSwitchToCustomer;


    public delegate void FoodTrashed();
    public static event FoodTrashed OnFoodTrashed;

    public delegate void PauseButtonPressed();
    public static event PauseButtonPressed OnPauseButtonPressed;

    FoodOnPlate foodOnPlate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        darkenOthers = GetComponent<ScrappyInputGraphics>();
        foodOnPlate = GetComponent<FoodOnPlate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFlow.gameActive)
        {
            if (gameFlow.screenSwitch)
            {
                foreach (string keyName in gameFlow.allKeyBindingsUsed)
                {
                    if (Input.GetKeyDown(keyName) && !inDonerMinigame)
                    {
                        Debug.Log("Regular input");
                        if (OnRegularInput != null)
                            OnRegularInput();
                    }
                }

                if (Input.GetKeyDown("d")) //doner enter ve exit ayný anda çalýþýyo
                {
                    DonerChecker();
                }

                if (Input.GetKeyDown("x"))
                {
                    if (gameFlow.carbList.Count != 0 && gameFlow.toppingList.Count != 0 && gameFlow.sauceList.Count != 0 && gameFlow.spiceList.Count != 0 && gameFlow.donerList.Count != 0)
                        OnFoodTrashed();
                }



                if (Input.GetKeyDown("space"))
                {
                    Debug.Log("Plate served");
                    StartCoroutine(WaitAndSwitch());

                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    StartCoroutine(WaitAndSwitchScreen());
                }
            }
        }


        if (Input.GetKeyDown("escape"))
        {
            if (!gameFlow.isGamePaused)
            {

                OnPauseButtonPressed();
                gameFlow.gameActive = false;
                gameFlow.isGamePaused = true;
                Debug.Log("Game paused");

            }
            else
            {
                OnPauseButtonPressed();
                gameFlow.gameActive = true;
                gameFlow.isGamePaused = false;
                Debug.Log("Game resumed");
            }
        }
    }

    private void DonerChecker()
    {
        if (inDonerMinigame)
        {
            Debug.Log("Doner exit");
            OnDonerExit();
            darkenOthers.LightenObjects();
            inDonerMinigame = false;
        }
        else
        {
            Debug.Log("Doner enter");
            OnDonerEnter();
            darkenOthers.DarkenObjects();
            inDonerMinigame = true;
        }
    }

    IEnumerator WaitAndSwitch()
    {
        yield return new WaitForSeconds(0.01f);
        OnPlateServed();
        OnScreenSwitchToCustomer();
    }

    IEnumerator WaitAndSwitchScreen()
    {
        yield return new WaitForSeconds(0.01f);
        OnScreenSwitchToCustomer();
        Camera.main.transform.position = new Vector3(-30, 0, -10);
        gameFlow.screenSwitch = false;
        Debug.Log("Screen switched to customer");
    }
}

