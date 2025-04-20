using DG.Tweening;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class ReciptManager : MonoBehaviour
{
    public OrderManager orderManager;
    [SerializeField] GameObject[] reciptPrefab;
    Image[] img = new Image[3];

    Color tempColor;
    bool reciptChanged = false;
    int reciptIndex;

    //List<bool> isPuzzleSolved = new List<bool>{ };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //ordermanagerdan is puzzle solvedlarý çek

        //this.transform.GetComponent<HorizontalLayoutGroup>().enabled = false;
        for (int i = 0; i< reciptPrefab.Length; i++)
        {
            img[i] = reciptPrefab[i].GetComponent<Image>();
            Color tempColor = img[i].color;
            tempColor.a = 0f;
            img[i].color = tempColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for döngüsünün içinde puzzlelarýn solved olup olmadýðýný kontrol et, solved olan puzzlea göre gridi aktivleþtir
    }

    void ReciptSpawn()
    {
        Debug.Log("Recipt Spawned");
        for (int i = 0; i < orderManager.instantiatedObjects.Count; i++)
        {
            Color tempColor = img[i].color;
            tempColor.a = 1f;
            img[i].color = tempColor;

            reciptPrefab[i].GetComponent<RectTransform>().DOAnchorPosY(0, 0.5f).SetEase(Ease.OutBack);

        }

        //when customer deleted check customer count set alpha to zero and original position
    }

    void PuzzleSolved()
    {

    }


    private void OnEnable()
    {
        OrderManager.OnCustomerSpawned += ReciptSpawn;
    }

    private void OnDisable()
    {
        OrderManager.OnCustomerSpawned -= ReciptSpawn;

    }


    void MoveReciptDown(int reciptIndex)
    {
        reciptPrefab[reciptIndex].GetComponent<RectTransform>().DOAnchorPosY(0, 0.5f).SetEase(Ease.OutBack);
    }

    void MoveReciptUp(int reciptIndex)
    {
        reciptPrefab[reciptIndex].GetComponent<RectTransform>().DOAnchorPosY(0, 0.5f).SetEase(Ease.OutBack);
    }



}
