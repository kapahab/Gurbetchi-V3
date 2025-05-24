using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class MarxText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI marxText; // Reference to the TextMeshProUGUI component
    [SerializeField] string[] tutorialTexts; // Array of tutorial texts
    private int currentTextIndex = 0; // Index to track the current text being displayed
    [SerializeField] float textDisplaySpeed; // Time in seconds to display each text
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        marxText.text = string.Empty; // Clear the text at the start
        StartDialogue(); // Start the dialogue by initializing the text index
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (marxText.text == tutorialTexts[currentTextIndex])
                NextLine();
            else
            {
                StopAllCoroutines(); 
                marxText.text = tutorialTexts[currentTextIndex];
                RebuildLayout();
            }
        }
    }

    void StartDialogue()
    {
        currentTextIndex = 0;
        StartCoroutine(TypeLine()); // Start the coroutine to type out the first line of text
    }
    IEnumerator TypeLine()
    {
        foreach (char letter in tutorialTexts[currentTextIndex].ToCharArray())
        {
            marxText.text += letter; // Append each letter to the text
            yield return new WaitForSeconds(textDisplaySpeed); // Wait for a short duration before displaying the next letter
            RebuildLayout();
        }
    }

    void RebuildLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(marxText.rectTransform); // Force the layout to rebuild immediately
    }

    void NextLine()
    {

        if (currentTextIndex < tutorialTexts.Length - 1) // If there are more texts to display
        {
            currentTextIndex++; // Move to the next text
            marxText.text = string.Empty; // Clear the current text
            RebuildLayout();
            StartCoroutine(TypeLine()); // Start typing the next line of text
        }
        else
        {
            marxText.text = string.Empty; // Clear the text when the tutorial is complete
            gameObject.SetActive(false); // Optionally deactivate this GameObject or perform any other action
        }

    }
}
