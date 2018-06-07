using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VID;

public class VIDSettingsInit : MonoBehaviour 
{

    public string access_token = "";
    public string user_id = "";

	// Use this for initialization
	void Start ()
    {
        VIDPlugin.Initialize(access_token);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
