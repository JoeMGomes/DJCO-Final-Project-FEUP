using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick_Bed : Interactable
{

    private string startString = "Press 'E' to start dialogue";
    private string deadString = "";
    public Item lockpick;

    private void Awake()
    {

    }

    override public void Interact()
    {
        base.Interact();
        InventoryController.instance.Add(lockpick);
        DestroyImmediate(HUDText_gameobject);
        DestroyImmediate(this);
    }

    override public void OnFocus()
    {
        if (HUDText_gameobject == null)
        {
            HUDText_gameobject = Instantiate(HUDText_prefab, GameObject.FindGameObjectWithTag("Canvas").transform);
            HUDText_gameobject.GetComponent<HUD_Interactable>().setText("Press 'E' rip metal rod from bed");
        }
    }

    override public void OnDefocus()
    {
        base.OnDefocus();
    }
}
