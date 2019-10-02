using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    //もうちょっとprivateで書けるように直す あとで
    public GameObject p1;
    public GameObject p2;
    public GameObject player1;
    public GameObject player2;
    private Text p1HeightText;
    private Text p2HeightText;
    Player player1cs;
    Player player2cs;

    void Start () {
        p1HeightText = p1.GetComponent<Text>();
        p2HeightText = p2.GetComponent<Text>();
        player1cs = player1.GetComponent<Player>();
        player2cs = player2.GetComponent<Player>();
    }
	
	void Update () {
        p1HeightText.text = player1cs.Height.ToString() + " m";
        p2HeightText.text = player2cs.Height.ToString() + " m";
    }
}
