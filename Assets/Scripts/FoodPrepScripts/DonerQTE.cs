using System.Collections;
using UnityEngine;

public class DonerQTE : MonoBehaviour
{

    [SerializeField] string keyStrokeStart;
    [SerializeField] string keyStrokeFinish;
    [SerializeField] GameObject[] donerCopy;
    [SerializeField] FoodOnPlate foodOnPlate;
    private int DonerValue;
    public static bool donerCheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        donerCheck = false;
        Debug.Log(donerCheck + "Doner check is working");
    }

    // Update is called once per frame
    void Update()
    {
        if (donerCheck) //&& ingredientChoose.diffInputIngredientCheck)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Left Arrow is pressed");
                DonerValue += 1;
                if (DonerValue == 2)
                {
                    gameFlow.donerList.Add("az_doner");
                    foodOnPlate.PutFoodOnPlate(donerCopy[0], gameFlow.xPosOfPlate, gameFlow.yPosOfPlate);
                }

                if (DonerValue == 4)
                {
                    gameFlow.donerList.Remove("az_doner");
                    gameFlow.donerList.Add("orta_doner");
                    foodOnPlate.PutFoodOnPlate(donerCopy[1], gameFlow.xPosOfPlate, gameFlow.yPosOfPlate);

                }

                if (DonerValue == 6)
                {
                    gameFlow.donerList.Remove("orta_doner");
                    gameFlow.donerList.Add("cok_doner");
                    foodOnPlate.PutFoodOnPlate(donerCopy[2], gameFlow.xPosOfPlate, gameFlow.yPosOfPlate);

                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Right Arrow is pressed");
                DonerValue += 1;
                if (DonerValue == 2)
                {
                    gameFlow.donerList.Add("az_doner");
                    foodOnPlate.PutFoodOnPlate(donerCopy[0], gameFlow.xPosOfPlate, gameFlow.yPosOfPlate);

                }

                if (DonerValue == 4)
                {
                    gameFlow.donerList.Remove("az_doner");
                    gameFlow.donerList.Add("orta_doner");
                    foodOnPlate.PutFoodOnPlate(donerCopy[1], gameFlow.xPosOfPlate, gameFlow.yPosOfPlate);

                }

                if (DonerValue == 6)
                {
                    gameFlow.donerList.Remove("orta_doner");
                    gameFlow.donerList.Add("cok_doner");
                    foodOnPlate.PutFoodOnPlate(donerCopy[2], gameFlow.xPosOfPlate, gameFlow.yPosOfPlate);

                }
            }

        }
    }

    void OnEnable()
    {
        EventManager.OnDonerEnter += DonerMinigameEnter;
        EventManager.OnDonerExit += DonerMinigameExit;
    }

    private void OnDisable()
    {
        EventManager.OnDonerEnter -= DonerMinigameEnter;
        EventManager.OnDonerExit -= DonerMinigameExit;

    }

    void DonerMinigameEnter()
    {
        donerCheck = true;
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
        DonerValue = 0;
    }

}
