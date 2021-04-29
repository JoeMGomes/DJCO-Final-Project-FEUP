using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLook : MonoBehaviour
{

    public float sensitivity = 100f;
    private Rigidbody m_Rigidbody;
    private float rotationY;
    private float rotationX;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -180f, 180f);

        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
