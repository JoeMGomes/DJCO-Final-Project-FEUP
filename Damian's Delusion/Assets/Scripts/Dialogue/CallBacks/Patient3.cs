using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient3 : IDialogueCallBack
{

    public Key key;
    public Item wine;

    public override IEnumerator CallBack_4()
    {
        InventoryController.instance.Remove(wine);
        MessageManager.instance.InsertMessage("Alcohol lost");
        InventoryController.instance.Add(key);
        MessageManager.instance.InsertMessage("Key Received");
        DialogueManager.instance.EndDialogue();
        //Enumerator return is mandatory to enable more complex callbacks
        yield return new WaitForSeconds(0.01f);
    }
}
