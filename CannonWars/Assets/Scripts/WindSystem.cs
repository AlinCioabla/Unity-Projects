using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindSystem : MonoBehaviour {

    // Use this for initialization

    public float MinWind;
    public float MaxWind;

    private float Wind;
    private int WindDirection;

    public Text WindText;

    private GameObject Ball;

    void Start () {
        GenerateWind();
	}
	
	// Update is called once per frame
	void Update () {

        Ball = GameObject.FindGameObjectWithTag("Ball");

        if (WindDirection == 0)
                WindText.text = "No Wind";
            else
            if (WindDirection == 1)
                WindText.text = Wind.ToString("0") + " --> ";
            else
                WindText.text = Wind.ToString("0") + " <-- ";

            if (WindDirection != 0 && Ball != null)
            {
                Rigidbody2D ballrb = Ball.GetComponent<Rigidbody2D>();
                ballrb.AddForce(new Vector2(Wind * WindDirection, 0f) * Time.deltaTime);
            }  
    }

    public void GenerateWind()
    {
        Wind = Random.Range(MinWind, MaxWind);
        WindDirection = Random.Range(-1, 2);
    }
}
