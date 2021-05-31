using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient1 : IDialogueCallBack
{

    public Door_Interactable door;

    public override IEnumerator CallBack_4()
    {
        door.Unlock();
        MessageManager.instance.InsertMessage("Door opened nearby...");

        //Enumerator return is mandatory to enable more complex callbacks
        yield return new WaitForSeconds(0.01f);
    }
}
