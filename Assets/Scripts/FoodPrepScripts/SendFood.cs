using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class SendFood : MonoBehaviour
{
    [SerializeField] FoodOnPlate foodOnPlate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnEnable()
    {
        EventManager.OnPlateServed += FoodDestroyer;
        EventManager.OnPlateServed += SwitchScene;
        EventManager.OnFoodTrashed += FoodDestroyer;
    }

    void OnDisable()
    {
        EventManager.OnPlateServed -= FoodDestroyer;
        EventManager.OnPlateServed -= SwitchScene;
        EventManager.OnFoodTrashed -= FoodDestroyer;
    }

    


     void FoodDestroyer()
    {
        foreach (GameObject copyClone in foodOnPlate.copiedObjects) //listedeki her copyClone i�in copyClone silinir, yani tabaktaki
                                                                    //her �ey silinir
        {
            Destroy(copyClone);
        }
    }

    void SwitchScene()
    {
        //buraya bir if kosulu eklenmeli ama ne oldu�unu bi t�rl� bulamad�m
        gameFlow.foodSent = true;
        Camera.main.transform.position = new Vector3(-30, 0, -10); //bu iki line s�rekli kopyalan�p olamaz, d�zg�n bir metod bul
        gameFlow.screenSwitch = false; // camera switchi ayr� class yap�p, space'e bas�ld���nda �a�r�labilir
    }
}
