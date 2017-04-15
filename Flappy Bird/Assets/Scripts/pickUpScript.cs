using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpScript : MonoBehaviour {

    // Use this for initialization
    public float bgMoveSpeed;
    public PlayerController pc;
    public Transform leftLimit;
    public Transform resetPoint;
    public float moveSpeed;
    private int randomOffset;
    void Start () {
        ChangePosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isDead == false)
        {

            transform.position = transform.position - transform.right * moveSpeed * Time.deltaTime;
            if (transform.position.x < leftLimit.position.x)
                ChangePosition(resetPoint.position);

        }
    }
   

    void ChangePosition(Vector3 _newposition)
    {
        float y = Random.Range(-2f, 5f);
        transform.position = new Vector3(_newposition.x, y, _newposition.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            randomOffset = Random.Range(2, 4) * 5;
            transform.position = new Vector3(transform.position.x + randomOffset, transform.position.y, transform.position.z);
            pc.IncrementScore();
            pc.IncrementScore();
            pc.IncrementScore();
        }
    }
}
