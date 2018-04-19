using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    [SerializeField] Button startPoint;

    void Start()
    {
        startPoint.Select();
    }

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
