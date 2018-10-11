using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameLog : MonoBehaviour {

    public static InGameLog inGameLog;
    public static Text Log;

	// Use this for initialization
	void Start () {
        inGameLog = this;
        Log = GetComponent<Text>();
    }


    //InGameLog.LogFunc(" ");

    public static void LogFunc(string _string)
    {
        Log.text = _string;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
