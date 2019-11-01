using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
    public GameObject[] player = new GameObject[2];
    private Player[] playerCs = new Player[2];
    public int[] score = new int[2];

    public static ScoreManager Instance
    {
        get; private set;
    }
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start () {
        //DontDestroyObjManager.DontDestroyOnLoad(gameObject);
        //DontDestroyOnLoad(gameObject);
        for (int i = 0; i < player.Length; i++)
        {
            playerCs[i] = player[i].GetComponent<Player>();
            score[i] = 0;
        }
    }
	
	void Update () {
        for (int i = 0; i < player.Length; i++)
        {
            score[i] = playerCs[i].StarScore;
        }
        /*
        if(SceneManager.GetActiveScene().name == "Start")
        {
            Destroy(gameObject);
        }*/
	}
}