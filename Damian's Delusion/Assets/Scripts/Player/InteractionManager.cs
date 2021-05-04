using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InteractionManager : MonoBehaviour
{

    private Camera cam;
    public Interactable focus = null;
    public float interactionDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.distance <= interactionDistance)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                else
                {
                    RemoveFocus();
                }
                
            }
            else RemoveFocus();
        }

        //if (Input.GetKeyDown(KeyCode.E) && focus != null)
        //{
        //   
        //}
    }


    void OnInteract(InputValue value)
    {
        if(focus != null)
        {
            focus.Interact();
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocus();
            }
            focus = newFocus;

            newFocus.OnFocus();
        }
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocus();
        }
        focus = null;
    }
}
