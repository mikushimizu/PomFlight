using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour {
    public GameObject letter;
    public GameObject rule;
    private int pCount;
    private int qCount;

    void Start() {
        pCount = 0;
        qCount = 0;
    }

    void Update() {
        ShowLetter();
        ShowRule();
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.Joystick1Button0))
        {
            pCount++;
        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKey(KeyCode.Joystick1Button2))
        {
            qCount++;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.Joystick1Button8))
        {
            Invoke("loadMain1P", 3);
            TransitionMotionPlayer.hide = 1;
        }
    }

    public void pPlus()
    {
        pCount++;
    }

    public void qPlus()
    {
        qCount++;
    }

    void ShowLetter()
    {
        if (pCount % 2 == 1)
        {
            letter.SetActive(true);
        }
        else
        {
            letter.SetActive(false);
        }
    }

    void ShowRule()
    {
        if (qCount % 2 == 1)
        {
            rule.SetActive(true);
        }
        else
        {
            rule.SetActive(false);
        }
    }
    void loadMain()
    {
        SceneManager.LoadScene("Main");
    }
    void loadMain1P()
    {
        SceneManager.LoadScene("Main1P");
    }
}