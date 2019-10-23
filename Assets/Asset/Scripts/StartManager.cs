using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if ((StartBar.isAble[0] && StartBar.isAble[1]) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
