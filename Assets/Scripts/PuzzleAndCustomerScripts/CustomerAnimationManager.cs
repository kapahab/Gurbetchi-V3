using UnityEngine;
using DG.Tweening;
using UnityEditor.Search;

public class CustomerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator customerAnimator;
    [SerializeField] string animationNameOpen;
    [SerializeField] string animationNameClose;
    [SerializeField] Transform thoughtBubbleTransform;
    Vector3 startPosition;
    Vector3 localEndPosition = new Vector3(0,0,0);
    Vector3 openPuzzlePosition;
    bool isPuzzleOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = thoughtBubbleTransform.localPosition; //bunun update edilmesi gerekiyo bir þekilde(yoksa puzzle kapandýgýnda düþünce balonu yanlýþ yere gidiyor) 
        EndPosCalc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCustomerAnimation()
    {
        openPuzzlePosition = new Vector3(-30f, 0, 0); 

        SetToPosition(openPuzzlePosition.x, openPuzzlePosition.y, openPuzzlePosition.z);
        customerAnimator.Play(animationNameOpen);

        isPuzzleOpen = true;

        thoughtBubbleTransform.GetComponent<SpriteRenderer>().sortingOrder = 9; //bu muhabbet çok saçma þimdilik buraya koydum, çözülmüþ puzzlelarýn
        //üstüne çýkabilmesi için gerekli
    }

    public void StopCustomerAnimation()
    {
        SetToPositionLocal(startPosition.x, startPosition.y, startPosition.z);
        customerAnimator.Play(animationNameClose);

        isPuzzleOpen = false;

        thoughtBubbleTransform.GetComponent<SpriteRenderer>().sortingOrder = 7;
    }

    void SetToPosition(float xPos, float yPos, float zPos)
    {
        thoughtBubbleTransform.DOMove(new Vector3(xPos, yPos, zPos), 0.5f).SetEase(Ease.OutSine);
    }

    void SetToPositionLocal(float xPos, float yPos, float zPos)
    {
        thoughtBubbleTransform.DOLocalMove(new Vector3(xPos, yPos, zPos), 0.5f).SetEase(Ease.OutSine);
    }

    void EndPosCalc()
    {
        localEndPosition = transform.position - thoughtBubbleTransform.position;
        Debug.Log(localEndPosition);
    }

    public void UpdateOpenPuzzlePosition()
    {
        if (!isPuzzleOpen) 
            return;
        thoughtBubbleTransform.position = openPuzzlePosition;
    }

    


}
