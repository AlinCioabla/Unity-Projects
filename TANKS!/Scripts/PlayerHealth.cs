using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public float maxHealth;
    public Slider healthSlider;
    public float currenthealth;
    public float bulletDamage = 2;
    public float rocketDamage = 48;
    private PlayerController playerController;

	// Use this for initialization
	void Start () {
        currenthealth = maxHealth;
        playerController = GetComponent<PlayerController>();
        healthSlider.value = currenthealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (currenthealth <= 0)
        {
            playerController.enabled = false;
            GameManager.Instance.PlayerLost();

        }

	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(bulletDamage);
        }
        else
            if(collision.gameObject.CompareTag("Rocket"))
        {
            TakeDamage(rocketDamage);
        }
    }

    void TakeDamage(float damage)
    {
        currenthealth -= damage;
        healthSlider.value = currenthealth;
    }
}
