using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    // Use this for initialization
    public Transform target;
    public GameObject turret;
    public Rocket rocketPrefab;
    public Transform shootingPoint;
    public float fireRate;
    public float changePatrolStateTimer = 4f;



    enum EnemyState { Charge, Patrol }
    private EnemyState currentState;
    private Vector3 patrolDestination;
    

    private Rigidbody rb;
    private NavMeshAgent nav;
    private float fireTimer;
    private Rigidbody turretRb;
    private float timer;


	void Start () {
        currentState = EnemyState.Patrol;
        rb = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        turretRb = turret.GetComponent<Rigidbody>();
        patrolDestination = new Vector3(Random.Range(75, -75), 0f, Random.Range(75, -75));
        timer = 0f;
    }
	
	// Update is called once per frame
	void Update () {
            switch(currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Charge:
                Chase();
                break;
        }
        timer += Time.deltaTime;
        
	}

    void Patrol()
    {
        nav.SetDestination(patrolDestination);
        if (timer >= changePatrolStateTimer)
        {
            patrolDestination = new Vector3(Random.Range(75, -75), 0f, Random.Range(75, -75));
            timer = 0f;

        }

    }

    void Chase()
    {
        nav.SetDestination(target.position);

        Vector3 targetDir = target.transform.position - turret.transform.position ;

        float step = 100 * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);

        turret.transform.rotation = Quaternion.LookRotation(newDir);





        fireTimer += Time.deltaTime;
        if(fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentState = EnemyState.Charge;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = EnemyState.Patrol;
            patrolDestination = transform.position + new Vector3(Random.Range(20f, -20f), 0f, Random.Range(20f, -20f));
        }
        
    }


    void Shoot()
    {
        Rocket currentRocket = Instantiate(rocketPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
        rb = currentRocket.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * currentRocket.firePower, ForceMode.Impulse);
        
    }
    



}
