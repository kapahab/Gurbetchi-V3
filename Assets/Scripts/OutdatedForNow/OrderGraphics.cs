using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class OrderGraphics : MonoBehaviour
{
    public GameObject[] carbModels;
    public GameObject[] toppingModels;
    public GameObject[] sauceModels;
    public GameObject[] spiceModels;
    public GameObject[] donerModels;



    void Start()
    {
    }

    void Update()
    {
    }

    public void PrepareOrderGraphics(int carbValue,  int spiceValue, int sauceValue, int donerValue, List<int> toppingIndexes) // siparişin görüntülerini 5 saniyeliğine ekrana getirir
    {
        List<Vector2> positions = new List<Vector2>();
        Debug.Log("Order graphic is prepared");
        Debug.Log("Carb value: " + carbValue + "Topping value: " + toppingIndexes[0] + "Spice value: "+ spiceValue + "sauce value: "+ sauceValue + "doner value : " + donerValue);
        switch (gameFlow.gameDifficulty)
        {
            case 0:
                positions = PositionMaker(5);
                break;
            case 1:
                positions = PositionMaker(6);
                break;
            case 2:
                positions = PositionMaker(7);
                break;

        }



        // inspectordaki objelerin sırası OrderMakerdaki sırayla aynı olmalıdır.
        switch(gameFlow.gameDifficulty)
        {
            case 0:
                {
                    CarbGraphic(carbValue, positions[0].x, positions[0].y);

                    ToppingGraphic(toppingIndexes[0], positions[1].x, positions[1].y);

                    SpiceGraphic(spiceValue, positions[2].x, positions[2].y);

                    SauceGraphic(sauceValue, positions[3].x, positions[3].y);

                    DonerGraphic(donerValue, positions[4].x, positions[4].y);

                    break;
                }

            case 1:
                {
                    CarbGraphic(carbValue, positions[0].x, positions[0].y);

                    ToppingGraphic(toppingIndexes[0], positions[1].x, positions[1].y);

                    ToppingGraphic(toppingIndexes[1], positions[2].x, positions[2].y);

                    SpiceGraphic(spiceValue, positions[3].x, positions[3].y);

                    SauceGraphic(sauceValue, positions[4].x, positions[4].y);

                    DonerGraphic(donerValue, positions[5].x, positions[5].y);

                    break;
                }

            case 2:
                {
                    CarbGraphic(carbValue, positions[0].x, positions[0].y);

                    ToppingGraphic(toppingIndexes[0], positions[1].x, positions[1].y);

                    ToppingGraphic(toppingIndexes[1], positions[2].x, positions[2].y);

                    ToppingGraphic(toppingIndexes[2], positions[3].x, positions[3].y);

                    SpiceGraphic(spiceValue, positions[4].x, positions[4].y);

                    SauceGraphic(sauceValue, positions[5].x, positions[5].y);

                    DonerGraphic(donerValue, positions[6].x, positions[6].y);

                    break;
                }
        }




    }

    public void CarbGraphic(int carbValue, float xPos, float yPos)
    {
        GameObject carbModel = Instantiate(carbModels[carbValue], new Vector2(xPos, yPos), Quaternion.identity);
        Destroy(carbModel, 5f);

    }

    public void ToppingGraphic(int toppingValue, float xPos, float yPos)
    {
        GameObject toppingModel = Instantiate(toppingModels[toppingValue], new Vector2(xPos, yPos), Quaternion.identity);
        Destroy(toppingModel, 5f);

    }

    public void SpiceGraphic(int spiceValue, float xPos, float yPos)
    {
        GameObject spiceModel = Instantiate(spiceModels[spiceValue], new Vector2(xPos, yPos), Quaternion.identity);
        Destroy(spiceModel, 5f);

    }

    public void SauceGraphic(int sauceValue, float xPos, float yPos)
    {
        GameObject sauceModel = Instantiate(sauceModels[sauceValue], new Vector2(xPos, yPos), Quaternion.identity);
        Destroy(sauceModel, 5f);

    }

    public void DonerGraphic(int donerValue, float xPos, float yPos)
    {
        GameObject donerModel = Instantiate(donerModels[donerValue], new Vector2(xPos, yPos), Quaternion.identity);
        Destroy(donerModel, 5f);

    }

    public List<Vector2> PositionMaker(int totalOrderCount)
    {
        List<Vector2> positions = new List<Vector2>();

        float startX = -5.75f; // Starting X position
        float incrementX = 3.90f; // Horizontal spacing
        float startY = 1.83f; // Starting Y position
        float incrementY = 0f; // Vertical spacing (set to 0 for a single row layout)
        float lowerX = 0;
        float lowerXIncrement = 0;
        float xPos;
        float yPos;
        switch (totalOrderCount) // alt sırayı oluşturmak için gerekli olan değişkenler
        {
            case 5:
                lowerX = 0;
                lowerXIncrement = 0;
                break;
            case 6:
                lowerX = startX;
                lowerXIncrement = incrementX;
                break;
            case 7:
                lowerX = startX;
                lowerXIncrement = incrementX;
                break;
        }
        for (int i = 0; i < totalOrderCount; i++)
        {
            if (i >= 4) // alt sıra koşulu
            {
                xPos = lowerX + (i - 3) * lowerXIncrement;
                yPos = -1.95f;
                positions.Add(new Vector2(xPos, yPos));
                continue;
            }
            xPos = startX + i * incrementX;
            yPos = startY + i * incrementY;
            positions.Add(new Vector2(xPos, yPos));
        }

        return positions;
    }


}

