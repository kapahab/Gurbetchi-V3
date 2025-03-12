using JetBrains.Annotations;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class OrderMaker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    List<string> orderCarbList = new List<string> { "ekmek", "gobit", "lavas" };
    List<string> orderToppingList = new List<string> { "domates", "morLahana", "lahana", "sogan", "patates" };
    List<string> orderSpiceList = new List<string> { "tuz", "pulbiber" };
    List<string> orderSauceList = new List<string> { "kırmızı", "beyaz" };
    List<string> orderDonerList = new List<string> { "az_doner", "orta_doner", "cok_doner" };
    public List<string> totalOrderList = new List<string>();

    int carbValue;
    int toppingValue1;
    int toppingValue2;
    int toppingValue3;
    int spiceValue;
    int sauceValue;
    int donerValue;
    List<int> toppingIndexes = new List<int>();
    public List<int> correctOrders = new List<int>();

    public List<int> amountOfIngredients = new List<int>();
    int amountOfCarb;
    int amountOfTopping;
    int amountOfSpice;
    int amountOfSauce;
    int amountOfDoner;

    public List<int> correctCarbIndex = new List<int>();
    public List<int> correctToppingIndex = new List<int>();
    public List<int> correctSpiceIndex = new List<int>();
    public List<int> correctSauceIndex = new List<int>();
    public List<int> correctDonerIndex = new List<int>();


    void Start()
    {

        //aralarından rastgele seçilecek olan listeler, her kategoriden farklı miktarlarda alınabilsin diye ayrılmışlardır.
        //ileride bu listeyi daha ayarlanabilir yap ve bu classtan çıkar
        orderCarbList = new List<string> { "ekmek", "gobit", "lavas" };
        orderToppingList = new List<string> { "domates", "morLahana", "lahana", "sogan", "patates" };
        orderSpiceList = new List<string> { "tuz", "pulbiber" };
        orderSauceList = new List<string> { "kırmızı", "beyaz" };
        orderDonerList = new List<string> { "az_doner", "orta_doner", "cok_doner" };

        Debug.Log("order lists initiliazed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeOrder()
    {
        totalOrderList.Clear();// use total order list to send the order to serveordelete
        /*

        totalOrderList.Add(orderCarbList[carbValue = ValueMaker(orderCarbList)]);

        totalOrderList.Add(orderSpiceList[spiceValue = ValueMaker(orderSpiceList)]);

        totalOrderList.Add(orderSauceList[sauceValue = ValueMaker(orderSauceList)]);

        totalOrderList.Add(orderDonerList[donerValue = ValueMaker(orderDonerList)]);

        AddToppingsByDifficulty();

        correctOrders.Add(carbValue);
        correctOrders.Add(toppingIndexes[0]);
        correctOrders.Add(spiceValue);
        correctOrders.Add(sauceValue);
        correctOrders.Add(donerValue);


        Debug.Log("active order on order maker: " + gameFlow.activeOrder);
        Debug.Log("current total orders: " + gameFlow.orderCounter.Count);

        for (int i = 0; i < totalOrderList.Count; i++)
        {
            Debug.Log("list after " + i + " order randomly selected: " + totalOrderList[i]);
        }

        */
        GenericIngredientSelector(amountOfCarb = 1, orderCarbList, correctCarbIndex);
        GenericIngredientSelector(amountOfTopping = 3, orderToppingList, correctToppingIndex);
        GenericIngredientSelector(amountOfSpice = 1, orderSpiceList, correctSpiceIndex);
        GenericIngredientSelector(amountOfSauce = 2, orderSauceList, correctSauceIndex);
        GenericIngredientSelector(amountOfDoner = 1, orderDonerList, correctDonerIndex);
        PuzzleListMaker();/*
        for (int i = 0; i < totalOrderList.Count; i++)
        {
            Debug.Log("list after " + i + " order randomly selected: " + totalOrderList[i]);
            Debug.Log("correct orders: " + correctOrders[i]);
        }*/
    }




    void GenericIngredientSelector(int amount, List<string> type , List<int> correctTypeIndex) //eger correct ordersı düzgün bir sırayla return edebilirsem kullanılır ve generic edilir
    {
        HashSet<int> usedIndexes = new HashSet<int>();
        for (int i = 0; i < amount; i++)
        {
            int index;
            string stringValue;
            do
            {
                index = Random.Range(0, type.Count);
                stringValue = type[index];

            } while (usedIndexes.Contains(index) || totalOrderList.Contains(stringValue)); // Ensure no duplicates

            usedIndexes.Add(index);
            correctOrders.Add(index);
            totalOrderList.Add(stringValue);
            correctTypeIndex.Add(index);
        }
        new List<int>(usedIndexes); // add to total order list in MakeOrder to ensure the total order list has correct placement

    }

    void PuzzleListMaker()
    {
        for (int i = 0; i < amountOfCarb; i++)
        {
            amountOfIngredients.Add(0);
        }

        for (int i = 0; i < amountOfTopping; i++)
        {
            amountOfIngredients.Add(1);
        }

        for (int i = 0; i < amountOfSpice; i++)
        {
            amountOfIngredients.Add(2);
        }

        for (int i = 0; i < amountOfSauce; i++)
        {
            amountOfIngredients.Add(3);
        }

        for (int i = 0; i < amountOfDoner; i++)
        {
            amountOfIngredients.Add(4);
        }
    }
}
