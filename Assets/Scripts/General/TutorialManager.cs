using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isTutorialActive = false;
    public bool isTutorialComplete = false;
    [SerializeField] GameObject easyOrderPrefab;
    CustomerManager marxCustomerManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTutorial()
    {
        isTutorialActive = true;
        // Add tutorial logic here

    }
    //ilk marx gelicek, yemek yapmayi ogreticek. sonra marx oradayken bir musteri gelicek ve puzzle mekanigini anlaticak. o musteri gidince marx ekranin tepesine gelicek ve orada kalicak

    void SpawnMarx()
    {
        GameObject newOrder = Instantiate(easyOrderPrefab);
        newOrder.transform.position = new Vector3(0, 0, 0); // Set the position as needed

        marxCustomerManager = newOrder.GetComponent<CustomerManager>();

    }
}
