using UnityEngine;
using System.Collections;

public class MovablePipe : MonoBehaviour {

    public Transform leftLimit;
    public Transform resetPoint;
    public float moveSpeed;


    void Start() {

        ChangePosition(transform.position);
    
    }

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
            float y = Random.Range(-0.7f,3f);
            transform.position = new Vector3(_newposition.x, y, _newposition.z);
            
 
    }




}