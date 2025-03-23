using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class gameFlow : MonoBehaviour
{
    public static int orderValue;
    public static int plateValue;
    public static List<string> carbList = new List<string>();
    public static List<string> toppingList = new List<string>();
    public static List<string> spiceList = new List<string>();
    public static List<string> sauceList = new List<string>();
    public static List<string> donerList = new List<string>();
    public static List<string> totalPlayerList = new List<string>();
    public static List<string> orderList;
    [SerializeField] private List<string> allKeyBindings = new List<string>();
    public static List<string> allKeyBindingsUsed;
    public static float xPosOfPlate = 0f;
    public static float yPosOfPlate = -3.25f;
    public static int gameDifficulty = 2;
    public static bool gameStart = true;
    
    public static int activeOrder = 0; // bunu ordermakerda kullanýp sipariþ listesi endeksi olabilir
    public static List<List<string>> orderCounter = new List<List<string>>(); //orderlarýn toplandýðý liste

    public static int correctOrderIndex = -1;

    public static bool foodSent = false;

    public static int totalPoints = 0;

    private OrderMaker newOrder;
    private OrderGraphics newOrderGraphics;

    public static bool screenSwitch = true; //true = food prepare, false = puzzle and customer

    public static bool gameActive = false;
    public static int dayCount = 1;
    public static float dayRemainingTime = 20f;

    public static bool isGamePaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        allKeyBindingsUsed = new List<string>(allKeyBindings);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
