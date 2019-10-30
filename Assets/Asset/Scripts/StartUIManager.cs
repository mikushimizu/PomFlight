using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIManager : MonoBehaviour {
    public GameObject letter;
    public GameObject rule;
    private int pCount;
    private int qCount;
    // Use this for initialization
    void Start() {
        pCount = 0;
        qCount = 0;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log("p:" + pCount + ", q:" + qCount);
        ShowLetter();
        ShowRule();
        if (Input.GetKeyDown(KeyCode.P))
        {
            pCount++;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            qCount++;
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
}