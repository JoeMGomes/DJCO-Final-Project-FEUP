using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodePanel : MonoBehaviour
{
   public TextMeshProUGUI codeText;

   public GameObject Box;

   public SafeInteractable safe;

    public playerMovement mov;
    public cameraLook cam;

   string codeTextValue = "";

    // Update is called once per frame

    public void Begin() {
        // stop player movement
        mov.enabled = false;
        cam.enabled = false;

        // enable mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Box.SetActive(true);
    }


    void Update()
    {
        codeText.text = codeTextValue;

        
    }

    public void AddDigit(string digit) {
        codeTextValue += digit;
    }

    public void Clear() {
        codeTextValue = "";
    }

    public void Enter() {
        if(codeTextValue == safe.unlockCode) {
            Debug.Log("Correct");
            safe.Open();
        }else{
            safe.Fail();
        }
        End();
    }

    public void End()
    {
        Clear();
        mov.enabled = true;
        cam.enabled = true;

        // disable mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Box.SetActive(false);
    }
}
