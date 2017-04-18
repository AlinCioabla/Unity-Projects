using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmoBoxes : MonoBehaviour {

    // Use this for initialization

    public GunController gunController;
    public CannonController cannonController;
    public int bulletBoxValue = 25;
    public int rocketBoxValue = 5;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletBox"))
        {
            gunController.ChangeBulletCount(bulletBoxValue);
            StartCoroutine(RespawnPowerUp(other));

            
        }
        else
            if (other.CompareTag("RocketBox"))
        {
            cannonController.ChangeRocketCount(rocketBoxValue);
            StartCoroutine(RespawnPowerUp(other));
        }


        }

    private IEnumerator RespawnPowerUp(Collider powerUp)
    {
        powerUp.gameObject.SetActive(false);
        yield return new WaitForSeconds(15);
        powerUp.gameObject.SetActive(true);
    }

    
}


