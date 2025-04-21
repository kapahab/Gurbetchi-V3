using DG.Tweening;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ReciptManager : MonoBehaviour
{
    [SerializeField]int index;
    public OrderManager orderManager;
    [SerializeField] GameObject[] reciptPrefab;
    Image image;
    Color tempColor;
    [SerializeField] CanvasGroup germanText;
    [SerializeField] CanvasGroup ownAlpha;

    bool reciptActive = false;
    bool puzzleInitiated = false;
    int reciptIndex;

    CustomerManager customerManager;
    [SerializeField]CorrectOrderSpawnerRecipt correctOrderSpawnerRecipt;

    RectTransform rectTransform; 

    float yOffsetDown = 30f;
    float yPositionUp = 73f;

    //List<bool> isPuzzleSolved = new List<bool>{ };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        ownAlpha.alpha = 0f;
        //ordermanagerdan is puzzle solvedlarý çek
        /*
        //this.transform.GetComponent<HorizontalLayoutGroup>().enabled = false;
        for (int i = 0; i< reciptPrefab.Length; i++)
        {
            img[i] = reciptPrefab[i].GetComponent<Image>();
            Color tempColor = img[i].color;
            tempColor.a = 0f;
            img[i].color = tempColor;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (orderManager.instantiatedObjects.Count > index)
        {
            if (!reciptActive)
                InitilizeRecipt();//2. günden itibaren ilk müþteride bu kýsým doðru çalýþmýyor sanýrým
            if (customerManager.isPuzzleSolved && !puzzleInitiated)//2. günden itibaren ilk müþteride bu kýsým doðru çalýþmýyor sanýrým
                PuzzleSolved();
            if (Input.GetKeyDown((index+1).ToString()))
                MoveReciptDown();
            if (Input.GetKeyUp((index + 1).ToString()))
                MoveReciptUp();
            
            
        }
        //for döngüsünün içinde puzzlelarýn solved olup olmadýðýný kontrol et, solved olan puzzlea göre gridi aktivleþtir
        else if (reciptActive)
            DeactivateRecipt();


        if (!gameFlow.screenSwitch)
        {
            HideShowRecipt(0f);
        }
        else if (reciptActive)
        {

            HideShowRecipt(1f);
        }
    }

    void InitilizeRecipt()
    {
        germanText.alpha = 1f;
        ownAlpha.alpha = 1f;
        customerManager = orderManager.instantiatedObjects[index].GetComponent<CustomerManager>();
        Debug.Log("Recipt index: " + index);
        Debug.Log("Recipt prefab: " + customerManager.orderID);//sorunu çözmek için log ekle

        reciptActive = true;
        Debug.Log("Recipt active");
    }

    void DeactivateRecipt()
    {
        ownAlpha.alpha = 0f;
        reciptActive = false;
        Debug.Log("Recipt inactive");
    }

    void HideShowRecipt(float value)
    {
        /*
        tempColor.a = value;
        image.color = tempColor;
        if (!puzzleInitiated)
            germanText.alpha = 1f;
        else
            germanText.alpha = 0f;
        */
        ownAlpha.alpha = value;
    }
    void PuzzleSolved()
    {
        correctOrderSpawnerRecipt.InstantiateCorrectOrders(customerManager.orderMaker);
        germanText.alpha = 0f;
        StartCoroutine(WaitForSeconds());
        puzzleInitiated = true;
    }

    IEnumerator WaitForSeconds()
    {
        Debug.Log("WaitForSeconds");
        yield return new WaitForSeconds(0.1f);
        yOffsetDown = yPositionUp - correctOrderSpawnerRecipt.CalculateDeltaY();
    }

    void MoveReciptDown()
    {
        rectTransform.DOAnchorPosY(yOffsetDown, 0.5f).SetEase(Ease.OutBack);
    }

    void MoveReciptUp()
    {
        rectTransform.DOAnchorPosY(yPositionUp, 0.5f).SetEase(Ease.OutBack);
    }

    void ClearPuzzle()
    {
        if (puzzleInitiated)
        {
            correctOrderSpawnerRecipt.DestroyInstances();
        }
    }

    void ReOrderRecipt()
    {
        if (!reciptActive)
            return;
        if (orderManager.instantiatedObjects.Count > index)
        {
            customerManager = orderManager.instantiatedObjects[index].GetComponent<CustomerManager>();
            if (customerManager.isPuzzleSolved)
            {
                correctOrderSpawnerRecipt.InstantiateCorrectOrders(customerManager.orderMaker);
                germanText.alpha = 0f;
                puzzleInitiated = true;
            }
            else
            {
                correctOrderSpawnerRecipt.DestroyInstances();
                germanText.alpha = 1f;
                yOffsetDown = 30f;
                puzzleInitiated = false;
            }
        }
    }

    private void OnEnable()
    {
        OrderManagerPuzzle.OnCustomerDeleted += ClearPuzzle;
        OrderManagerPuzzle.OnCustomerDeleted += ReOrderRecipt;
    }

    private void OnDisable()
    {
        OrderManagerPuzzle.OnCustomerDeleted -= ClearPuzzle;
        OrderManagerPuzzle.OnCustomerDeleted -= ReOrderRecipt;
    }



}
