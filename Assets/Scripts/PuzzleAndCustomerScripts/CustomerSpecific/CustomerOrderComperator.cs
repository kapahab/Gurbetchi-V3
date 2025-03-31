using System.Collections.Generic;
using UnityEngine;

public class CustomerOrderComperator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CombineList()
    {
        ListCombiner(gameFlow.carbList);
        ListCombiner(gameFlow.toppingList);
        ListCombiner(gameFlow.spiceList);
        ListCombiner(gameFlow.sauceList);
        ListCombiner(gameFlow.donerList);

    }

    public void ListCombiner(List<string> foodLists)
    {
        if (foodLists.Count > 0)
            for (int i = 0; i < foodLists.Count; i++)
                gameFlow.totalPlayerList.Add(foodLists[i]);
    }

    public bool OrderChecker(List<string> orderList, List<string> playerList)
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
            playerList.Sort();
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i] != playerList[i])
                {
                    Debug.Log("Order is incorrect");
                    return false;

                }
            }
            Debug.Log("Order is correct");
            return true;
        }
    }
}
