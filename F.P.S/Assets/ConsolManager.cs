using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsolManager : MonoBehaviour {

    public InputField ConsolWindow;

    public GameObject player, enemey;

	// Use this for initialization
	void Start () {
        ConsolWindow = GetComponent<InputField>();
        ConsolWindow.onEndEdit.AddListener(delegate { ConsolCommand(ConsolWindow.text); });
    }

    public void ConsolCommand(string command)
    {
        switch (command)
        {
            case "spawn player":
                Instantiate(player, new Vector3(-6f, 0f, 0f), Quaternion.identity);
                InGameLog.LogFunc("Execute : " + command);
                break;

            case "spawn enemy":
                Instantiate(enemey, new Vector3(6f, 0f, 0f), Quaternion.identity);
                InGameLog.LogFunc("Execute : " + command);
                break;

            default:
                InGameLog.LogFunc("It's not correct Command");
                break;
        }
    }

        // Update is called once per frame
        void Update () {
		
	}
}