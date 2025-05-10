using UnityEngine;
using System.Collections;

public class ZonePicker : MonoBehaviour
{
    [SerializeField] string keyStrokeZone;
    public bool isThisZoneActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnterZone();
        ExitZone();
    }

    void EnterZone()
    {
        if (gameFlow.isZoneSelected)
            return;

        if (Input.GetKeyDown(keyStrokeZone))
        {

            StartCoroutine(WaitForSeconds(true));
            Debug.Log("Zone is selected");
        }
    }

    void ExitZone()
    {
        if (!isThisZoneActive)
            return;
        if (Input.GetKeyDown(keyStrokeZone))
        {

            StartCoroutine(WaitForSeconds(true));
            Debug.Log("Zone is deselected");
        }
    }

    IEnumerator WaitForSeconds(bool trueOrFalse)
    {
        yield return new WaitForSeconds(0.01f);
        gameFlow.isZoneSelected = trueOrFalse;
        isThisZoneActive = trueOrFalse;
    }
}
