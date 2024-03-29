﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Text[] heightText = new Text [2];
    public Text[] starScoreText = new Text[2];
    public Text timer;
    public GameObject[] player = new GameObject [2];
    private Player[] playerCs = new Player[2];
    public static float second;
    public static float elapsedTime;
    public static float remainingTime;
    public static bool battleStart;
    public AudioClip fanfare;
    public AudioClip countDown;
    public AudioClip pomu_playing;
    public GameObject ScoreManager;
    private bool isCalledOnce;
    private bool isCalledOnceCountDown;
    private AudioSource audioSource;
    private float timeCountDown;

    void Start () {
        second = 60;
        elapsedTime = 0;
        battleStart = false;
        timeCountDown = 7; //7秒くらい待つ
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(fanfare);
        for (int i = 0; i < player.Length; i++)
        {
            playerCs[i] = player[i].GetComponent<Player>();
        }
    }
	
	void Update () {
        if (!battleStart) //バトル開始前
        {
            if (timeCountDown > 0)
            {
                if(timeCountDown < 4)
                {
                    if (!isCalledOnceCountDown)
                    {
                        isCalledOnceCountDown = true;
                        audioSource.PlayOneShot(countDown);
                    }
                }
                timeCountDown -= Time.deltaTime;
            }
            else
            {
                battleStart = true;
            }
        }
        else //バトル開始
        {
            //バトル開始直後一度だけ実行する
            if (!isCalledOnce)
            {
                isCalledOnce = true;
                audioSource.PlayOneShot(pomu_playing);
            }

            elapsedTime += Time.deltaTime;
            remainingTime = second - elapsedTime;
            timer.text = Mathf.Floor(remainingTime).ToString();

            //距離とスコア表示
            for (int i = 0; i < player.Length; i++)
            {
                heightText[i].text = playerCs[i].Height.ToString() + "M";
                starScoreText[i].text = "★" + playerCs[i].StarScore.ToString();
            }

            //制限時間オーバー
            if (remainingTime < 1)
            {
                SceneManager.LoadScene("Result");
            }
        }
    }
}