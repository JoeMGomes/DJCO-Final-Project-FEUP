using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public float m_Speed = 10.0f;
    public InputMaster controls;
    private Vector2 direction;

    void Awake()
    {
        controls = new InputMaster();
    }

    void Update()
    {
        direction = controls.player.movement.ReadValue<Vector2>();
        m_Rigidbody.velocity = new Vector3(direction.x, 0, direction.y) * m_Speed;
    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }


}
