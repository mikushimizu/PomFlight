using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour {
    public Text[] heightText = new Text [2];
    public Text[] starScoreText = new Text[2];
    public Text timer;
    public GameObject[] player = new GameObject [2];
    private Player[] playerCs = new Player[2];
    public static float second;
    public static float elapsedTime;
    public static float remainingTime;

    void Start () {
        second = 60;
        elapsedTime = 0;
        for(int i = 0; i < player.Length; i++)
        {
            playerCs[i] = player[i].GetComponent<Player>();
        }
    }
	
	void Update () {
        elapsedTime += Time.deltaTime;
        remainingTime = second - elapsedTime;
        timer.text =Mathf.Floor(remainingTime).ToString();
        for (int i = 0; i < player.Length; i++)
        {
            heightText[i].text = playerCs[i].Height.ToString() + "M";
            starScoreText[i].text = "★" + playerCs[i].StarScore.ToString();
        }
        if (remainingTime < 1)
        {
            SceneManager.LoadScene("Result");
        }
    }
}