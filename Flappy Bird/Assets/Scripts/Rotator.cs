using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public float rotateSpeed;
	// Use this for initialization
	void Start () {
        rotateSpeed = 70f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, rotateSpeed, 0f) * Time.deltaTime);
	}
}
