using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject p1;
    public GameObject p2;
    private Text p1HeightText;
    private Text p2HeightText;

    void Start () {
        p1HeightText = p1.GetComponent<Text>();
        p2HeightText = p2.GetComponent<Text>();
    }
	
	void Update () {
        p1HeightText.text = Player.player1Height.ToString() + " m";
        p2HeightText.text = Player.player2Height.ToString() + " m";
    }
}
