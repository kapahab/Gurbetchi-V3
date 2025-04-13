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
    [SerializeField] private List<string> carbKeyBindings = new List<string>();
    [SerializeField] private List<string> toppingKeyBindings = new List<string>();
    [SerializeField] private List<string> spiceKeyBindings = new List<string>();
    [SerializeField] private List<string> sauceKeyBindings = new List<string>();

    public static List<string> allKeyBindingsUsed;
    public static List<string> carbKeyBindingsUsed;

    public static float xPosOfPlate = 0f;
    public static float yPosOfPlate = -2.35f;
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
    [SerializeField] float dayTime = 90f; // 90 seconds
    public static float dayRemainingTime;

    public static bool isGamePaused = false;
    public static bool isCarbOnTable = false;


    public static List<string> allCarbList = new List<string> { "ekmek", "gobit", "lavas" };
    public static List<string> allToppingList = new List<string> { "domates", "morLahana", "lahana", "sogan", "patates", "tursu" };
    public static List<string> allSpiceList = new List<string> { "tuz", "pulbiber" };
    public static List<string> allSauceList = new List<string> { "kýrmýzý", "beyaz" };
    public static List<string> allDonerList = new List<string> { "az_doner", "orta_doner", "cok_doner" };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        allKeyBindingsUsed = new List<string>(allKeyBindings);
        carbKeyBindingsUsed = new List<string>(carbKeyBindings);
        dayRemainingTime = dayTime;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
