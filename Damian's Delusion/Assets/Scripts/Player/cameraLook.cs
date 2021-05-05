using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLook : MonoBehaviour
{

    public float sensitivity = 1000f;
    public float acceleration = 1000f;
    public float inputLagPeriod = 0.004f;
    public float maxRotationY = 90f;
    public float minRotationY = -90f;
    private Vector2 velocity; // The current rotation velocity, in degrees
    private Vector2 rotation; // The current rotation, in degrees
    private Vector2 lastInputEvent; // The last received non-zero input value
    private float inputLagTimer; // The time since the last received non-zero input value
    public Transform playerBody;
    public InputMaster controls;


    void Awake()
    {
        controls = new InputMaster();
    }

    private Vector2 GetInput()
    {
        // Add to the lag timer
        inputLagTimer += Time.deltaTime;
        // Get the input vector. This can be changed to work with the new input system or even touch controls
        Vector2 input = new Vector2(
            controls.player.mouseLookX.ReadValue<float>(),
            -controls.player.mouseLookY.ReadValue<float>()
        );

        // Sometimes at fast framerates, Unity will not receive input events every frame, which results
        // in zero values being given above. This can cause stuttering and make it difficult to fine
        // tune the acceleration setting. To fix this, disregard zero values. If the lag timer has passed the
        // lag period, we can assume that the user is not giving any input, so we actually want to set
        // the input value to zero at that time.
        // Thus, save the input value if it is non-zero or the lag timer is met
        if ((Mathf.Approximately(0, input.x) && Mathf.Approximately(0, input.y)) == false || inputLagTimer >= inputLagPeriod)
        {
            lastInputEvent = input;
            inputLagTimer = 0;
        }
        return lastInputEvent;
    }
    private void Update()
    {
        // The wanted velocity is the current input scaled by the sensitivity
        // This is also the maximum velocity
        Vector2 wantedVelocity = GetInput() * sensitivity;

        // Calculate new rotation
        velocity = new Vector2(
            Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration * Time.deltaTime),
            Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration * Time.deltaTime));
        rotation += velocity * Time.deltaTime;

        // Convert the rotation to euler angles
        rotation.y = Mathf.Clamp(rotation.y, minRotationY, maxRotationY);
        transform.localEulerAngles = new Vector3(rotation.y, 0f, 0f);
        playerBody.transform.localEulerAngles = new Vector3(0f, rotation.x, 0f);
    }



    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
