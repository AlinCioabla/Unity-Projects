using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public Sprite[] LifeSprites;
    public Image LifeUI;
    public PlayerController pc;
  
    private void Update()
    {
        LifeUI.sprite = LifeSprites[pc.LifesLeft];
    }

}
