using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoader : MonoBehaviour {
	void Start () {
        Invoke("LoadStart", 3);
        //GameObject scoreManager = GameObject.Find("ScoreManager");
        //Instantiate(scoreManager);
    }
	
	void LoadStart () {
        SceneManager.LoadScene("Start");

    }
}
