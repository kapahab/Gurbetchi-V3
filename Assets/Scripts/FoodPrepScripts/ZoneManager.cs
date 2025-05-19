using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class ZoneManager : MonoBehaviour
{
    public int moveIndex = 11;
    ZonePicker zonePicker;
    [SerializeField] int maxIndexTens, maxIndexOnes;
    public bool inThisZone = false;
    bool spritesDarkened = true;
    bool lastZoneState = false;
    [SerializeField] GameObject[] foodInZone;
    List<FoodInZoneIndices> foodInZoneIndices = new List<FoodInZoneIndices>();

    int previousMoveIndex = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zonePicker = GetComponent<ZonePicker>();
        for (int i = 0; i < foodInZone.Length; i++)
        {
            if (foodInZone[i] == null)
                continue;
            if (foodInZone[i].GetComponent<FoodInZoneIndices>() == null)
                continue;
            foodInZoneIndices.Add(foodInZone[i].GetComponent<FoodInZoneIndices>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameFlow.gameActive) return;
        if (!gameFlow.screenSwitch) return;

        inThisZone = zonePicker.isThisZoneActive;

        if (ZonePicker.currentActiveZone == null)
            UndarkenSprites();
        else if (ZonePicker.currentActiveZone != null && ZonePicker.currentActiveZone != zonePicker)
            DarkenSprites();
        else if (ZonePicker.currentActiveZone != null && ZonePicker.currentActiveZone == zonePicker)
            UndarkenSprites();

        if (!inThisZone)
            return;
        Move();
        CheckForCarb();
    }

    void Move()
    {
        previousMoveIndex = moveIndex;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            moveIndex = GetMoveIndex(moveIndex - 10);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            moveIndex = GetMoveIndex(moveIndex + 10);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            moveIndex = GetMoveIndex(moveIndex - 1);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            moveIndex = GetMoveIndex(moveIndex + 1);
    }

    void CheckForCarb()
    {
        if (!zonePicker.isThisCarbZone)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
            gameFlow.isCarbOnTable = true;
    }

    int GetMoveIndex(int moveIndexToBe)
    {
        int correctedMoveIndex = moveIndexToBe;

        if (moveIndexToBe % 10 > maxIndexOnes)
            correctedMoveIndex = (moveIndex - (moveIndex %10)) + 1;
        if (moveIndexToBe % 10 < 1)
            correctedMoveIndex = (moveIndex - (moveIndex % 10)) + maxIndexOnes;
        if (moveIndexToBe / 10 > maxIndexTens / 10)
            correctedMoveIndex = (moveIndex % 10)+10;
        if (moveIndexToBe / 10 < 1)
            correctedMoveIndex = (moveIndex % 10) + maxIndexTens;

        int blockedIndex;
        if (CheckIfFoodIsUsed(correctedMoveIndex, out blockedIndex))
            return BlockedIngredientMove(foodInZoneIndices[blockedIndex]);

        //for (int i = 0; i < foodInZoneIndices.Count; i++)
        //{
        //    if (correctedMoveIndex == foodInZoneIndices[i].moveIndex && foodInZoneIndices[i].isIngredientAdded)
        //        return BlockedIngredientMove(foodInZoneIndices[i]);
        //}

        return correctedMoveIndex;
    }




    int BlockedIngredientMove(FoodInZoneIndices food)
    {
        int blockedIndex = food.moveIndex;
        int resultTens;
        int resultOnes;
        int resultingIndex;
        //do
        //{
        int blockedIndexTens = blockedIndex / 10;
        int blockedIndexOnes = blockedIndex % 10;

        resultTens = blockedIndexTens;
        resultOnes = blockedIndexOnes;

        if (moveIndex / 10 - blockedIndex / 10 == 0)//change in the ones
        {
            Debug.Log("change in ones");
            if (blockedIndexOnes == maxIndexOnes) //if the blocked index is the last one
            {
                if (blockedIndexTens == maxIndexTens)
                    resultOnes = 1;
                else
                {
                    resultOnes = 1;
                    resultTens = blockedIndexTens + 1;
                }
            }
            else if (blockedIndexOnes == 1) //if the blocked index is the first one
            {
                if (blockedIndexTens == 1)
                    resultOnes = 1;
                else
                {
                    resultOnes = maxIndexOnes;
                    resultTens = blockedIndexTens - 1;
                }
            }
            else if ((moveIndex % 10) - blockedIndexOnes < 0) //if the move index is less than the blocked index
                resultOnes = blockedIndexOnes + 1;
            else
                resultOnes = blockedIndexOnes - 1;
        }
        else
        {
            resultOnes = blockedIndexOnes;
        }

        if (moveIndex % 10 - blockedIndex % 10 == 0)//change in the tens
        {
            Debug.Log("change in tens");
            if (blockedIndexTens == maxIndexTens / 10)
            {
                resultTens = 1;
                Debug.Log("max index tens");
            }
            else if (blockedIndexTens == 1)
            {
                resultTens = maxIndexTens / 10;
                Debug.Log("min index tens");
            }
            else if ((moveIndex / 10) - blockedIndexTens < 0)
            {
                resultTens = blockedIndexTens + 1;
                Debug.Log("move index tens < blocked index tens");
                Debug.Log(blockedIndexTens + "blocked index");
                Debug.Log(maxIndexTens + "max tens");
            }
            else
            {
                resultTens = blockedIndexTens - 1;
                Debug.Log("move index tens > blocked index tens");
            }
        }
        else
        {
            resultTens = blockedIndexTens;
        }

        resultingIndex = (resultTens * 10) + resultOnes;
        //}
        //while (CheckIfFoodIsUsed(resultingIndex, out blockedIndex));

        return (resultTens * 10) + resultOnes;
    }


    bool CheckIfFoodIsUsed(int moveIndex, out int index)
    {
       

        for (int i = 0; i < foodInZoneIndices.Count; i++)
        {
            if ((moveIndex == foodInZoneIndices[i].moveIndex && foodInZoneIndices[i].isIngredientAdded))
            {
                index = i;
                return true;
            }

        }
        index = -1;
        return false;
    }

    void DarkenSprites()
    {
        if (spritesDarkened)
            return;
        foreach (GameObject food in foodInZone)
        {
            SpriteRenderer spriteRenderer = food.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color = new Color(0.5f, 0.5f, 0.5f); // Set the alpha value to 0.5 for darkening
                spriteRenderer.color = color;
            }
        }
        spritesDarkened = true;
    }

    void UndarkenSprites()
    {
        if (!spritesDarkened)
            return;
        foreach (GameObject food in foodInZone)
        {
            if (food.GetComponent<FoodInZoneIndices>()!= null)
                if (food.GetComponent<FoodInZoneIndices>().isIngredientAdded)
                    continue;
            SpriteRenderer spriteRenderer = food.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color = new Color(1f, 1f, 1f); // Set the alpha value to 1 for undarkening
                spriteRenderer.color = color;
            }
        }
        spritesDarkened = false;
    }

}
