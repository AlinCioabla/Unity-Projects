using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float firePower;


    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    void OnCollisionEnter(Collision _other)
    {
        if (_other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
