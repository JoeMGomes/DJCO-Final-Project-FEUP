using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLook : MonoBehaviour
{

    public float sensitivity = 100f;
    public float maxRotationY = 90f;
    public float minRotationY = -90f;
    private float rotationY;
    private float rotationX;
    public Transform playerBody;
    public InputMaster controls;

    void Awake()
    {
        controls = new InputMaster();
        controls.player.mouseLook.performed += ctx => rotate(ctx.ReadValue<Vector2>());
    }

    void rotate(Vector2 rotation)
    {   
        rotationY -= rotation.y * sensitivity * Time.deltaTime;
        rotationX = rotation.x * sensitivity * Time.deltaTime;
        //rotate the camera
        rotationY = Mathf.Clamp(rotationY, minRotationY, maxRotationY);
        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
        //rotate the object
        playerBody.Rotate(Vector3.up * rotationX);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
