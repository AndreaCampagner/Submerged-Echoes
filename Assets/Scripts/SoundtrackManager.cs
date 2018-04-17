using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour {
    [SerializeField] AudioClip soundtrack;
    AudioSource audioSource;

    // Use this for initialization
    void Awake () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = soundtrack;
        audioSource.Play();
    }
}
