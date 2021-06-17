using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient4 : IDialogueCallBack
{

    public Key key;
    public TimerController timerController;

    public override IEnumerator CallBack_1()
        {
            timerController.timeLeft = 0f;
            timerController.EndGame = true;
            DialogueManager.instance.EndDialogue();
            //Enumerator return is mandatory to enable more complex callbacks
            yield return new WaitForSeconds(0.01f);
        }

    public override IEnumerator CallBack_2()
    {
        InventoryController.instance.Add(key);
        MessageManager.instance.InsertMessage("Exit Key Received");
        DialogueManager.instance.EndDialogue();
        //Enumerator return is mandatory to enable more complex callbacks
        yield return new WaitForSeconds(0.01f);
    }
}
