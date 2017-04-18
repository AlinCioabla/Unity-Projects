using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float bodyTurnSpeed;
    [SerializeField]
    private float mouseSensitivity;
    [SerializeField]
    private float cannonMaxTurnY;
    [SerializeField]
    private float cannonMinTurnY;
    [SerializeField]
    private float cannonFireRate = 2f;
    [SerializeField]
    private float turretTurnSpeed;
    [SerializeField]
    private BodyController body;
    [SerializeField]
    private TurretController turret;
    [SerializeField]
    private CannonController cannon;
    [SerializeField]
    private GunController gun;
    [SerializeField]
    private Transform bulletSP;
    [SerializeField]
    private Bullet bulletPrefab;
    [SerializeField]
    private int initialBulletCount = 100;
    [SerializeField]
    private int initialRocketCount = 10;



    private Rigidbody tankRb;
    float gunTimer;
    float cannonTimer;
    private bool isGunShooting;
  
      
    void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        tankRb = GetComponent<Rigidbody>();
        body.Init(bodyTurnSpeed);
        turret.Init(mouseSensitivity,turretTurnSpeed);
        cannon.Init(mouseSensitivity, cannonMinTurnY, cannonMaxTurnY, initialRocketCount);
        gun.InitWithPrefab(bulletPrefab,bulletSP, initialBulletCount);
        isGunShooting = false;
        
	}

    // Update is called once per frame
    
    private void Update()
    {
        cannonTimer += Time.deltaTime;
    }
    
    void FixedUpdate () {
        float mouseXMovement = Input.GetAxis("Mouse X");
        float mouseYMovement = Input.GetAxis("Mouse Y");
        float tankMovement = Input.GetAxis("Horizontal");
        float bodyMovement = Input.GetAxis("Vertical");
        body.Turn(tankMovement);
        turret.Turn(mouseXMovement);
        MoveTank(bodyMovement);
        cannon.Turn(mouseYMovement);



        if(Input.GetButton("Fire1") && cannonTimer >= cannonFireRate && cannon.CanFire())
        {
            cannonTimer = 0f;
            cannon.Fire();
        }

        if (Input.GetButtonDown("Fire2") && gun.currentState != FireMode.Auto)
        {
            gun.Fire();
        }
        else if (Input.GetButton("Fire2") && !isGunShooting && gun.currentState == FireMode.Auto)
        {
            isGunShooting = true;
            gun.Auto();
        }
        else if (Input.GetButtonUp("Fire2") && isGunShooting && gun.currentState == FireMode.Auto)
        {
            isGunShooting = false;
            gun.StopFire();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            gun.ChangeState();
            gun.StopFire();
            isGunShooting = false;
        }




    }

    void MoveTank(float _playerInput)
    {
        Vector3 moveForce = body.bodyForward() * moveSpeed * _playerInput * acceleration;
        tankRb.AddForce(moveForce,ForceMode.Acceleration);
        tankRb.velocity = Vector3.ClampMagnitude(tankRb.velocity, moveSpeed);
    }

}
