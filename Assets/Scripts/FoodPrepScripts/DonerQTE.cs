using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonerQTE : MonoBehaviour
{

    [SerializeField] string keyStrokeStart;
    [SerializeField] string keyStrokeFinish;
    [SerializeField] GameObject[] donerCopy;
    [SerializeField] FoodOnPlate foodOnPlate;
    private int DonerValue;
    public static bool donerCheck;
    HashSet<int> usedIndexes = new HashSet<int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        donerCheck = false;
        Debug.Log(donerCheck + "Doner check is working");
    }

    // Update is called once per frame
    void Update()
    {
        if (donerCheck) 
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Left Arrow is pressed");
                DonerValue += 1;
                if (DonerValue == 2)
                {
                    DonerAdder(0);
                }

                if (DonerValue == 4)
                {
                    DonerAdder(1);
                }

                if (DonerValue == 6)
                {
                    DonerAdder(2);
                }
            }
        }
    }

    void OnEnable()
    {
        EventManager.OnDonerEnter += DonerMinigameEnter;
        EventManager.OnDonerExit += DonerMinigameExit;
        EventManager.OnPlateServed += ResetDonerCounter;
        EventManager.OnFoodTrashed += ResetDonerCounter;
    }

    private void OnDisable()
    {
        EventManager.OnDonerEnter -= DonerMinigameEnter;
        EventManager.OnDonerExit -= DonerMinigameExit;
        EventManager.OnPlateServed -= ResetDonerCounter;
        EventManager.OnFoodTrashed -= ResetDonerCounter;
    }

    void DonerMinigameEnter()
    {
        donerCheck = true;
    }


    void ResetDonerCounter()
    {
        DonerValue = 0;
        usedIndexes.Clear();
    }

    void DonerMinigameExit()
    {
        if (DonerValue/2 <2)
        {
            Debug.Log("Doner is not done");
        }
        else
        {
            Debug.Log("Doner is done");
        }
        Debug.Log("plate value after doner is " + gameFlow.plateValue);
        donerCheck = false;
    }

    void DonerAdder(int donerIndex)
    {
        string doner = "";

        if (gameFlow.donerList.Count != 0)
            gameFlow.donerList.Clear();
        
        switch (donerIndex)
        {
            case 0:
                doner = "az_doner";
                break;
            case 1:
                doner = "orta_doner";
                break;
            case 2:
                doner = "cok_doner";
                break;
        }

        gameFlow.donerList.Add(doner);
        DonerInstantiator();
    }

    void DonerInstantiator()
    {
        int index;
        for (int i = 0; i < UnityEngine.Random.Range(2,3); i++)
        {
            if (usedIndexes.Count == donerCopy.Length)
            {
                usedIndexes.Clear(); // Reset the used indexes if all have been used
                Debug.Log("All indexes have been used, resetting.");
            }

            do
            {
                index = UnityEngine.Random.Range(0, donerCopy.Length);
            } while (usedIndexes.Contains(index)); // Ensure no duplicates

            usedIndexes.Add(index);

            foodOnPlate.PutFoodOnPlate(donerCopy[index], (gameFlow.xPosOfPlate + UnityEngine.Random.Range(-0.5f, 0.5f)), gameFlow.yPosOfPlate); //ortalý olacak þekilde düþün
        }
    }
}
