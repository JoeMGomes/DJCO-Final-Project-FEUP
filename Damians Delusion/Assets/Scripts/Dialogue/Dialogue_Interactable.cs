using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Interactable : Interactable
{
    public Dialogue dialogue;
    private DialogueManager manager;
    private string startString = "Press 'E' to start dialogue";

    [FMODUnity.EventRef]
    public string talkEvent = "";
    FMOD.Studio.EventInstance talk;

    private void Awake()
    {
        manager = FindObjectOfType<DialogueManager>();
        if (manager == null) Debug.LogError("Dialogue Manager not found in Scene");

        if (talkEvent != "")
        {
            talk = FMODUnity.RuntimeManager.CreateInstance(talkEvent);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(talk, GetComponent<Transform>(), GetComponent<Rigidbody>());
        }
    }

    override public void Interact()
    {
        base.Interact();
        Destroy(HUDText_gameobject);
        manager.StartDialogue(dialogue);
        if(talkEvent != "")
            talk.start();
    }

    override public void OnFocus()
    {
        if (HUDText_gameobject == null)
        {
            HUDText_gameobject = Instantiate(HUDText_prefab, GameObject.FindGameObjectWithTag("Canvas").transform);
            HUDText_gameobject.GetComponent<HUD_Interactable>().setText(startString);
        }
    }

    override public void OnDefocus()
    {
        base.OnDefocus();
        InventoryController.instance.CanOpen = true;
    }
}
