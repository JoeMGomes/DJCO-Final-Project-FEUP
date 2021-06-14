using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream_Scare : Interactable
{

    private string startString = "Press 'E' to start dialogue";
    private string deadString = "";
    [FMODUnity.EventRef]
    public string screamEvent = "";
    FMOD.Studio.EventInstance scream;

    private cameraLook playerCamera;
    private bool isDead = false;

    private void Awake()
    {
        playerCamera = GameObject.Find("Player").GetComponentInChildren<cameraLook>();
        if (playerCamera == null)
            Debug.LogError("Cannot find player in scene.");

        scream = FMODUnity.RuntimeManager.CreateInstance(screamEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(scream, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    override public void Interact()
    {
        base.Interact();
        Destroy(HUDText_gameobject);
        if (!isDead)
        {
            Destroy(HUDText_gameobject);
            scream.start();
            startString = deadString;
            isDead = true;
            playerCamera.Shake(0.9f, 0.01f);
        }
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
