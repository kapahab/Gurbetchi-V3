using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public int moveIndex = 10;
    ZonePicker zonePicker;
    [SerializeField] int maxIndexTens, maxIndexOnes;
    public bool inThisZone = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zonePicker = GetComponent<ZonePicker>();
    }

    // Update is called once per frame
    void Update()
    {
        zonePicker.isThisZoneActive = inThisZone;
        if (!inThisZone)
            return;
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && CheckAvailablity(moveIndex+10))
            moveIndex += 10;
        if (Input.GetKeyDown(KeyCode.DownArrow) && CheckAvailablity(moveIndex - 10))
            moveIndex -= 10;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && CheckAvailablity(moveIndex - 1))
            moveIndex -= 1;
        if (Input.GetKeyDown(KeyCode.RightArrow) && CheckAvailablity(moveIndex + 1))
            moveIndex += 1;
       
    }

    bool CheckAvailablity(int moveIndexToBe)
    {
        if (10 % moveIndexToBe < maxIndexOnes || maxIndexTens / moveIndexToBe < 1)
            return false;
        return true;
    }

}
