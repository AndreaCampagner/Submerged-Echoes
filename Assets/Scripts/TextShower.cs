using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextShower : MonoBehaviour {

    private Text text;
    [SerializeField] List<string> textToShow;
    private int index = -1;
    [SerializeField] float timeInterval;
    private bool call = true;
    [SerializeField] bool end = false;
    [SerializeField] bool finish = false;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponentInChildren<Text>();
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
        if (index < textToShow.Count - 1)
        {
            index++;
            text.text = textToShow[index];

        }
        else
        {
            text.text = "";
            if(end)
                Initiate.Fade("EndScene", Color.black, 1.0f);
            if (finish)
                Initiate.Fade("StartScene", Color.black, 1.0f);
        }
        call = true;
    }

    public void AddText(List<string> newText)
    {
        textToShow.AddRange(newText);
    }

    public void EndGame(List<string> endText)
    {
        textToShow = endText;
        end = true;
    }

}
