using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{

    public GameObject shootingPoint;
    private Camera camera;
    private float initialSize;
    bool isStarting;
    public float cameraSpeed;
    public float movingSpeed;
    public float focusSize;
    private GameObject CannonBall;

    private Vector3 focusOnEnemyCameraPosition = Vector3.zero;
    private Vector3 focusOnPlayerCameraPosition = Vector3.zero;

    [HideInInspector]public bool playerTurn;

    public float cameraBoundsminX;
    public float cameraBoundsmaxX;

    [HideInInspector]
    public bool CanShoot;

    [HideInInspector]
    public bool gameover;

    public Text WinText;




    // Use this for initialization
    void Start()
    {
        isStarting = true;
        camera = GetComponent<Camera>();
        initialSize = camera.orthographicSize;
        playerTurn = true;
        CanShoot = false;
        gameover = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        CannonBall = GameObject.FindGameObjectWithTag("Ball");
        cameraTransitionToPlayer();
        if (!gameover)
            moveCamera();
        else
        {
            Invoke("cameraTransitionInitialSize",1f);
            displayWinner();
        }
        
    }

    void moveCamera()
    {
        if (CannonBall != null)
        {
            
            Vector3 targetPosition = new Vector3(
                Mathf.Clamp(CannonBall.transform.position.x, cameraBoundsminX, cameraBoundsmaxX), transform.position.y, transform.position.z);
              
            float CannonBallSpeed = CannonBall.GetComponent<Rigidbody2D>().velocity.x; 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Mathf.Abs(CannonBallSpeed));
     
        }
        else
            if(GameObject.FindGameObjectWithTag("EnemyCannon").GetComponent<EnemyCannonController>().numberOfShots == 3)
        {
            gameover = true;
            WinText.text = "Draw !";
        }
        else
            if (!isStarting)
        {
            if (!playerTurn)
            {
                transform.position = Vector3.MoveTowards(transform.position, focusOnEnemyCameraPosition, movingSpeed * Time.deltaTime * 5);
                if (transform.position == focusOnEnemyCameraPosition)
                {
                    EnemyCannonController enemycannon = GameObject.FindGameObjectWithTag("EnemyCannon").GetComponent<EnemyCannonController>();
                    enemycannon.EnemyShoot();
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, focusOnPlayerCameraPosition, movingSpeed * Time.deltaTime * 5);
                if (transform.position == focusOnPlayerCameraPosition)
                {
                    CanShoot = true;
                    EnemyCannonController enemycannon = GameObject.FindGameObjectWithTag("EnemyCannon").GetComponent<EnemyCannonController>();
                    enemycannon.hasShot = false;
                }
            }
        }
    }

    void cameraTransitionToPlayer()
    {
        if (isStarting && camera.orthographicSize > focusSize)
        {
            camera.orthographicSize -= cameraSpeed;
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(shootingPoint.transform.position.x, shootingPoint.transform.position.y, transform.position.z), movingSpeed * Time.deltaTime);
        }
        else
            if (isStarting && camera.orthographicSize <= focusSize)
        {
            isStarting = false;
            GameObject player = GameObject.FindGameObjectWithTag("PlayerCannon");
            GameObject enemy = GameObject.FindGameObjectWithTag("EnemyCannon");

            float cameraOffsetX = Vector3.Distance(player.transform.position, transform.position + new Vector3(0, 0, 10));
            
            focusOnEnemyCameraPosition = new Vector3(enemy.transform.position.x - cameraOffsetX, transform.position.y, transform.position.z);

            focusOnPlayerCameraPosition = transform.position;

            CanShoot = true;


        }
    }

    void cameraTransitionInitialSize()
    {
        if (camera.orthographicSize < initialSize)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, -10), movingSpeed * 5 * Time.deltaTime);
            camera.orthographicSize += cameraSpeed;
        }
    }

    void displayWinner()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("EnemyCannon");
        GameObject player = GameObject.FindGameObjectWithTag("PlayerCannon");
        if (enemy != null && player == null)
            WinText.text = "You Lost !";
        else
        {
            if (enemy == null && player != null)
                WinText.text = "You Win";
        }



        WinText.gameObject.SetActive(true);
    }
}

