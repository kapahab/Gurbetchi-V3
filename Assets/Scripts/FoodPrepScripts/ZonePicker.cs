using UnityEngine;
using System.Collections;

public class ZonePicker : MonoBehaviour
{
    [SerializeField] string keyStrokeZone;
    public bool isThisZoneActive = false;
    public static ZonePicker currentActiveZone = null;
    public bool isThisCarbZone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameFlow.gameActive) return;
        if (!gameFlow.screenSwitch) return;



        CheckZoneSwitch();
        CarbFunctions();
    }

    void CarbFunctions()
    {
        if (!isThisCarbZone)
        {
            if (!gameFlow.isCarbOnTable)
            {
                DeactivateZone();
            }
                return;
        }
        if (!gameFlow.isCarbOnTable)
            return;
        DeactivateZone();
    }

    void CheckZoneSwitch()
    {
        if (Input.GetKeyDown(keyStrokeZone))
        {
            // If another zone is active, deactivate it
            if (currentActiveZone != null && currentActiveZone != this)
            {
                currentActiveZone.DeactivateZone();
                Debug.Log("Deactivated another zone: " );
            }

            // Toggle this zone: if already active, deactivate; otherwise activate
            if (isThisZoneActive)
            {
                DeactivateZone();
                Debug.Log("Zone deactivated: " + keyStrokeZone);
            }
            else
            {
                ActivateZone();
                Debug.Log("Zone activated: " + keyStrokeZone);
            }
        }
    }

    void ActivateZone()
    {
        StartCoroutine(WaitAndSetZone(true));
        currentActiveZone = this;
    }

    void DeactivateZone()
    {
        StartCoroutine(WaitAndSetZone(false));
        if (currentActiveZone == this)
            currentActiveZone = null;
    }

    IEnumerator WaitAndSetZone(bool value)
    {
        yield return null;//new WaitForSeconds(0.01f);
        gameFlow.isZoneSelected = value;
        isThisZoneActive = value;
    }

    void DonerCompatabilty()
    {
        if (currentActiveZone == this)
            DeactivateZone();
    }

    void OnEnable()
    {
        EventManager.OnDonerEnter += DonerCompatabilty;
        
    }

    private void OnDisable()
    {
        EventManager.OnDonerEnter -= DonerCompatabilty;
        
    }

}
