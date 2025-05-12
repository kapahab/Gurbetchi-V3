using UnityEngine;
using System.Collections;

public class ZonePicker : MonoBehaviour
{
    [SerializeField] string keyStrokeZone;
    public bool isThisZoneActive = false;
    public static ZonePicker currentActiveZone = null;
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
    }

    void CheckZoneSwitch()
    {
        if (Input.GetKeyDown(keyStrokeZone))
        {
            // If another zone is active, deactivate it
            if (currentActiveZone != null && currentActiveZone != this)
            {
                currentActiveZone.DeactivateZone();
            }

            // Toggle this zone: if already active, deactivate; otherwise activate
            if (isThisZoneActive)
            {
                DeactivateZone();
            }
            else
            {
                ActivateZone();
            }
        }
    }

    void ActivateZone()
    {
        StartCoroutine(WaitAndSetZone(true));
        currentActiveZone = this;
        Debug.Log("Zone activated: " + keyStrokeZone);
    }

    void DeactivateZone()
    {
        StartCoroutine(WaitAndSetZone(false));
        if (currentActiveZone == this)
            currentActiveZone = null;
        Debug.Log("Zone deactivated: " + keyStrokeZone);
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
