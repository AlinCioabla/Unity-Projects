using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonController : MonoBehaviour {


    private bool playerTurn;
    public GameObject cannonballPrefab;
    public GameObject EnemyShootingPoint;
    private GameObject cannonballInstance;
    public float power;
    public Transform TurretPosition;
    private float timeElapsed;

    [HideInInspector]
    public bool hasShot;

    [HideInInspector]
    public int numberOfShots = 0;
    // Use this for initialization
    void Awake () {
        hasShot = false;
        transform.position = new Vector3(Random.Range(3f, 6f), transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void EnemyShoot()
    {
        if (!hasShot)
        {
            RotateTurret();
            Invoke("Shoot", 1.5f);
            hasShot = true;
            
        }


    }

    void Shoot()
    {
        power = Random.Range(5f, 12f);
        cannonballInstance = Instantiate(cannonballPrefab, EnemyShootingPoint.transform.position, EnemyShootingPoint.transform.rotation);
        cannonballInstance.GetComponent<Rigidbody2D>().AddForce(-cannonballInstance.transform.right * power * Time.deltaTime, ForceMode2D.Impulse);
        numberOfShots++;
    }

    void RotateTurret()
    {
        TurretPosition.transform.localEulerAngles = new Vector3(0, 0, Random.Range(30f,47f));
    }
    
}
