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

    enum State { Alive, Dead, Changing }
    State current = State.Alive;
    public List<string> keys;
    bool engine = false;

    // Use this for initialization
    void Start () {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
        InventoryManager inventory = Object.FindObjectOfType<InventoryManager>();
        keys = inventory.keys;
    }
	
	// Update is called once per frame
	void Update () {
        if (current == State.Alive)
        {
            Thrust();
            Rotate();
        }
    }

    public void EndGame()
    {
        current = State.Dead;
		rigidBody.useGravity = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (current == State.Alive)
        {
            InventoryManager inventory = Object.FindObjectOfType<InventoryManager>();
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
                    Key k = collision.gameObject.GetComponent<Key>();
                    inventory.keys.Add(k.keyName);
                    keys.Add(k.keyName);
                    audioSource.PlayOneShot(levelEnd);
                    success.Play();
                    if (inventory.keys.Contains("ExtraKey") && !k.keyName.Equals("ExtraKey"))
                        Initiate.Fade("Cave", Color.black, 1.0f);
                    break;
                default:
                    current = State.Dead;
                    engineFire.Stop();
                    deathExplosion.Play();
                    audioSource.Stop();
                    audioSource.PlayOneShot(death);
                    if (inventory.keys.Contains("ExtraKey"))
                    {
                        Initiate.Fade("Cave", Color.black, 1.0f);
                    }
                    else
                    {
                        Initiate.Fade("FirstScene", Color.black, 1.0f);
                        inventory.keys.Clear();
                    }
                    break;
            }
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //Manual control taken
        float rotationThisFrame = rotationFactor * Time.deltaTime;

        float value = Input.GetAxis("Horizontal");

        if (value < 0)
            transform.Rotate(Vector3.forward * rotationThisFrame);
        else if (value > 0)
            transform.Rotate(-Vector3.forward * rotationThisFrame);

        rigidBody.freezeRotation = false; //Manual control released
    }

    private void Thrust()
    {
        if (Input.GetButton("Jump"))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustFactor * Time.deltaTime);
            if (!engine)
            {
                engineFire.Play();
                engine = true;
            }
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(mainEngine);
        }
        else
        {
            engineFire.Stop();
            audioSource.Stop();
            engine = false;
        }
    }
}
