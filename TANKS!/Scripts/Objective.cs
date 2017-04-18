using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour {
    public float countDownTime;
    [SerializeField]
    private RadiusTrigger radiusTrig;
    private bool countDownStarted;

    private void Start()
    {
        countDownStarted = false;
        radiusTrig.InitWithObjective(this);
    }

    public void StartCountDown()
    {
        countDownStarted = true;
    }

    public void StopCountDown()
    {
        countDownStarted = false;
    }

    public void UpdateCountDown()
    {
        if(countDownStarted && countDownTime>0)
        {
            countDownTime -= Time.deltaTime;
            if(countDownTime <= 0)
            {
                GameManager.Instance.PlayerWon();
            }
                
        }
    }

    


}
