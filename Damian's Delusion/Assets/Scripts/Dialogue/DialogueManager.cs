using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public GameObject dialogueBox;
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI sentenceText;

    public playerMovement mov;
    public cameraLook cam;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        dialogueBox.SetActive(false);
        nameText = dialogueBox.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
        if (nameText == null) Debug.LogError("could not find name text mesh pro");

        sentenceText = dialogueBox.transform.Find("Sentence").gameObject.GetComponent<TextMeshProUGUI>();
        if (sentenceText == null) Debug.LogError("could not find sentence text mesh pro");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // stop player movement
        mov.enabled = false;
        cam.enabled = false;

        // enable mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // restart dialogue action
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        nameText.text = dialogue.name;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        sentenceText.text = sentence;
        dialogueBox.SetActive(true);
    }

    public void EndDialogue()
    {
        mov.enabled = true;
        cam.enabled = true;

        // disable mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        dialogueBox.SetActive(false);
    }
}
