using UnityEngine;
using System.Collections;

public class MovableScript : MonoBehaviour {
    public Transform leftLimit;
    public Transform resetPoint;
    public float moveSpeed;

    void Update()
    {
        if (PlayerController.isDead == false)
        {
            transform.position = transform.position - transform.right * moveSpeed * Time.deltaTime;
            if (transform.position.x < leftLimit.position.x)
                transform.position = resetPoint.position;
        }
    }
}
