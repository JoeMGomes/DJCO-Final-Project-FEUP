using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mock_Interaction : Interactable
{

    override public void Interact()
    {
        base.Interact();
    }

    override public void OnFocus()
    {
        if (HUDText_gameobject == null)
        {
            HUDText_gameobject = Instantiate(HUDText_prefab, GameObject.FindGameObjectWithTag("Canvas").transform);
            HUDText_gameobject.GetComponent<HUD_Interactable>().setText("Press 'E' to interact with mock");
        }
    }
    override public void OnDefocus()
    {
        base.OnDefocus();
    }
}
