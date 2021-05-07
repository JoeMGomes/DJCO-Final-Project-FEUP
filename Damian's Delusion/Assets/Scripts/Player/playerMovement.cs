using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float m_Speed = 10.0f;
    public CharacterController controller;

    private Vector2 direction;


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direction.y += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y -= 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1f;
        }

        if (direction.magnitude > 1){
            direction = direction.normalized;
        }
        Vector3 move = new Vector3(direction.x, 0, direction.y) * m_Speed * Time.deltaTime;
        move = this.transform.TransformDirection(move);
        controller.Move(move);

        direction = new Vector2(0f, 0f);
    }



}
