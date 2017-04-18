using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    public float maxHealth;
    public Slider healthSlider;
    public float currenthealth;
    public float bulletDamage = 2;
    public float rocketDamage = 48;
    private EnemyAI enemyAI;
    private NavMeshAgent nav;
    public GameObject enemyDeathExplosion;

    // Use this for initialization
    void Start()
    {
        currenthealth = maxHealth;
        enemyAI = GetComponent<EnemyAI>();
        nav = GetComponent<NavMeshAgent>();
        healthSlider.value = currenthealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthealth <= 0)
        {
            enemyAI.enabled = false;
            nav.enabled = false;
            Instantiate(enemyDeathExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(bulletDamage);
        }
        else
            if (collision.gameObject.CompareTag("Rocket"))
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
