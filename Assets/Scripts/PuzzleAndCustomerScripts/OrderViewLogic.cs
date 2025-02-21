using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderViewLogic : MonoBehaviour
{
    OrderGraphRemover removeOrder;
    OrderGraphicsV2 newOrderGraphics;
    int orderIndex = 0;


    [SerializeField] SpriteRenderer[] order1Line;
    [SerializeField] SpriteRenderer[] order2Line;
    [SerializeField] SpriteRenderer[] order3Line;
    private List<SpriteRenderer[]> spriteRenderers = new List<SpriteRenderer[]>();

    private List<int> currentCarbValue = new List<int>();
    private List<int> currentSpiceValue = new List<int>();
    private List<int> currentSauceValue = new List<int>();
    private List<int> currentDonerValue = new List<int>();
    private List<List<int>> currentToppingIndexes = new List<List<int>>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        removeOrder = GetComponent<OrderGraphRemover>();
        newOrderGraphics = GetComponent<OrderGraphicsV2>();
        spriteRenderers.Add(order1Line);
        spriteRenderers.Add(order2Line);
        spriteRenderers.Add(order3Line);
    }

    // Update is called once per frame
    void Update()
    {
      
       
            
    }

    public void MakeOrderGraphic(int carbValue, int spiceValue, int sauceValue, int donerValue, List<int> toppingIndexes)
    {

        currentCarbValue.Add(carbValue);
        currentSpiceValue.Add(spiceValue);
        currentSauceValue.Add(sauceValue);
        currentDonerValue.Add(donerValue);
        currentToppingIndexes.Add(toppingIndexes);

        switch (gameFlow.activeOrder)
        {
            case 0:
                newOrderGraphics.OrderGraphPreSet(carbValue, spiceValue, sauceValue, donerValue, toppingIndexes, order1Line);
                break;

            case 1:
                newOrderGraphics.OrderGraphPreSet(carbValue, spiceValue, sauceValue, donerValue, toppingIndexes, order2Line);
                break;
            case 2:
                newOrderGraphics.OrderGraphPreSet(carbValue, spiceValue, sauceValue, donerValue, toppingIndexes, order3Line);
                break;
        }


    }

    public void OrderDeleter()
    {
        currentCarbValue.RemoveAt(gameFlow.correctOrderIndex);
        currentSpiceValue.RemoveAt(gameFlow.correctOrderIndex);
        currentSauceValue.RemoveAt(gameFlow.correctOrderIndex);
        currentDonerValue.RemoveAt(gameFlow.correctOrderIndex);
        currentToppingIndexes.RemoveAt(gameFlow.correctOrderIndex);

        switch (gameFlow.correctOrderIndex)
        {
            case 0:
                removeOrder.RemoveLine(gameFlow.gameDifficulty + 5, order1Line);
                break;

            case 1:
                removeOrder.RemoveLine(gameFlow.gameDifficulty + 5, order2Line);
                break;
            case 2:
                removeOrder.RemoveLine(gameFlow.gameDifficulty + 5, order3Line);
                break;
        }
        if (gameFlow.correctOrderIndex - gameFlow.activeOrder < 0)
        {
            for (int i = 2; i > gameFlow.correctOrderIndex; i--)
            {
                Debug.Log("lines that will be cleared after correct order: " + i);
                removeOrder.RemoveLine(gameFlow.gameDifficulty + 5, spriteRenderers[i]);
            }
            for (int y =0; y < gameFlow.activeOrder; y++)
            {
                Debug.Log("lines that will be created after correct order: " + y);
                newOrderGraphics.OrderGraphPreSet(currentCarbValue[y], currentSpiceValue[y], currentSauceValue[y], currentDonerValue[y], currentToppingIndexes[y], spriteRenderers[y]);
            }
        }
        
        /*if there are any other orders down
            for however many orders
                using current lists generate from top to bottom */
    }
}
