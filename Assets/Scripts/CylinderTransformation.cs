using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderTransformation : Object_orders
{

    //float transformation_speed = 0.05f;
    //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
    //bool direction = true;
    // Use this for initialization
    void Start () {
        //watch.Start();//开始计时
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.S))
        {
            Object_orders.Operationminus();
            Debug.Log(Object_orders.operation);
        }
    }
}
