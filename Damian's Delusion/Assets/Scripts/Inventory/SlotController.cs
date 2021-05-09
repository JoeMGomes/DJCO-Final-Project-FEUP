using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public Item item;
    public Color activeColor;
    public void Remove()
    {
        if (item)
        {
            InventoryController.instance.Remove(item);
        }
    }

    public void updateinfo()
    {   
        Text displayText = transform.Find("Text").GetComponent<Text>();
        Image sprite = transform.Find("Image").GetComponent<Image>();
        if (item)
        {
            displayText.text = item.ItemName;
            sprite.sprite = item.icon;
            sprite.color = Color.white;
        }
        else
        {
            displayText.text = "";
            sprite.sprite = null;
            sprite.color = Color.clear;
        }
    }

    public void setActive()
    {
        ColorBlock buttonColors = transform.GetComponent<Button>().colors;
        buttonColors.normalColor = activeColor;
        transform.GetComponent<Button>().colors = buttonColors;

    }

    public void setInactive()
    {
        ColorBlock buttonColors = transform.GetComponent<Button>().colors;
        buttonColors.normalColor = Color.white;
        transform.GetComponent<Button>().colors = buttonColors;
    }

}
