using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    public float m_Speed = 10.0f;
    public float gravity = 10.0f;
    public CharacterController controller;

    private Vector2 direction;
    public GameObject pauseMenu;
    public float moveTime = 0.0f;

    private cameraLook playerCam;

    [FMODUnity.EventRef]
    public string step1Event = "event:/Player/Tile_Room_Footsteps/TileStep2";
    FMOD.Studio.EventInstance step1;
    [FMODUnity.EventRef]
    public string step2Event = "event:/Player/Tile_Room_Footsteps/TileStep3";
    FMOD.Studio.EventInstance step2;
    [FMODUnity.EventRef]
    public string step3Event = "event:/Player/Tile_Room_Footsteps/TileStep4";
    FMOD.Studio.EventInstance step3;

    private bool stepSound = false;

    private void Awake()
    {
        playerCam = GameObject.Find("Player").GetComponentInChildren<cameraLook>();
        if(playerCam == null)
        {
            Debug.LogError("Cannot find camera in Player");
        }

        step1 = FMODUnity.RuntimeManager.CreateInstance(step1Event);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(step1, GetComponent<Transform>(), GetComponent<Rigidbody>());

        step2 = FMODUnity.RuntimeManager.CreateInstance(step2Event);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(step2, GetComponent<Transform>(), GetComponent<Rigidbody>());

        step3 = FMODUnity.RuntimeManager.CreateInstance(step3Event);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(step3, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);

        }

        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;
        if (Input.GetKey(KeyCode.W))
        {
            direction.y += 1f;
           up = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y -= 1f;
            down = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1f;
            left = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1f;
            right = true;
        }
            
        if(up || down || left || right)
        {
            moveTime += Time.deltaTime;
            //Esparguetada para tocar sons aleatoreos a cada passo
            if(Mathf.Sin(moveTime * 10)  < -0.95 && !stepSound)
            {
                stepSound = true;
                float stepNumber = Random.Range(0.0f, 3f);
                //Debug.Log(stepNumber);
                if (stepNumber < 1)
                {
                    step1.getPlaybackState(out FMOD.Studio.PLAYBACK_STATE state);
                    if (state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
                    {
                        step2.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                        step3.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                        step1.start();
                    }

                }
                else if (stepNumber < 2)
                {

                    step2.getPlaybackState(out FMOD.Studio.PLAYBACK_STATE state);
                    if (state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
                    {
                        step1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                        step3.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                        step2.start();
                    }
                }
                else
                {

                    step3.getPlaybackState(out FMOD.Studio.PLAYBACK_STATE state);
                    if (state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
                    {
                        step2.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                        step1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                        step3.start();
                    }
                }
            }
            else if (Mathf.Sin(moveTime * 10) > -0.95  && stepSound)
            {
                stepSound = false;
            }
        }
        


        playerCam.CameraBob(moveTime);
        if (direction.magnitude > 1)
        {
            direction = direction.normalized;
        }
        Vector3 move;

        if (controller.isGrounded)
        {
            move = new Vector3(direction.x, 0, direction.y) * m_Speed * Time.deltaTime;
        }
        else
        {
            move = new Vector3(direction.x, -gravity, direction.y) * m_Speed * Time.deltaTime;
        }

        move = this.transform.TransformDirection(move);
        controller.Move(move);

        direction = new Vector2(0f, 0f);
    }



}
