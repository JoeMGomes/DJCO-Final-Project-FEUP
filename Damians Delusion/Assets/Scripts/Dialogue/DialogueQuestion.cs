using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueQuestion
{
    public string question;
    public Knowledge necessaryKnowledge;

    [TextArea(1, 10)]
    public string[] sentences;
}
