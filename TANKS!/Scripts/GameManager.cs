using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Objective objective;
    public static GameManager Instance;
    public Text endGameText;

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        endGameText.text = string.Empty;
    }



    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }

    public void PlayerWon()
    {
        endGameText.text = "You Won!";
        StartCoroutine("RestartGame");
    }

    public void PlayerLost()
    {
        endGameText.text = "You Lost!";
        StartCoroutine("RestartGame");
    }

}
