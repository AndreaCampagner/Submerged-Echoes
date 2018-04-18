using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ListStringEvent : UnityEvent<List<string>> { }

public class Cthulhu : MonoBehaviour {
    [SerializeField] GameObject eye;
    [SerializeField] List<Vector3> eyePositions;
    [SerializeField] List<string> endText;
    AudioSource audioSource;
    [SerializeField] AudioClip voice;
    bool end = false;

    public ListStringEvent EndEvent;
	
	// Update is called once per frame
	void Update () {
        InventoryManager inventory = Object.FindObjectOfType<InventoryManager>();
        if(!end && inventory.keys.Contains("FirstKey") && inventory.keys.Contains("SecondKey") && inventory.keys.Contains("ThirdKey"))
        {
            foreach (Vector3 pos in eyePositions)
                Instantiate(eye, pos, Quaternion.identity);
            EndEvent.Invoke(endText);
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = voice;
            audioSource.PlayOneShot(voice);
            end = true;
            inventory.OnEnd();
        }
    }
}
