using UnityEngine;

public class ScrappyInputGraphics : MonoBehaviour
{
    [SerializeField] GameObject[] inputObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DarkenObjects()
    {
        for (int i = 0; i < inputObjects.Length; i++)
        {
            inputObjects[i].GetComponent<SpriteRenderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    public void LightenObjects()
    {
        for (int i = 0; i < inputObjects.Length; i++)
        {
            inputObjects[i].GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f);
        }
    }
}
