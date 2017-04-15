using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float flapPower;
    private Rigidbody2D rb;
    private int score;
    public static bool isDead;
    public GameObject gameOverText;
    public int MaxLifes = 3;
    public int LifesLeft;
    public Text scoreText;

    private Animator anim;


    void Start () {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        isDead = false;
        LifesLeft = MaxLifes;
        anim = GetComponent<Animator>();
	}
	
	
	void Update () {
        bool isFlap = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

        if (isFlap && isDead == false){
            rb.velocity = Vector2.zero;
            Vector2 force = transform.up * flapPower;
            rb.AddForce(force);
            anim.SetTrigger("isFlapping");
            
        }
        else if (isDead) 
            {
                gameOverText.SetActive(true);
                if(isFlap)
                SceneManager.LoadScene(0);
                anim.SetTrigger("isDead");
            }

        }
    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score : " + score.ToString();
    
    }

    public int GetScore()
    {
        return score;
    
    }



    void OnCollisionEnter2D(Collision2D _other) {

        if (_other.gameObject.tag == "Death")
        {
            if(LifesLeft > 0)
                LifesLeft--;
        }
        else

        if(_other.gameObject.tag =="CameraDeath")
        {
            LifesLeft = 0;
        }
        if (LifesLeft == 0)
            isDead = true;


    }


}
