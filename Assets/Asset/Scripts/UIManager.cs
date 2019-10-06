using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text[] heightText = new Text [2];
    public Text[] starScoreText = new Text[2];
    public GameObject[] player = new GameObject [2];
    private Player[] playerCs = new Player[2];

    void Start () {
        for(int i = 0; i < player.Length; i++)
        {
            playerCs[i] = player[i].GetComponent<Player>();
        }
    }
	
	void Update () {
        for (int i = 0; i < player.Length; i++)
        {
            heightText[i].text = playerCs[i].Height.ToString() + " m";
            starScoreText[i].text = playerCs[i].StarScore.ToString() + " 個";
        }
    }
}