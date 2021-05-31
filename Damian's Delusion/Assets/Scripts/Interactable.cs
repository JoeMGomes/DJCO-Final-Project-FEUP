using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool isInteracting = false;

    public GameObject HUDText_prefab;
    protected GameObject HUDText_gameobject = null;

    public Knowledge acquiredKnowledge;
    public PlayerKnowledge player;

    public void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<PlayerKnowledge>();

            if(player == null)
            {
                Debug.LogError("Player knowledge component missing in interactable: " + gameObject.transform.name + ". Does the scene have a player?");
                Debug.Break();
            }
        }
    }

    public virtual void Interact()
    {
        isInteracting = true;
        player.AddKnowledge(acquiredKnowledge);
    }

    public virtual void OnDefocus()
    {
        isInteracting = false;
        if (HUDText_gameobject != null)
        {
            Destroy(HUDText_gameobject);
        }
    }

    public virtual void OnFocus()
    {
        if (HUDText_gameobject == null)
        {
            HUDText_gameobject = Instantiate(HUDText_prefab, GameObject.FindGameObjectWithTag("Canvas").transform);
            HUDText_gameobject.GetComponent<HUD_Interactable>().setText("Press 'E' to interact");
        }
    }
}
