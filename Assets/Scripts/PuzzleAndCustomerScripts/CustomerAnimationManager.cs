using UnityEngine;
using DG.Tweening;

public class CustomerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator customerAnimator;
    [SerializeField] string animationNameOpen;
    [SerializeField] string animationNameClose;
    [SerializeField] Transform thoughtBubbleTransform;
    Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = thoughtBubbleTransform.position; //bunun update edilmesi gerekiyo bir þekilde(yoksa puzzle kapandýgýnda düþünce balonu yanlýþ yere gidiyor) 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCustomerAnimation()
    {
        SetToPosition(-30f, 0, 0);
        customerAnimator.Play(animationNameOpen);
    }

    public void StopCustomerAnimation()
    {
        SetToPosition(startPosition.x, startPosition.y, startPosition.z);
        customerAnimator.Play(animationNameClose);
    }

    void SetToPosition(float xPos, float yPos, float zPos)
    {
        thoughtBubbleTransform.DOMove(new Vector3(xPos, yPos, zPos), 0.5f).SetEase(Ease.OutSine);
    }
}
