using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Object_sel
{
    cube,
    cylinder,
    sphere
}

public class Object_select : MonoBehaviour {


    public static Object_sel obj = 0;


    public static void obj_select()
    {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            obj = 0;
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            obj = 0;
            for(int i =0;i<1;i++)
                obj++;
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            obj = 0;
            for (int i = 0; i < 2; i++)
                obj++;
        }

    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        obj_select();
	}
}
