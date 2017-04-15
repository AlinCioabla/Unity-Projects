using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CannonController : MonoBehaviour {
	public GameObject cannonballPrefab;
	private GameObject shootingPoint;
	private GameObject cannonballInstance;
	public Button FireButton;
    public float power;
    public List<GameObject> ammunitionList;

    public Text WinText;

    public Button RestartButton;
    public Button ExitButton;

	// Use this for initialization
	void Start () {
		shootingPoint = GameObject.FindGameObjectWithTag ("ShootingPoint");
        FireButton.onClick.AddListener(Fire);
        RestartButton.onClick.AddListener(RestartGame);
        ExitButton.onClick.AddListener(ExitGame);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Fire()
	{
        if (Camera.main.GetComponent<CameraManager>().CanShoot )
        {
            cannonballInstance = Instantiate(cannonballPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
            cannonballInstance.GetComponent<Rigidbody2D>().AddForce(cannonballInstance.transform.right * power * Time.deltaTime, ForceMode2D.Impulse);
            Camera.main.GetComponent<CameraManager>().CanShoot = false;
            ammunitionList[ammunitionList.Count - 1].SetActive(false);
            ammunitionList.RemoveAt(ammunitionList.Count - 1);
            if(ammunitionList.Count == 0)
            {
                WinText.text = "Draw !";
            }
        }
	}

    public void ChangePowerWithSlider(float newPower)
    {
        power = newPower;
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
