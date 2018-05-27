using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class CubeTransformation : Object_select
{

    private Transform m_Transform;

    void Start()
    {

        m_Transform = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame

    void Update()
    {
        if(obj == 0)
            MoveControl();

    }

    void MoveControl()

    {

        if (Input.GetKey(KeyCode.W))

        {

            m_Transform.Translate(Vector3.forward * 0.1f, Space.Self);

        }

        if (Input.GetKey(KeyCode.S))

        {

            m_Transform.Translate(Vector3.back * 0.1f, Space.Self);

        }

        if (Input.GetKey(KeyCode.A))

        {

            m_Transform.Translate(Vector3.left * 0.1f, Space.Self);

        }

        if (Input.GetKey(KeyCode.D))

        {

            m_Transform.Translate(Vector3.right * 0.1f, Space.Self);

        }

        if (Input.GetKey(KeyCode.Q))

        {

            m_Transform.Rotate(Vector3.up, -1.0f);

        }

        if (Input.GetKey(KeyCode.E))

        {

            m_Transform.Rotate(Vector3.up, 1.0f);

        }

        m_Transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));

        m_Transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y"));

    }

}