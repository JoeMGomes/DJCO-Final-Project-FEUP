using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Bang_Scream : Interactable
{

    private string doorString = "Press 'E' to open";
    private string deadString = "";
    [FMODUnity.EventRef]
    public string bangScreamEvent = "";
    FMOD.Studio.EventInstance bangScream;

    private cameraLook playerCamera;

    private bool isDead = false;

    private void Awake()
    {
        playerCamera = GameObject.Find("Player").GetComponentInChildren<cameraLook>();
        if (playerCamera == null)
            Debug.LogError("Cannot find player in scene.");
        bangScream = FMODUnity.RuntimeManager.CreateInstance(bangScreamEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(bangScream, GetComponent<Transform>(), GetComponent<Rigidbody>());

    }

    override public void Interact()
    {
        base.Interact();
        if (!isDead)
        {
            Destroy(HUDText_gameobject);
            bangScream.start();
            doorString = deadString;
            isDead = true;
            playerCamera.Shake(0.3f, 0.01f);
        }
    }

    override public void OnFocus()
    {
        if (HUDText_gameobject == null)
        {
            HUDText_gameobject = Instantiate(HUDText_prefab, GameObject.FindGameObjectWithTag("Canvas").transform);
            HUDText_gameobject.GetComponent<HUD_Interactable>().setText(doorString);
        }
    }

    override public void OnDefocus()
    {
        base.OnDefocus();
        InventoryController.instance.CanOpen = true;
    }

}
