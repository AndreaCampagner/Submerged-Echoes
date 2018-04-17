using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    [SerializeField] string nextLevel;
    [SerializeField] List<string> requiredKeys;
    [SerializeField] List<string> blockingKeys;
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player")
        {
            Bathyscaphe b = Object.FindObjectOfType<Bathyscaphe>();
                if(requiredKeys.TrueForAll(s => b.keys.Contains(s)) && blockingKeys.TrueForAll(s => !b.keys.Contains(s)))
                    Initiate.Fade(nextLevel, Color.black, 1.0f);
            //SceneManager.LoadScene(nextLevel);
        }
	}
}
