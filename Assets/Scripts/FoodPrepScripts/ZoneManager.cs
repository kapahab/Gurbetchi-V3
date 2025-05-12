using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public int moveIndex = 10;
    ZonePicker zonePicker;
    [SerializeField] int maxIndexTens, maxIndexOnes;
    public bool inThisZone = false;
    bool spritesDarkened = true;
    bool lastZoneState = false;
    [SerializeField] GameObject[] foodInZone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zonePicker = GetComponent<ZonePicker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameFlow.gameActive) return;
        if (!gameFlow.screenSwitch) return;

        inThisZone = zonePicker.isThisZoneActive;

        if (ZonePicker.currentActiveZone == null)
            UndarkenSprites();
        if (ZonePicker.currentActiveZone != null && !inThisZone)
            DarkenSprites();
        if (ZonePicker.currentActiveZone != null && inThisZone)
            UndarkenSprites();

        if (!inThisZone)
            return;
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && CheckAvailablity(moveIndex-10))
            moveIndex -= 10;
        if (Input.GetKeyDown(KeyCode.DownArrow) && CheckAvailablity(moveIndex + 10))
            moveIndex += 10;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && CheckAvailablity(moveIndex - 1))
            moveIndex -= 1;
        if (Input.GetKeyDown(KeyCode.RightArrow) && CheckAvailablity(moveIndex + 1))
            moveIndex += 1;
       Debug.Log("Move index: " + moveIndex);
    }

    bool CheckAvailablity(int moveIndexToBe)
    {
        if (moveIndexToBe % 10 > maxIndexOnes || moveIndexToBe / 10 > maxIndexTens/10 || moveIndexToBe/10 < 1)
            return false;
        return true;
    }

    void DarkenSprites()
    {
        if (spritesDarkened)
            return;
        foreach (GameObject food in foodInZone)
        {
            SpriteRenderer spriteRenderer = food.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color = new Color(0.5f, 0.5f, 0.5f); // Set the alpha value to 0.5 for darkening
                spriteRenderer.color = color;
            }
        }
        spritesDarkened = true;
    }

    void UndarkenSprites()
    {
        if (!spritesDarkened)
            return;
        foreach (GameObject food in foodInZone)
        {
            SpriteRenderer spriteRenderer = food.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color = new Color(1f, 1f, 1f); // Set the alpha value to 1 for undarkening
                spriteRenderer.color = color;
            }
        }
        spritesDarkened = false;
    }

}
