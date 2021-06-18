using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{

    public GameObject hand;
    // Update is called once per frame
    public void UpdateItemModel(GameObject newModel)
    {
        GameObject Item;
        if(newModel == null){
            Item = Instantiate(hand, new Vector3(0, 0, 10), Quaternion.identity);
        }else{
            Item = Instantiate(newModel, new Vector3(0, 0, 10), Quaternion.identity) as GameObject;
        }
        GameObject child = transform.Find("Main Camera/Item").gameObject;
        Item.transform.position = child.transform.position;
        Item.transform.rotation = child.transform.rotation;
        Item.transform.parent = child.transform.parent;
        Item.name = "Item";
        DestroyImmediate(child);
    }
}
