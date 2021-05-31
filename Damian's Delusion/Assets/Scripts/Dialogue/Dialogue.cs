using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    public Knowledge necessaryKnowledge;
    [TextArea]
    public string noKnowledgeSentence;

    [TextArea]
    public string initialSentence;

    public DialogueQuestion[] questions;
    public IDialogueCallBack callback;

    public string GetQuestion(int index)
    {
        return questions[index].question;
    }

    public string[] GetSentences(int index)
    {
        return questions[index].sentences;
    }

    public Knowledge GetKnowledgeQuestion(int index)
    {
        return questions[index].necessaryKnowledge;
    }

    public int GetQuestionsSize()
    {
        return questions.Length;
    }

    internal void Callback(int questionNumber)
    {
        callback.Run(questionNumber);

    }
}
