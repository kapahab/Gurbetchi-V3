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
        if (gameFlow.plateValue == 0) //bu kýsýmda yemek kategorisi incelenir, ilk kategoriden bir yemek seçilmediyse diðerleri seçilemez
        {
            if (ingredientName > 3) // ya da birler kategorisindeki en yüksek deðer
            {
                spriteRenderer.material.color = Color.gray;
                keyStroke = "*"; // bu haliyle GetKeyDown error veriyor, belki çok saçma bir harf vermek daha mantýklý olabilir
                diffInputIngredientCheck = false;
            }
            else
            {
                spriteRenderer.material.color = Color.white;
                keyStroke = storedKeyStroke;
            }

        }
        else // burada ilk kategoriden bir þey seçildiyse diðer seçenekleri açar ve ilk kategoriyi kapatýr
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
            gameFlow.plateValue += ingredientName; // bu kýsýmdan sonrasý get key up ile yapýlabilir(animasyonlar geldikten sonra)
            GameObject copyClone = Instantiate(cloneObj, new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log("Ingredient " + ingredientName + " is chosen");
            Debug.Log("Plate value is " + gameFlow.plateValue);
            copiedObjects.Add(copyClone); // burada ileride silinmek için tabaða gelen objeler listeye eklenir
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

                if (ingredientListType == "carbList") // her kategoriye bakýp ayrý listelere eklemek gereksiz olabilir çünkü sonuçta hepsi ayný listeye gidiyor
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
