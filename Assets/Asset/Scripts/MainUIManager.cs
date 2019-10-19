using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour {
    public Text[] heightText = new Text [2];
    public Text[] starScoreText = new Text[2];
    public Text timer;
    public GameObject[] player = new GameObject [2];
    private Player[] playerCs = new Player[2];
    public static float second;

    void Start () {
        second = 3660;
        for(int i = 0; i < player.Length; i++)
        {
            playerCs[i] = player[i].GetComponent<Player>();
        }
    }
	
	void Update () {
        timer.text =Mathf.Floor(second/60).ToString();
        second--;
        for (int i = 0; i < player.Length; i++)
        {
            heightText[i].text = playerCs[i].Height.ToString() + " m";
            starScoreText[i].text = playerCs[i].StarScore.ToString() + " 個";
        }
    }
}