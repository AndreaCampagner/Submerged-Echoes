using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathyscaphe : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * 10.0f);
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
            audioSource.Stop();

        if (Input.GetKey(KeyCode.A))
            rigidBody.AddRelativeTorque(Vector3.forward * 0.5f);
        else if (Input.GetKey(KeyCode.D))
            rigidBody.AddRelativeTorque(-Vector3.forward * 0.5f);
    }
}
