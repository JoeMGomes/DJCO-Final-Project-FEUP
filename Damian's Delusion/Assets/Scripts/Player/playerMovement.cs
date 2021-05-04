using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float m_Speed = 10.0f;
    public CharacterController controller;
    public InputMaster controls;
    private Vector2 direction;

    void Awake()
    {
        controls = new InputMaster();
    }

    void Update()
    {
        direction = controls.player.movement.ReadValue<Vector2>();
        Vector3 move = new Vector3(direction.x, 0, direction.y) * m_Speed * Time.deltaTime;
        move = this.transform.TransformDirection(move);
        controller.Move(move);
    }

    void Start()
    {
    }

    private void OnEnable()
    {
        controls.Enable();
    }


}
