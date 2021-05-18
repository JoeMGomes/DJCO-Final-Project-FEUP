using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{

    private static MessageManager instance;
    public GameObject messagePrefab;

    public List<HUD_Message> messageSlots;
    public List<string> queuedMessages;
    public float messageTime = 1.0f;
    private bool poping;
    private void Start()
    {
        instance = this;
    }

    //Inserts a new message on queue
    //Updates message display if needed
    //Starts Poping message Courotine
    public void InsertMessage(string message)
    {
        queuedMessages.Add(message);

        if(queuedMessages.Count <= messageSlots.Count)
            UpdateSlots();

        if(!poping)
            StartCoroutine(WaitForPop());

    }


    //Sets all message slots text fields with the existing queued messages
    private void UpdateSlots()
    {

        for (int i = 0; i < messageSlots.Count; i++)
        {
            Debug.Log(i);
            if (i >= queuedMessages.Count)
            {
                Debug.Log("emppt");
                messageSlots[i].SetText("");
            }
            else
            {
                Debug.Log("set");
                messageSlots[i].SetText(queuedMessages[i]);

            }
        }
    }

    private void PopMessage()
    {
        queuedMessages.RemoveAt(0);
    }

    //While there are queued messages pops one message and waits messageTime seconds
    private IEnumerator WaitForPop()
    {
        poping = true;
        while (queuedMessages.Count > 0)
        {
            yield return new WaitForSeconds(messageTime);
            PopMessage();
            UpdateSlots();
        }
        poping = false;

    }


}
