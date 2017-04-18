using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    private float mouseSensitivity;
    private float turnSpeed;

    public void Init(float _mouseSensitivity, float _turnSpeed)
    {
        mouseSensitivity = _mouseSensitivity;
        turnSpeed = _turnSpeed;
    }

    public void Turn(float _playerInput)
    {
        transform.Rotate(0f,_playerInput * turnSpeed * mouseSensitivity, 0f);
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
