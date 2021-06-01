using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : ScriptableObject
{   
    
    public string ItemName = "";
    public Sprite icon;
    public GameObject model;


    public virtual void use(){
        Debug.Log(ItemName); //default action
    }
}
