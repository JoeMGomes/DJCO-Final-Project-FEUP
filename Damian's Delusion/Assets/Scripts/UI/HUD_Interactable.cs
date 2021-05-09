using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD_Interactable : MonoBehaviour
{

    public TextMeshProUGUI textObject;

    private void Awake()
    {
       textObject =  gameObject.GetComponentInChildren<TextMeshProUGUI>();
        if(textObject == null)
        {
            Debug.LogError("Could not get TextMeshProUGUI Object in children ");
        }
    }

    public void setText(string text)
    {
        textObject.text = text;
    }

    public string getText(string text)
    {
        return textObject.text;
    }

}
