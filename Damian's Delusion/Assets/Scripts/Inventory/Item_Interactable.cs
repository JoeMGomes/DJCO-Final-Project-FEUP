using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Interactable : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        InventoryController.instance.Add(item);
        DestroyImmediate(base.gameObject);
    }


     public override void OnFocus()
    {
        if (HUDText_gameobject == null)
        {
            HUDText_gameobject = Instantiate(HUDText_prefab, GameObject.FindGameObjectWithTag("Canvas").transform);
            HUDText_gameobject.GetComponent<HUD_Interactable>().setText("Press 'E' to pick up");
        }

    }
}