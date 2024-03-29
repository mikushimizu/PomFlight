﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlwaysSceneController : MonoBehaviour {
    private void Start()
    {
        //DontDestroyObjManager.DontDestroyOnLoad(gameObject);
        //DontDestroyOnLoad(gameObject);
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button9))
        {
            Invoke("loadMain", 3);
            TransitionMotionPlayer.hide = 1;
            //SceneManager.LoadScene("Main");
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKey(KeyCode.Joystick1Button12))
        {
            SceneManager.LoadScene("Start");
        }
    }
    
    void loadMain()
    {
        if (GameObject.Find("ScoreManager(Clone)")){
            Debug.Log("Destroy ScoreManager");
            GameObject scoreManager = GameObject.Find("ScoreManager(Clone)");
            Destroy(scoreManager.gameObject);
        }
        
        SceneManager.LoadScene("Main");
    }
}