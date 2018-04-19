using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    bool paused = false;
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Button startPoint;

    void Start()
    {
        pauseCanvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {        
            Time.timeScale = 1 - Time.timeScale;
            pauseCanvas.enabled = !pauseCanvas.enabled;
            if (pauseCanvas.isActiveAndEnabled)
                startPoint.Select();
            else
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
            //paused = true;
        }
	}

    public void OnMenu()
    {
        SceneManager.LoadScene("StartScene");
        Destroy(this.gameObject);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
