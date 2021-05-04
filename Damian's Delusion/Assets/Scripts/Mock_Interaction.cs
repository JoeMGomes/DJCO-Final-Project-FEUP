using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mock_Interaction : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Interact()
    {
        Debug.Log("INTERAGIU JOVEM COM HERANÇA");
    }
}
