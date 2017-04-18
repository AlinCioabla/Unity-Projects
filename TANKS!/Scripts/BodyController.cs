using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour {

    private float turnSpeed;

    // Use this for initialization
    public void Init(float _turnSpeed)
    {
        turnSpeed = _turnSpeed;
    }

    public void Turn(float _playerInput)
    {
        transform.Rotate(0f, _playerInput * turnSpeed, 0f);
        
    } 

    public Vector3 bodyForward()
    {
        return -transform.forward;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
