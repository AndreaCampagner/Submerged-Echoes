using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShower : MonoBehaviour {

    private Text text;
    [SerializeField] List<string> textToShow;
    private int index = 0;
    [SerializeField] float timeInterval;
    private bool call = true;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponentInChildren<Text>();
        text.text = textToShow[index];
	}
	
	// Update is called once per frame
	void Update () {
        if (call)
        {
            Invoke("ChangeText", timeInterval);
            call = false;
        }
	}

    void ChangeText()
    {
        if (index < textToShow.Count -1)
        {
            index++;
            text.text = textToShow[index];
            call = true;
        }
        else
            text.text = "";
    }
}
