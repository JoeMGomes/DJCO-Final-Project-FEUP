using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Interactable : Interactable
{
    public Dialogue dialogue;
    private DialogueManager manager;
    private string startString = "Press 'E' to start dialogue";

    private void Awake()
    {
        manager = FindObjectOfType<DialogueManager>();
        if (manager == null) Debug.LogError("Dialogue Manager not found in Scene");
    }

    override public void Interact()
    {
        base.Interact();
        Destroy(HUDText_gameobject);
        manager.StartDialogue(dialogue);
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
