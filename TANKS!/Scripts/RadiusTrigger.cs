using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusTrigger : MonoBehaviour {


    private Objective objective;

    public void InitWithObjective(Objective _obj)
    {
        objective = _obj;
    }
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            objective.StartCountDown();
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            objective.UpdateCountDown();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            objective.StopCountDown();
        }
    }

}
