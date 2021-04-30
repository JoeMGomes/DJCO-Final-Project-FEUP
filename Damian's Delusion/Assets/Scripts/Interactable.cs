using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool isInteracting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Interact()
    {
        Debug.Log("INTERACTED WITH: " + gameObject.name);
        isInteracting = true;
    }

    public void OnDefocus()
    {
        Debug.Log("DEFOCUSED: " + gameObject.name);
        isInteracting = false;
    }

    internal void OnFocus()
    {
        Debug.Log("FOCUDED: " + gameObject.name);
    }
}
