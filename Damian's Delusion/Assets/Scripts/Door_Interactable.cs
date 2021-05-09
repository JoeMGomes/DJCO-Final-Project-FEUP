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

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    override public void Interact()
    {
        base.Interact();

        if (isOpen )
        {
            closeDoor();
        }else if(!isOpen)
        {
            openDoor();
        }

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
            if(isOpen)
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
