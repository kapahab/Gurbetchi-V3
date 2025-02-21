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




    }

    private void AddToppingsByDifficulty()
    {
        int difficulty = 0; // Assumes gameDifficulty exists in gameFlow
        HashSet<int> usedIndexes = new HashSet<int>();
        int toppingCount = difficulty + 1; // Example logic: 1 topping for easy, 2 for medium, 3 for hard
        for (int i = 0; i < toppingCount; i++)
        {
            int toppingIndex;
            do
            {
                toppingIndex = Random.Range(0, orderToppingList.Count);
            } while (usedIndexes.Contains(toppingIndex)); // Ensure no duplicates

            usedIndexes.Add(toppingIndex);
            totalOrderList.Add(orderToppingList[toppingIndex]);
        }


        for (int i = 0; i < new List<int>(usedIndexes).Count; i++)
        {
            Debug.Log("Topping " + i + ": " + orderToppingList[new List<int>(usedIndexes)[i]]);
        }

        List <int> CopyIndexes = new List<int>(usedIndexes);
        toppingIndexes = CopyIndexes;


    }

    private int ValueMaker(List<string> list)
    {
        return Random.Range(0, list.Count);
    }
}
