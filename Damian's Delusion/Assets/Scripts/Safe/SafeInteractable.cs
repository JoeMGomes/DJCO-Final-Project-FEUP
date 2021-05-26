using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeInteractable : Interactable
{

    public bool isLocked = true;

    public Knowledge unlockKnowledge;

    public GameObject codePanel;
    private string openString = "Press 'E' to unlock";
    private string failedMessage = "Wrong code";
    private string unlockedMessage = "Safe Opened!";
    public string unlockCode = "1234";

override public void Interact()
    {
        base.Interact();

        if (!isLocked)
        {
            return;
        }
        else
        {
            Destroy(HUDText_gameobject);
            codePanel.GetComponent<CodePanel>().Begin();
        }

    }

    public void Open(){
        MessageManager.instance.InsertMessage(unlockedMessage);
        isLocked = false;
    }

     public void Fail(){
        MessageManager.instance.InsertMessage(failedMessage);
    }
    override public void OnFocus()
    {
        if (HUDText_gameobject == null)
        {
            HUDText_gameobject = Instantiate(HUDText_prefab, GameObject.FindGameObjectWithTag("Canvas").transform);
                HUDText_gameobject.GetComponent<HUD_Interactable>().setText(openString);
        }
    }
}
