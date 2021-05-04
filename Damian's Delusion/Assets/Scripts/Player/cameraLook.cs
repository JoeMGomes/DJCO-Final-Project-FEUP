using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLook : MonoBehaviour
{

    public float sensitivity = 100f;
    public Rigidbody m_Rigidbody;
    public float maxRotationY = 180;
    public float minRotationY = -180;
    private float rotationY;
    private float rotationX;
    public InputMaster controls;

    void Awake()
    {
        controls = new InputMaster();
        controls.player.mouseLook.performed += ctx => rotate(ctx.ReadValue<Vector2>());
    }

    void rotate(Vector2 rotation)
    {   
        rotationY -= rotation.y * Time.deltaTime;
        rotationX += rotation.x * Time.deltaTime;
        //rotate the camera
        //rotationY = Mathf.Clamp(rotationY, minRotationY, maxRotationY);
        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
        //rotate the object
        m_Rigidbody.rotation = Quaternion.Euler(0f, rotationX, 0f);
        
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

    // Update is called once per frame
    /*void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -180f, 180f);

        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
    }*/
}
