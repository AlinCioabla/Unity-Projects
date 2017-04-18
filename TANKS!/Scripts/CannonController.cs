using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour {

    private float mouseSensitivity, cannonMinTurnY, cannonMaxTurnY;
    private float angle;
    public Transform shootingPoint;
    public Rocket rocketPrefab;
    public GameObject shootExplosion;
    public Text rocketCount;

    private int initialRocketCount;

    public void Init(float _mouseSensitivity, float _cannonMinTurnY, float _cannonMaxTurnY, int _initialRocketCount)
    {
        cannonMaxTurnY = _cannonMaxTurnY;
        cannonMinTurnY = _cannonMinTurnY;
        mouseSensitivity = _mouseSensitivity;
        initialRocketCount = _initialRocketCount;
        UpdateText();
    }

    public void Turn(float _playerInput)
    {
        angle += _playerInput * mouseSensitivity;
        angle = Mathf.Clamp(angle, cannonMinTurnY, cannonMaxTurnY);
        transform.localEulerAngles = new Vector3(angle, 0f, 0f);
    }

	// Use this for initialization
	void Start () {
        angle = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire()
    {
        
        Rocket currentRocket =  Instantiate(rocketPrefab, shootingPoint.transform.position,transform.rotation);
        Vector3 force = -transform.forward * currentRocket.firePower;
        currentRocket.GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
        Instantiate(shootExplosion, shootingPoint.transform.position, transform.rotation);
        ChangeRocketCount(-1);

    }

    void UpdateText()
    {
        rocketCount.text = " x " + initialRocketCount.ToString();
    }

    public void ChangeRocketCount(int rocketAmount)
    {
        initialRocketCount += rocketAmount;
        UpdateText();
    }

    public bool CanFire()
    {
        return initialRocketCount > 0;
    }
}
