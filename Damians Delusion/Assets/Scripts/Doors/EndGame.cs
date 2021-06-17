using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{   
    public TimerController timerController;
    private bool ended = false;
    // Start is called before the first frame update
    void Update(){
        if(this.GetComponent<Door_Interactable>().isOpen && !ended){
            timerController.timeLeft = 0f;
            ended = true;
            timerController.EndGame = true;
        }
    }
}
