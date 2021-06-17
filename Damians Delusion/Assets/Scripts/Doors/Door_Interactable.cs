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


    [FMODUnity.EventRef]
    public string doorOpenEvent = "event:/FX/Door/Metal_Door_Opening";
    FMOD.Studio.EventInstance doorOpenSound;
    [FMODUnity.EventRef]
    public string doorCloseEvent = "event:/FX/Door/Metal_Door_Cloosing";
    FMOD.Studio.EventInstance doorCloseSound;
    [FMODUnity.EventRef]
    public string doorUnlockEvent = "event:/FX/Door/Unblock_Door";
    FMOD.Studio.EventInstance doorUnlockSound;
    [FMODUnity.EventRef]
    public string doorRussleEvent = "event:/FX/Door/Metal_Door_Russling";
    FMOD.Studio.EventInstance doorRussleSound;
    // 
    private void Awake()
    {
        anim = gameObject.GetComponentInParent<Animator>();

        doorOpenSound = FMODUnity.RuntimeManager.CreateInstance(doorOpenEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(doorOpenSound, GetComponent<Transform>(), GetComponent<Rigidbody>());

        doorCloseSound = FMODUnity.RuntimeManager.CreateInstance(doorCloseEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(doorCloseSound, GetComponent<Transform>(), GetComponent<Rigidbody>());

        doorUnlockSound = FMODUnity.RuntimeManager.CreateInstance(doorUnlockEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(doorUnlockSound, GetComponent<Transform>(), GetComponent<Rigidbody>());

        doorRussleSound = FMODUnity.RuntimeManager.CreateInstance(doorRussleEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(doorRussleSound, GetComponent<Transform>(), GetComponent<Rigidbody>());
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
                doorUnlockSound.start();
                InventoryController.instance.Remove(unlock_Key);
                MessageManager.instance.InsertMessage(unlockedMessage);

                ToggleOpen();
            }
            else
            {
                doorRussleSound.start();
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
    }

    private void openDoor()
    {

        anim.SetBool("isOpen", true);
        doorOpenSound.start();
        isOpen = true;
        HUDText_gameobject.GetComponent<HUD_Interactable>().setText(closeString);
    }

    private void closeDoor()
    {
        anim.SetBool("isOpen", false);
        isOpen = false;
        doorCloseSound.start();
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
