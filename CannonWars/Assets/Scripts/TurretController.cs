using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeAngleWithSlider(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
