using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interactable : Interactable
{

    public bool isOpen = false;
    private Animator anim;

    private string openString = "Press 'E' to open";
    private string closeString = "Press 'E' to close";

    private string closedMessage = "Door is closed, where is the key?";
    private string unlockedMessage = "Door unlocked";

    public Key unlock_Key;
    public bool isLocked = false;

    private void Awake()
    {
        anim = gameObject.GetComponentInParent<Animator>();
    }

    override public void Interact()
    {
        base.Interact();

        if (!isLocked)
        {
            ToggleOpen();
        }
        else
        {
            if (InventoryController.instance.getActiveItem() == unlock_Key)
            {
                Unlock();
                InventoryController.instance.Remove(unlock_Key);
                MessageManager.instance.InsertMessage(unlockedMessage);

                ToggleOpen();
            }
            else
            {
                MessageManager.instance.InsertMessage(closedMessage);
            }
        }

    }

    public void Unlock()
    {
        isLocked = false;
    }

    public void ToggleOpen()
    {
        if (isOpen)
        {
            closeDoor();
        }
        else if (!isOpen)
        {
            openDoor();
        }

        Debug.Log("Door is"+isOpen);

    }

    private void openDoor()
    {

        anim.SetBool("isOpen", true);
        isOpen = true;
        HUDText_gameobject.GetComponent<HUD_Interactable>().setText(closeString);
    }

    private void closeDoor()
    {
        anim.SetBool("isOpen", false);
        isOpen = false;
        HUDText_gameobject.GetComponent<HUD_Interactable>().setText(openString);
    }

    override public void OnFocus()
    {
        if (HUDText_gameobject == null)
        {
            HUDText_gameobject = Instantiate(HUDText_prefab, GameObject.FindGameObjectWithTag("Canvas").transform);
            if (isOpen)
                HUDText_gameobject.GetComponent<HUD_Interactable>().setText(closeString);
            else
                HUDText_gameobject.GetComponent<HUD_Interactable>().setText(openString);
        }
    }
    override public void OnDefocus()
    {
        base.OnDefocus();
    }
}
