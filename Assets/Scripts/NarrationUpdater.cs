using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationUpdater : MonoBehaviour {

    private bool activated = false;
    [SerializeField] List<string> text;
    [SerializeField] TextShower narrator;

    void Awake()
    {
        narrator = Object.FindObjectOfType<TextShower>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == "Player" && !activated)
        {
            print("Hello!");
            activated = true;
            narrator.AddText(text);
        }
	}
}
