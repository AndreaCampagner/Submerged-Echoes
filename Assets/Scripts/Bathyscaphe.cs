using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bathyscaphe : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] float rotationFactor = 100f;
    [SerializeField] float thrustFactor = 10f;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip levelEnd;

    [SerializeField] ParticleSystem engineFire;
    [SerializeField] ParticleSystem deathExplosion;
    [SerializeField] ParticleSystem success;

    private int keyCount = 0;

    enum State { Alive, Dead, Changing }
    State current = State.Alive;

    // Use this for initialization
    void Start () {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (current == State.Alive)
        {
            Thrust();
            Rotate();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (current == State.Alive)
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    break;
                case "Finish":
                    current = State.Changing;
                    engineFire.Stop();
                    success.Play();
                    audioSource.Stop();
                    audioSource.PlayOneShot(levelEnd);
                    Invoke("LoadNextScene", 1f);
                    break;
                case "Key":
                    collision.gameObject.SetActive(false);
                    keyCount++;
                    audioSource.PlayOneShot(levelEnd);
                    success.Play();
                    break;
                default:
                    current = State.Dead;
                    engineFire.Stop();
                    deathExplosion.Play();
                    audioSource.Stop();
                    audioSource.PlayOneShot(death);
                    Invoke("LoadNextScene", 1f);
                    break;
            }
        }
    }

    private void LoadNextScene()
    {
        if (current == State.Changing)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else if (current == State.Dead)
            SceneManager.LoadScene(0);
        current = State.Alive;
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //Manual control taken
        float rotationThisFrame = rotationFactor * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.forward * rotationThisFrame);
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(-Vector3.forward * rotationThisFrame);

        rigidBody.freezeRotation = false; //Manual control released
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustFactor * Time.deltaTime);
            engineFire.Play();
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(mainEngine);
        }
        else
        {
            engineFire.Stop();
            audioSource.Stop();
        }
    }
}
