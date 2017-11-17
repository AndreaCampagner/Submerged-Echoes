﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector;
    [SerializeField] float period;

    private Vector3 startingPosition;

	// Use this for initialization
	void Start () {
        startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (period <= Mathf.Epsilon)
            return;

        float cycles = Time.time / period;
        const float tau = 2 * Mathf.PI;
        float movementAlpha = Mathf.Sin(tau * cycles)/2 + 0.5f;

        Vector3 offset = movementVector * movementAlpha;
        transform.position = startingPosition + offset;
	}
}
