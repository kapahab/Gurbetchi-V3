using System.Collections.Generic;
using UnityEngine;

public class FoodOnPlate : MonoBehaviour
{
    public static List<GameObject> copiedObjects = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void  PutFoodOnPlate(GameObject cloneObj, float xPos, float yPos)
    {
        GameObject copyClone = Instantiate(cloneObj, new Vector2(xPos, yPos), Quaternion.identity);
        copiedObjects.Add(copyClone); // burada ileride silinmek için tabaða gelen objeler listeye eklenir
        Debug.Log("Number of ingredients chosen: " + copiedObjects.Count);
    }
}
