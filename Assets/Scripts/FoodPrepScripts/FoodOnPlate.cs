using System.Collections.Generic;
using UnityEngine;

public class FoodOnPlate : MonoBehaviour
{
    public List<GameObject> copiedObjects = new List<GameObject>();
    int layerOrder = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  PutFoodOnPlate(GameObject cloneObj, float xPos, float yPos)
    {
        GameObject copyClone = Instantiate(cloneObj, new Vector2(xPos, yPos), Quaternion.identity);
        copyClone.GetComponent<SpriteRenderer>().sortingOrder = layerOrder;
        layerOrder++;
        copiedObjects.Add(copyClone); // burada ileride silinmek için tabaða gelen objeler listeye eklenir
        Debug.Log("Number of ingredients chosen: " + copiedObjects.Count);
    }

    void ResetLayerOrder()
    {
        layerOrder = 0;
    }

    private void OnEnable()
    {
        EventManager.OnPlateServed += ResetLayerOrder;
    }

    private void OnDisable()
    {
        EventManager.OnPlateServed -= ResetLayerOrder;
    }
}
