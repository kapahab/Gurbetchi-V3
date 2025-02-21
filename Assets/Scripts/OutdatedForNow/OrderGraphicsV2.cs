using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OrderGraphicsV2 : MonoBehaviour
{
    [SerializeField] Sprite[] carbSprites;
    [SerializeField] Sprite[] toppingSprites;
    [SerializeField] Sprite[] sauceSprites;
    [SerializeField] Sprite[] spiceSprites;
    [SerializeField] Sprite[] donerSprites;
    [SerializeField] SpriteRenderer[] order1Line;
    [SerializeField] SpriteRenderer[] order2Line;
    [SerializeField] SpriteRenderer[] order3Line;

    void Start()
    {
        // scaled by 0.2 and 0.2

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OrderGraphPreSet(int carbValue, int spiceValue, int sauceValue, int donerValue, List<int> toppingIndexes, SpriteRenderer[] orderLine)
    {
        switch (gameFlow.gameDifficulty)
        {
            case 0:
                SpriteIntoBox(0, carbSprites[carbValue], orderLine);
                SpriteIntoBox(1, toppingSprites[toppingIndexes[0]], orderLine);
                SpriteIntoBox(2, spiceSprites[spiceValue], orderLine);
                SpriteIntoBox(3, sauceSprites[sauceValue], orderLine);
                SpriteIntoBox(4, donerSprites[donerValue], orderLine);
                break;
            case 1:
                SpriteIntoBox(0, carbSprites[carbValue], orderLine);
                SpriteIntoBox(1, toppingSprites[toppingIndexes[0]], orderLine);
                SpriteIntoBox(2, toppingSprites[toppingIndexes[1]], orderLine);
                SpriteIntoBox(3, spiceSprites[spiceValue], orderLine);
                SpriteIntoBox(4, sauceSprites[sauceValue], orderLine);
                SpriteIntoBox(5, donerSprites[donerValue], orderLine); 
                break;
            case 2:
                SpriteIntoBox(0, carbSprites[carbValue], orderLine);
                SpriteIntoBox(1, toppingSprites[toppingIndexes[0]], orderLine);
                SpriteIntoBox(2, toppingSprites[toppingIndexes[1]], orderLine);
                SpriteIntoBox(3, toppingSprites[toppingIndexes[2]], orderLine);
                SpriteIntoBox(4, spiceSprites[spiceValue], orderLine);
                SpriteIntoBox(5, sauceSprites[sauceValue], orderLine);
                SpriteIntoBox(6, donerSprites[donerValue], orderLine); 
                break;

        }
    }

    private void SpriteIntoBox(int numInLine, Sprite relatedSprite, SpriteRenderer[] orderNum)
    {
        orderNum[numInLine].enabled = true;
        orderNum[numInLine].sprite = relatedSprite;
        orderNum[numInLine].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }
}
