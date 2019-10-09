using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public GameObject[] player = new GameObject[2];
    private Player[] playerCs = new Player[2];
    public int[] score = new int[2];

	void Start () {
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < player.Length; i++)
        {
            playerCs[i] = player[i].GetComponent<Player>();
        }
    }
	
	void Update () {
        for (int i = 0; i < player.Length; i++)
        {
            score[i] = playerCs[i].StarScore;
        }
	}
}