using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	public void OnStart()
    {
        Initiate.Fade("FirstScene", Color.black,  1.0f);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
