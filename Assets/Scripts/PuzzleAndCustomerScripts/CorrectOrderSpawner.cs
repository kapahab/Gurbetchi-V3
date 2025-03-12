using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class CorrectOrderSpawner : MonoBehaviour
{
    OrderMaker orderMaker;
    [SerializeField] GameObject[] correctCarb;
    [SerializeField] GameObject[] correctTopping;
    [SerializeField] GameObject[] correctSpice;
    [SerializeField] GameObject[] correctSauce;
    [SerializeField] GameObject[] correctDoner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orderMaker = GetComponentInParent<OrderMaker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void InstantiateCorrectOrders()
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
            Instantiate(toBeInstantiated[indexList[i]], this.transform);
        }

    }
}
