using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    // Use this for initialization
    public float firePower = 200f;
    public float explosionPower = 10f;
    public float explosionRadius = 3f;
    public GameObject rocketDestroyEffect;
	void Start () {
        Destroy(gameObject, 8f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(rocketDestroyEffect, transform.position, transform.rotation);
        AddExplosion();
        Destroy(gameObject);
    }

    void AddExplosion()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider col in collisions)
        {
            Rigidbody colRb = col.GetComponent<Rigidbody>();
            if(colRb != null)
                colRb.AddExplosionForce(explosionPower, transform.position, explosionRadius);
        }
    }
}
