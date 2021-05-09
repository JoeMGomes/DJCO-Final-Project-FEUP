using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : ScriptableObject
{   
    
    public string ItemMame;
    public Sprite icon;


    public virtual void use(){
        Debug.Log(ItemMame);
    }
}
