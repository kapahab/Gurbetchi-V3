using System.Collections.Generic;
using UnityEngine;

public class CorrectOrderSpawnerRecipt : MonoBehaviour
{
    [SerializeField] int index;
    ReciptManager reciptManager;
    [SerializeField] GameObject[] correctCarb;
    [SerializeField] GameObject[] correctTopping;
    [SerializeField] GameObject[] correctSpice;
    [SerializeField] GameObject[] correctSauce;
    [SerializeField] GameObject[] correctDoner;
    List<GameObject> instantiatedObjects = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void InstantiateCorrectOrders(OrderMaker orderMaker)
    {
        PuzzleResultInstantiator(correctCarb, orderMaker.correctCarbIndex);
        PuzzleResultInstantiator(correctTopping, orderMaker.correctToppingIndex);
        PuzzleResultInstantiator(correctSpice, orderMaker.correctSpiceIndex);
        PuzzleResultInstantiator(correctSauce, orderMaker.correctSauceIndex);
        PuzzleResultInstantiator(correctDoner, orderMaker.correctDonerIndex);
    }

    void PuzzleResultInstantiator(GameObject[] toBeInstantiated, List<int> indexList)
    {
        for (int i = 0; i < indexList.Count; i++)
        {
            GameObject clone = Instantiate(toBeInstantiated[indexList[i]], this.transform);
            instantiatedObjects.Add(clone);
        }
    }

    public void DestroyInstances()
    {
        foreach (GameObject copyClone in instantiatedObjects) //listedeki her copyClone için copyClone silinir, yani tabaktaki
                                                        //her þey silinir
        {
            Destroy(copyClone);
        }
        instantiatedObjects.Clear();
    }

    public float CalculateDeltaY()
    {
        Debug.Log("Delta Y: " + this.transform.GetComponent<RectTransform>().sizeDelta.y);
        return this.transform.GetComponent<RectTransform>().sizeDelta.y;
    }

}
