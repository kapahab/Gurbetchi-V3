using UnityEngine;

public class BreadChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool carbGraphicsActivated = true;
    bool carbGraphicsNeedChange = false;
    bool lastCarbGraphicsState = false;
    [SerializeField] GameObject[] nonCarbObjects;
    [SerializeField] GameObject[] carbObjects;
    void Start()
    {
        carbGraphicsActivated = true;
        ShowCarb();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameFlow.isCarbOnTable == lastCarbGraphicsState)
        {
            lastCarbGraphicsState = gameFlow.isCarbOnTable;
            return;
        }

        if (gameFlow.isCarbOnTable)
            HideCarb();
        else
            ShowCarb();



        lastCarbGraphicsState = gameFlow.isCarbOnTable;
    }

    void ShowCarb()
    {
        ObjectColorChange(nonCarbObjects, 0.5f);
        ObjectColorChange(carbObjects, 1f);
    }
    void HideCarb()
    {
        ObjectColorChange(nonCarbObjects, 1f);
        ObjectColorChange(carbObjects, 0.5f);
    }

    void BreadCheckResetter()
    {
        gameFlow.isCarbOnTable = false;
    }


    private void OnEnable()
    {
        EventManager.OnResetFoodMaking += BreadCheckResetter;
    }

    private void OnDisable()
    {
        EventManager.OnResetFoodMaking -= BreadCheckResetter;
    }

    public void ObjectColorChange(GameObject[] inputObjects, float colorValue)
    {
        for (int i = 0; i < inputObjects.Length; i++)
        {
            inputObjects[i].GetComponent<SpriteRenderer>().material.color = new Color(colorValue, colorValue, colorValue);
        }
    }
}
