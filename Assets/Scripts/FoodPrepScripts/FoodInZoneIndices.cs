using Unity.VisualScripting;
using UnityEngine;

public class FoodInZoneIndices : MonoBehaviour
{
    public int moveIndex;
    [SerializeField]ZoneManager zoneManager;
    [SerializeField] GameObject highlightedObj;
    bool thisFoodSelected = false;
    [SerializeField] FoodOnPlate foodOnPlate;

    [SerializeField] string ingredientName;
    [SerializeField] string ingredientListType;
    public GameObject cloneObj;

    public bool isIngredientAdded = false;
    SpriteRenderer[] renderers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highlightedObj.SetActive(false);
        renderers = GetComponentsInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!gameFlow.gameActive) return;
        if (!gameFlow.screenSwitch) return;

        if (!zoneManager.inThisZone)
        {
            DeactivateAll();
            return;
        }
        Activate();
        Deactivate();
        AddFood();
        Disable();
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
            if (ingredientListType == "carbList") // her kategoriye bakýp ayrý listelere eklemek gereksiz olabilir çünkü sonuçta hepsi ayný listeye gidiyor
                gameFlow.carbList.Add(ingredientName);
            else if (ingredientListType == "toppingList")
                gameFlow.toppingList.Add(ingredientName);
            else if (ingredientListType == "spiceList")
                gameFlow.spiceList.Add(ingredientName);
            else if (ingredientListType == "sauceList")
                gameFlow.sauceList.Add(ingredientName);
            Debug.Log("Ingredient " + ingredientName + " is chosen");
            isIngredientAdded = true;
        }
    }

    void Disable()
    {
        if (!isIngredientAdded)
            return;
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }


    void ReEnable()
    {
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.color = new Color(1, 1, 1);
        }
        isIngredientAdded = true;
    }

    private void OnEnable()
    {
        EventManager.OnResetFoodMaking += ReEnable;
        EventManager.OnPlateServed += ReEnable;
        EventManager.OnFoodTrashed += ReEnable;
    }
    private void OnDisable()
    {
        EventManager.OnResetFoodMaking -= ReEnable;
        EventManager.OnPlateServed -= ReEnable;
        EventManager.OnFoodTrashed -= ReEnable;
    }
}
