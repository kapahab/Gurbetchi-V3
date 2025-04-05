using UnityEngine;
using DG.Tweening;

public class CustomerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator customerAnimator;
    [SerializeField] string animationNameOpen;
    [SerializeField] string animationNameClose;
    [SerializeField] Transform thoughtBubbleTransform;
    Vector3 startPosition;
    Vector3 localEndPosition = new Vector3(0,0,0);
    Vector3 openPuzzlePosition;
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
        SetToPosition(-30f, 0, 0);
        openPuzzlePosition = thoughtBubbleTransform.localPosition;
        customerAnimator.Play(animationNameOpen);
    }

    public void StopCustomerAnimation()
    {

        SetToPositionLocal(startPosition.x, startPosition.y, startPosition.z);
        customerAnimator.Play(animationNameClose);
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
        if (openPuzzlePosition == null) 
            return;
        thoughtBubbleTransform.localPosition = openPuzzlePosition;
    }

    


}
