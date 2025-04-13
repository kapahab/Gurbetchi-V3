using UnityEngine;
using System.Collections.Generic;

public class ingredientChoose : MonoBehaviour
{
    [SerializeField] string ingredientName;
    [SerializeField] string ingredientListType;
    [SerializeField] string keyStroke;
    public GameObject cloneObj;
    [SerializeField] private Renderer spriteRenderer;
    private string storedKeyStroke;
    private bool activateRegularInput = false;
    [SerializeField] FoodOnPlate foodOnPlate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        storedKeyStroke = keyStroke;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        EventManager.OnRegularInput += ActivateRegularInput;
        EventManager.OnCarbInput += ActivateRegularInput;

    }

    void OnDisable()
    {
        EventManager.OnRegularInput -= ActivateRegularInput;
        EventManager.OnCarbInput -= ActivateRegularInput;
    }
    void ActivateRegularInput()
    {
        if (DonerQTE.donerCheck == false) {

            if (Input.GetKeyDown(keyStroke))
            {

                if (ingredientListType == "carbList") // her kategoriye bak�p ayr� listelere eklemek gereksiz olabilir ��nk� sonu�ta hepsi ayn� listeye gidiyor
                    gameFlow.carbList.Add(ingredientName);
                else if (ingredientListType == "toppingList")
                    gameFlow.toppingList.Add(ingredientName);
                else if (ingredientListType == "spiceList")
                    gameFlow.spiceList.Add(ingredientName);
                else if (ingredientListType == "sauceList")
                    gameFlow.sauceList.Add(ingredientName);
                Debug.Log("Ingredient " + ingredientName + " is chosen");

                foodOnPlate.PutFoodOnPlate(cloneObj, gameFlow.xPosOfPlate, gameFlow.yPosOfPlate);
            }

        }
        
            
    }
}
