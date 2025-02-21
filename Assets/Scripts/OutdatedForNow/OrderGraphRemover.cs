using UnityEngine;

public class OrderGraphRemover : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] order1Line;
    [SerializeField] SpriteRenderer[] order2Line;
    [SerializeField] SpriteRenderer[] order3Line;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLine(int amountOfIng, SpriteRenderer[] orderNum)
    {
        Debug.Log("RemoveLine çalýþtý");
        for (int i=0; i < amountOfIng; i++)
        {
            orderNum[i].enabled = false;
        }
    }
}
