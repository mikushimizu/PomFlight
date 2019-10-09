using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadResultScene : MonoBehaviour {
	void Update () {
        if (MainUIManager.second < 0)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
