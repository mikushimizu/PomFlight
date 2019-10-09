using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour {
    public Text[] starScoreText = new Text[2];
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        for(int i=0; i<scoreManager.score.Length; i++)
        {
            starScoreText[i].text = scoreManager.score[i].ToString();
        }
    }
}
