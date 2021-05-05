using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Dialogue dialogue = new Dialogue();
        dialogue.name = "david banana";
        dialogue.sentences = new string[] { "hello", "my name is david", "what is yours" };

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
