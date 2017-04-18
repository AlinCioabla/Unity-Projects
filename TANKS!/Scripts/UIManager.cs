using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    
    [SerializeField]
    private Text countDown;

    void Update()
    {
        DateTime seconds = new DateTime((long) GameManager.Instance.objective.countDownTime * TimeSpan.TicksPerSecond);
        countDown.text = seconds.ToString("mm:ss");
    }
	
}
