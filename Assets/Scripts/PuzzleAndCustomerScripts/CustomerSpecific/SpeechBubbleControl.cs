using UnityEngine;
using UnityEngine.UI;

public class SpeechBubbleControl : MonoBehaviour
{
    RectTransform childRectTransform;
    RectTransform parentRectTransform;
    float childHeight;
    [SerializeField]GameObject[] thoughtBubbleObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        childRectTransform = this.transform.GetChild(0).GetComponent<RectTransform>();
        parentRectTransform = this.transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixContentSizeFitter()
    {/*
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.transform as RectTransform);
        gameObject.GetComponent<ContentSizeFitter>().enabled = false;
        gameObject.GetComponent<VerticalLayoutGroup>().enabled = false;
        childRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        childRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        childRectTransform.pivot = new Vector2(0.5f, 0.5f);
        childRectTransform.anchoredPosition = new Vector2(0, 0);
    */
        childRectTransform.GetComponent<ContentSizeFitter>().enabled = true;
        LayoutRebuilder.ForceRebuildLayoutImmediate(childRectTransform);
        childHeight = childRectTransform.sizeDelta.y;
        Debug.Log("Child Height: " + childHeight);
        parentRectTransform.sizeDelta = new Vector2(parentRectTransform.sizeDelta.x, childHeight+0.2f);
        LayoutRebuilder.ForceRebuildLayoutImmediate(parentRectTransform);
    }

    public void AdjustAlpha()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 1;

    }

    public void HideThoughtBubbles()
    {
        for (int i = 0; i < thoughtBubbleObjects.Length; i++)
        {
            thoughtBubbleObjects[i].SetActive(false);
        }
    }
}
