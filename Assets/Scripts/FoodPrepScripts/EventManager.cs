using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        darkenOthers = GetComponent<ScrappyInputGraphics>();

    }

    // Update is called once per frame
    void Update()
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

            if (Input.GetKeyDown("escape"))
            {
                OnFoodTrashed();
            }



            if (Input.GetKeyDown("return"))
            {
                Debug.Log("Plate served");
                OnPlateServed();
                OnScreenSwitchToCustomer(); //daha þýk bir çözüm belki olabilir(yemek yollanýrken ui kapanmasý için)
            }
            /*
            if (Input.GetKeyDown("return"))
            {
                Debug.Log("Order prepared");
                OnOrderPrepared();
            }
            */
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                OnScreenSwitchToCustomer();
                Camera.main.transform.position = new Vector3(-30, 0, -10);
                gameFlow.screenSwitch = false;
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
}

