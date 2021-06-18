using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient2 : IDialogueCallBack
{

    public PlayerKnowledge player;
    public Knowledge untieKnowledge;

    public Knowledge killKnowledge;


    [FMODUnity.EventRef]
    public string thunderEvent = "event:/Player/Tile_Room_Footsteps/TileStep4";
    FMOD.Studio.EventInstance thunder;

    void Start()
    {
        thunder = FMODUnity.RuntimeManager.CreateInstance(thunderEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(thunder, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    public override IEnumerator CallBack_3()
    {
        MessageManager.instance.InsertMessage("You freed him");
        player.AddKnowledge(untieKnowledge);
        DialogueManager.instance.EndDialogue();
        Destroy(GetComponent<Dialogue_Interactable>());

        //INSERT CODE FOR UNTIEING


        //Enumerator return is mandatory to enable more complex callbacks
        yield return new WaitForSeconds(0.01f);
    }
    public override IEnumerator CallBack_4()
    {
        MessageManager.instance.InsertMessage("You killed him...");
        player.AddKnowledge(killKnowledge);
        DialogueManager.instance.EndDialogue();

        Destroy(GetComponent<Dialogue_Interactable>());
        thunder.start();

        //INSERT CODE FOR DYING


        //Enumerator return is mandatory to enable more complex callbacks
        yield return new WaitForSeconds(0.01f);
    }
}
