using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD_Message : MonoBehaviour
{

    private TextMeshProUGUI textObject;

    private void Awake()
    {
        textObject = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        if (textObject == null)
        {
            Debug.LogError("Could not get TextMeshProUGUI Object in children ");
        }
    }

    public void SetText(string message)
    {
        textObject.text = message;
    }

}
