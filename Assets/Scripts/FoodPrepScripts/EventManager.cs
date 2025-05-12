using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void RegularInput();
    public static event RegularInput OnRegularInput;

    public delegate void CarbInput();
    public static event CarbInput OnCarbInput;

    public delegate void ResetFoodMaking();
    public static event ResetFoodMaking OnResetFoodMaking;

    public delegate void DonerEnter();
    public static event DonerEnter OnDonerEnter;
    private bool inDonerMinigame = false;

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
        foodOnPlate = GetComponent<FoodOnPlate>();
    }

    // Update is called once per frame
    void Update()
    {
        DonerQTE.donerCheck = inDonerMinigame; 

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

        if (!gameFlow.gameActive)
        {
            return;
        }
        if (!gameFlow.screenSwitch)
        {
            return;
        }

        if (Input.GetKeyDown("d")) //doner enter ve exit ayný anda çalýþýyo
        {
            DonerChecker();
        }

        //if (gameFlow.isCarbOnTable) // geri kalan yemek ürünlerine sadece ekmek masadaysa ulaþýlýr
        //{
        //    foreach (string keyName in gameFlow.allKeyBindingsUsed)
        //    {
        //        if (Input.GetKeyDown(keyName) && !inDonerMinigame)
        //        {
        //            Debug.Log("Regular input");
        //            if (OnRegularInput != null)
        //                OnRegularInput();
        //        }
        //    }

        //    if (Input.GetKeyDown("d")) //doner enter ve exit ayný anda çalýþýyo
        //    {
        //        DonerChecker();
        //    }
        //}

        //if (!gameFlow.isCarbOnTable) // carb sadece tek bir tür konulur
        //{
        //    foreach (string keyName in gameFlow.carbKeyBindingsUsed)
        //    {
        //        if (Input.GetKeyDown(keyName) && !inDonerMinigame)
        //        {
        //            Debug.Log("Carb input");
        //            if (OnCarbInput != null)
        //                OnCarbInput();
        //            gameFlow.isCarbOnTable = true; // ekmek masaya konulduðunda true olur
        //        }
        //    }
        //}





        if (Input.GetKeyDown("x"))
        {
            if (gameFlow.carbList.Count != 0 || gameFlow.toppingList.Count != 0 || gameFlow.sauceList.Count != 0 || gameFlow.spiceList.Count != 0 || gameFlow.donerList.Count != 0)
            {
                OnFoodTrashed();
                if (inDonerMinigame)
                    DonerChecker();
                OnResetFoodMaking();

            }
        }

        if (gameFlow.isZoneSelected)
            return;

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Plate served");
            StartCoroutine(WaitAndSwitch());
            if (inDonerMinigame)
                DonerChecker();
            OnResetFoodMaking();

            
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(WaitAndSwitchScreen());
        }

    }

    private void DonerChecker()
    {
        if (inDonerMinigame)
        {
            Debug.Log("Doner exit");
            OnDonerExit();
            inDonerMinigame = false;
        }
        else
        {
            Debug.Log("Doner enter");
            OnDonerEnter();
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
        //Camera.main.transform.position = new Vector3(-30, 0, -10);
        //gameFlow.screenSwitch = false;
        Debug.Log("Screen switched to customer");
    }
}

