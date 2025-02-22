using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class ServeOrDelete : MonoBehaviour// old version of serveordelete, the one on the first demo
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    OrderViewLogic orderDeleter;
    ScrappyPoints scrappyPoints;
    bool correctCheck;
    void Start()
    {
        orderDeleter = GetComponent<OrderViewLogic>();
        scrappyPoints = GetComponent<ScrappyPoints>();

    }

    // Update is called once per frame
    void Update() 
    {
        
    }
    /*
    void OnEnable()
    {
        EventManager.OnPlateServed += PlateServeChecker;
    }

    void OnDisable()
    {
        EventManager.OnPlateServed -= PlateServeChecker;
    }
    */
    /*
    void PlateServeChecker()
    {

        Debug.Log("totalPlayerList count after clearing: " + gameFlow.totalPlayerList.Count);

        gameFlow.totalPlayerList.AddRange(gameFlow.carbList);
        gameFlow.totalPlayerList.AddRange(gameFlow.toppingList);
        gameFlow.totalPlayerList.AddRange(gameFlow.spiceList);
        gameFlow.totalPlayerList.AddRange(gameFlow.sauceList);

        for (int i = 0; i < gameFlow.activeOrder; i++)
        {
            Debug.Log("order counter count: " + gameFlow.activeOrder);
            Debug.Log("on iteration: " + i);
            if (OrderChecker(gameFlow.orderCounter[i], gameFlow.totalPlayerList))
            {
                Debug.Log("doðru order");
                foreach (GameObject copyClone in FoodOnPlate.copiedObjects) //listedeki her copyClone için copyClone silinir, yani tabaktaki
                                                                            //her þey silinir
                {
                    Destroy(copyClone);
                }
                FoodOnPlate.copiedObjects.Clear(); //liste temizlenir
                gameFlow.orderCounter.RemoveAt(i);
                gameFlow.totalPlayerList.Clear();
                gameFlow.carbList.Clear();
                gameFlow.toppingList.Clear();
                gameFlow.spiceList.Clear();
                gameFlow.sauceList.Clear();
                gameFlow.activeOrder--;
                int copyIndex = i;
                gameFlow.correctOrderIndex = copyIndex;
                orderDeleter.OrderDeleter();
                scrappyPoints.PointUp();
                correctCheck = true;
                Debug.Log("correct order is: " + gameFlow.correctOrderIndex);
                break;
            }
            else
            {
                Debug.Log("plate value does not match up with order value " + i);
                Debug.Log("yanlýþ order");
                

            }
        }

        foreach (GameObject copyClone in FoodOnPlate.copiedObjects)
        {
            Destroy(copyClone);
        }
        FoodOnPlate.copiedObjects.Clear();
        gameFlow.totalPlayerList.Clear();
        gameFlow.carbList.Clear();
        gameFlow.toppingList.Clear();
        gameFlow.spiceList.Clear();
        gameFlow.sauceList.Clear();
        if (!correctCheck)
        {
            scrappyPoints.PointDown();
        }
        correctCheck = false;


    }

    bool OrderChecker(List<string> orderList, List<string> playerList)
    {
        Debug.Log("Entered order checker");
        if (orderList.Count != playerList.Count)
        {
            Debug.Log("liste sayýlarý farklý");
            Debug.Log("order list count: " + orderList.Count);
            Debug.Log("player list count: " + playerList.Count);
            return false;
        }
        else
        {

            orderList.Sort();
            Debug.Log("order list after sort: " + orderList[0] + " " + orderList[1] + " " + orderList[2] + " " + orderList[3] + " " + orderList[4]);

            playerList.Sort();
            Debug.Log("player list after sort: " + playerList[0] + " " + playerList[1] + " " + playerList[2] + " " + playerList[3] + " " + playerList[4]);


            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i] != playerList[i])
                {
                    return false;

                }
            }
            return true;
        }
    }
    */
}
