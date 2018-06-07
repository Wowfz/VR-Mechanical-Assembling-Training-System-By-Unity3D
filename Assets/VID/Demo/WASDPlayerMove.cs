using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDPlayerMove : MonoBehaviour
{
    public int stepSpeed = 10;
    public int lookAroundSpeed = 150;

    private Rigidbody _rigidBody;

	// Use this for initialization
    void Start ()
    {
        _rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    void Update ()
    {
        _rigidBody.MovePosition(transform.position + (transform.forward * Input.GetAxis ("Vertical") * Time.deltaTime * stepSpeed));
        _rigidBody.transform.Rotate (0, Input.GetAxis ("Horizontal") * Time.deltaTime * lookAroundSpeed, 0);
    }
}
