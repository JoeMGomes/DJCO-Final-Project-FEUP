using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Bang_Scream : Interactable
{

    private string startString = "Press 'E' to open";


    private cameraLook playerCamera;

    private void Awake()
    {
        playerCamera = GameObject.Find("Player").GetComponentInChildren<cameraLook>();
        if (playerCamera == null)
            Debug.LogError("Cannot find player in scene.");
    }

    override public void Interact()
    {
        base.Interact();
        Destroy(HUDText_gameobject);
        FMODUnity.RuntimeManager.PlayOneShot("event:/FX/Crazy_Person_On_Cell");
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
