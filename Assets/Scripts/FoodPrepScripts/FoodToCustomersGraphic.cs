using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class FoodToCustomersGraphic : MonoBehaviour
{
    [SerializeField] GameObject[] carbOnPuzzleScene;
    [SerializeField] GameObject[] toppingOnPuzzleScene;
    [SerializeField] GameObject[] spiceOnPuzzleScene;
    [SerializeField] GameObject[] sauceOnPuzzleScene;
    [SerializeField] GameObject[] donerOnPuzzleScene;
    List<GameObject> copiedObjects = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        OrderManagerPuzzle.OnFoodSent += FoodShowLogic;
        OrderManagerPuzzle.OnCustomerDeleted += FoodDestroyer;
    }

    private void OnDisable()
    {
        OrderManagerPuzzle.OnFoodSent -= FoodShowLogic;
        OrderManagerPuzzle.OnCustomerDeleted -= FoodDestroyer;

    }

    void FoodShowLogic()
    {
        FoodListComparetor(carbOnPuzzleScene, gameFlow.carbList);
        FoodListComparetor(toppingOnPuzzleScene, gameFlow.toppingList);
        FoodListComparetor(spiceOnPuzzleScene, gameFlow.spiceList);
        FoodListComparetor(sauceOnPuzzleScene, gameFlow.sauceList);
        FoodListComparetor(donerOnPuzzleScene, gameFlow.donerList);
    }

    void ShowFoodToCustomer(GameObject cloneObj, float xPos, float yPos, int i)
    {
        GameObject copyClone = Instantiate(cloneObj, new Vector2(xPos, yPos), Quaternion.identity);
        copyClone.GetComponent<SpriteRenderer>().sortingOrder = 6 + i;
        copiedObjects.Add(copyClone);
    }

    void FoodListComparetor(GameObject[] foodType, List<string> staticFoodType)
    {
        for (int i = 0; i < foodType.Length; i++)
        {
            if (staticFoodType.Contains(foodType[i].name))
            {
                ShowFoodToCustomer(foodType[i], -30, -4 , i);
            }
        }

    }

    void FoodDestroyer()
    {
        foreach (GameObject copyClone in copiedObjects) //listedeki her copyClone için copyClone silinir, yani tabaktaki
                                                                    //her þey silinir
        {
            Destroy(copyClone);
        }
    }

}
