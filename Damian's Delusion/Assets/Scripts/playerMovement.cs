using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public float m_Speed = 10.0f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = transform.forward * m_Speed;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = -transform.forward * m_Speed;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the sprite about the Y axis in the positive direction
            m_Rigidbody.velocity = transform.right * m_Speed;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Y axis in the negative direction
            m_Rigidbody.velocity = -transform.right * m_Speed;
        }
        else{
            m_Rigidbody.velocity = new Vector3(0,0,0);
        }
    }
}
