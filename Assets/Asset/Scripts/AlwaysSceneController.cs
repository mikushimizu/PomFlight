using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlwaysSceneController : MonoBehaviour {
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
        }
    }
}