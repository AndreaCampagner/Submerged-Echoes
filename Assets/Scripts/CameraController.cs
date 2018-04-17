using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] public GameObject target;
    [SerializeField] public float depth = -10;
    bool end = false;
    [SerializeField] float shakeStrength = 2;
    Vector3 originalPos;

	// Use this for initialization
	void Start () {
		
	}

    public void EndGame()
    {
        end = true;
		originalPos = new Vector3(target.transform.position.x, target.transform.position.y, depth);
    }
	
	// Update is called once per frame
	void Update () {
        if(!end)
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, depth);
        else
        {
            Vector2 xy = Random.insideUnitCircle*shakeStrength;
            transform.position = originalPos + new Vector3(xy.x, xy.y, 0);
        }
	}
}
