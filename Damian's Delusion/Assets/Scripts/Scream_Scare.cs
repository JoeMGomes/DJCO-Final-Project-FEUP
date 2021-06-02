using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream_Scare : Interactable
{

    private string startString = "Press 'E' to start dialogue";


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
        playerCamera.Shake(0.7f, 0.2f);
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
