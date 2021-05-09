using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public Item item;

    public void Use(){
        if (item){
            item.use();
        }
    }

    public void updateinfo(){
        Text displayText = transform.Find("Text").GetComponent<Text>();
        Image sprite = transform.Find("Image").GetComponent<Image>();
        if(item){
            displayText.text = item.ItemMame;
            sprite.sprite = item.icon;
            sprite.color = Color.white;
        }else{
            displayText.text = "";
            sprite.sprite = null;
            sprite.color = Color.clear;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
