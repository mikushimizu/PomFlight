using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
    public GameObject[] player = new GameObject[2];
    private Player[] playerCs = new Player[2];
    public int[] score = new int[2];

	void Start () {
        DontDestroyObjManager.DontDestroyOnLoad(gameObject);

        for (int i = 0; i < player.Length; i++)
        {
            if(player[i] != null)
            {
                playerCs[i] = player[i].GetComponent<Player>();
                score[i] = 0;
            }
        }
        
    }
	
	void Update () {
        if (GameObject.Find("Player1"))
        {
            player[0] = GameObject.Find("Player1");
        }
        else
        {
            player[0] = null;
        }
        if (GameObject.Find("Player2"))
        {
            player[1] = GameObject.Find("Player2");
        }
        else
        {
            player[1] = null;
        }

        for (int i = 0; i < player.Length; i++)
        {
            if(player[i] != null)
            {
                playerCs[i] = player[i].GetComponent<Player>();
                score[i] = playerCs[i].StarScore;
            }
        }
	}
}