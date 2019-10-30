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
            Invoke("loadMain", 3);
            TransitionMotionPlayer.hide = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
        }
    }
    void loadMain()
    {
        SceneManager.LoadScene("Main");
    }
}