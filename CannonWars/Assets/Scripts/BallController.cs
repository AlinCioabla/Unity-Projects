using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public GameObject explosion;
    public Text WinText;
    private GameObject WindSystem;
    
	// Use this for initialization
	void Start () {
        Camera.main.GetComponent<CameraManager>().playerTurn = !Camera.main.GetComponent<CameraManager>().playerTurn;
        WindSystem = GameObject.FindGameObjectWithTag("WindSystem");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Invoke("GenerateNewWind", 0.99f);
            Destroy(gameObject, 1f);
        }
        else

        if (collision.gameObject.CompareTag("EnemyCannon"))
        {
            
            Instantiate(explosion, transform.position, transform.rotation, transform);
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            Camera.main.GetComponent<CameraManager>().gameover = true; 
        }
        else
            if(collision.gameObject.CompareTag("PlayerCannon"))
        {
            Instantiate(explosion, transform.position, transform.rotation, transform);
            collision.gameObject.SetActive(false);
            Camera.main.GetComponent<CameraManager>().gameover = true;
        }
}

    void GenerateNewWind()
    {
        WindSystem.GetComponent<WindSystem>().GenerateWind();
    }
}
