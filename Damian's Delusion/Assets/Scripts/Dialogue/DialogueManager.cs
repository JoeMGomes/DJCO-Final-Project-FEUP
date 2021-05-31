using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Dialogue dialogue;

    // sentences to display
    private Queue<string> sentences;

    // text components to edit easily
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI sentenceText;
    private TextMeshProUGUI[] buttonsText;
    //private TextMeshProUGUI button0Text;
    //private TextMeshProUGUI button1Text;
    //private TextMeshProUGUI button2Text;
    //private TextMeshProUGUI button3Text;

    // UI GameObjects to easily enable/disable them
    private GameObject overlay;
    private GameObject actionTip;
    private GameObject[] buttons;
    //private GameObject button0;
    //private GameObject button1;
    //private GameObject button2;
    //private GameObject button3;

    // manually set these on Unity
    public GameObject dialogueBox;
    public playerMovement mov;
    public cameraLook cam;
    public PlayerKnowledge player;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        if (dialogueBox == null) Debug.Log("component DialogueBox [UI] is missing");
        dialogueBox.SetActive(false);

        nameText = dialogueBox.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
        if (nameText == null) Debug.LogError("could not find name text mesh pro");

        sentenceText = dialogueBox.transform.Find("Sentence").gameObject.GetComponent<TextMeshProUGUI>();
        if (sentenceText == null) Debug.LogError("could not find sentence text mesh pro");

        buttons = new GameObject[4];
        buttonsText = new TextMeshProUGUI[4];

        for (int i = 0; i < 4; i++)
        {
            Transform button = dialogueBox.transform.Find("Button" + i);
            buttons[i] = button.gameObject;
            buttonsText[i] = button.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
            if (buttons[i] == null || buttonsText[i] == null) Debug.LogError("could not find button " + i + " in dialogue box");
        }

        overlay = dialogueBox.transform.Find("ContinueOverlay").gameObject;
        if (overlay == null) Debug.LogError("could not find continue overlay");
        overlay.SetActive(false);

        actionTip = dialogueBox.transform.Find("ActionTip").gameObject;
        if (actionTip == null) Debug.LogError("could not find action tip");
    }

    public void StartDialogue(Dialogue d)
    {
        // stop player movement
        mov.enabled = false;
        cam.enabled = false;

        // enable mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        dialogue = d;
        dialogueBox.SetActive(true);

        // if player has not knowledge
        // shows the message of noKnowledge
        // and deactivates buttons and actiontip
        if (!HasKnowledge()) return;

        // restart dialogue sentence and action
        ResetInitialDialogue();

        nameText.text = dialogue.name;

        GetButtons();
    }

    private bool HasKnowledge()
    {
        if (player.ContainsKnowledge(dialogue.necessaryKnowledge))
        {
            return true;
        }
        sentenceText.text = dialogue.noKnowledgeSentence;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        actionTip.SetActive(false);
        return false;
    }

    private void ResetInitialDialogue()
    {
        sentences.Clear();
        sentenceText.text = dialogue.initialSentence;
        actionTip.SetActive(true);
        overlay.SetActive(false);
    }

    private void GetButtons()
    {
        int questionNum = Mathf.Min(4,dialogue.GetQuestionsSize());
        for (int i = 0; i < questionNum; i++)
        {
            if (!player.ContainsKnowledge(dialogue.GetKnowledgeQuestion(i)))
            {
                buttons[i].SetActive(false);
            }
            else
            {
                buttons[i].SetActive(true);
                buttonsText[i].text = dialogue.GetQuestion(i);
            }
        }

        for (int i = questionNum; i < 4; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            ResetInitialDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        sentenceText.text = sentence;
    }

    public void PrepareSentences(int button)
    {
        string[] sent = dialogue.GetSentences(button);

        foreach (string s in sent)
        {
            sentences.Enqueue(s);
        }

        overlay.SetActive(true);

        DisplayNextSentence();
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
