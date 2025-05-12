using UnityEngine;

public class FoodInZoneIndices : MonoBehaviour
{
    [SerializeField] int moveIndex;
    [SerializeField]ZoneManager zoneManager;
    [SerializeField] GameObject highlightedObj;
    bool thisFoodSelected = false;
    [SerializeField] FoodOnPlate foodOnPlate;

    [SerializeField] string ingredientName;
    [SerializeField] string ingredientListType;
    public GameObject cloneObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highlightedObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!zoneManager.inThisZone)
        {
            DeactivateAll();
            return;
        }
        Activate();
        Deactivate();
        AddFood();
    }


    void Activate()
    {
        if (moveIndex == zoneManager.moveIndex)
        {
            highlightedObj.SetActive(true);
            thisFoodSelected = true;
        } 
    }

    void Deactivate()
    {
        if (moveIndex != zoneManager.moveIndex)
        {
            highlightedObj.SetActive(false);
            thisFoodSelected = false;
        }
    }

    void DeactivateAll()
    {
        highlightedObj.SetActive(false);
    }

    void AddFood()
    {
        if (!thisFoodSelected)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foodOnPlate.PutFoodOnPlate(cloneObj, gameFlow.xPosOfPlate, gameFlow.yPosOfPlate);
            if (ingredientListType == "carbList") // her kategoriye bak�p ayr� listelere eklemek gereksiz olabilir ��nk� sonu�ta hepsi ayn� listeye gidiyor
                gameFlow.carbList.Add(ingredientName);
            else if (ingredientListType == "toppingList")
                gameFlow.toppingList.Add(ingredientName);
            else if (ingredientListType == "spiceList")
                gameFlow.spiceList.Add(ingredientName);
            else if (ingredientListType == "sauceList")
                gameFlow.sauceList.Add(ingredientName);
            Debug.Log("Ingredient " + ingredientName + " is chosen");
        }
        
    }

}
