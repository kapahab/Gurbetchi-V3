using UnityEngine;

public class TrashFood : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TrashMechanics()
    {
        gameFlow.carbList.Clear();
        gameFlow.toppingList.Clear();
        gameFlow.spiceList.Clear();
        gameFlow.sauceList.Clear();
        gameFlow.donerList.Clear();

        gameFlow.totalPoints -= 100;

    }

    private void OnEnable()
    {
        EventManager.OnFoodTrashed += TrashMechanics;
    }

    private void OnDisable()
    {
        EventManager.OnFoodTrashed -= TrashMechanics;
    }
}
