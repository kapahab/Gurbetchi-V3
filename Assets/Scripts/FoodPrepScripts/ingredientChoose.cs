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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        storedKeyStroke = keyStroke;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (gameFlow.plateValue == 0) //bu k�s�mda yemek kategorisi incelenir, ilk kategoriden bir yemek se�ilmediyse di�erleri se�ilemez
        {
            if (ingredientName > 3) // ya da birler kategorisindeki en y�ksek de�er
            {
                spriteRenderer.material.color = Color.gray;
                keyStroke = "*"; // bu haliyle GetKeyDown error veriyor, belki �ok sa�ma bir harf vermek daha mant�kl� olabilir
                diffInputIngredientCheck = false;
            }
            else
            {
                spriteRenderer.material.color = Color.white;
                keyStroke = storedKeyStroke;
            }

        }
        else // burada ilk kategoriden bir �ey se�ildiyse di�er se�enekleri a�ar ve ilk kategoriyi kapat�r
        {
            if (ingredientName > 3)
            {
                keyStroke = storedKeyStroke;
                spriteRenderer.material.color = Color.white;
                diffInputIngredientCheck = true;

            }
            else
            {
                spriteRenderer.material.color = Color.gray;
                keyStroke = "*";
            }

        }
        */
        /*if (Input.GetKeyDown(keyStroke))
        {
            gameFlow.plateValue += ingredientName; // bu k�s�mdan sonras� get key up ile yap�labilir(animasyonlar geldikten sonra)
            GameObject copyClone = Instantiate(cloneObj, new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log("Ingredient " + ingredientName + " is chosen");
            Debug.Log("Plate value is " + gameFlow.plateValue);
            copiedObjects.Add(copyClone); // burada ileride silinmek i�in taba�a gelen objeler listeye eklenir
            Debug.Log("Number of ingredients chosen: " + copiedObjects.Count);
            Debug.Log("Ingredients list: " + copiedObjects);
        }*/
    }

    void OnEnable()
    {
        EventManager.OnRegularInput += ActivateRegularInput;
    }

    void OnDisable()
    {
        EventManager.OnRegularInput -= ActivateRegularInput;
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

                FoodOnPlate.PutFoodOnPlate(cloneObj, gameFlow.xPosOfPlate, gameFlow.yPosOfPlate);
            }

        }
        
            
    }
}
