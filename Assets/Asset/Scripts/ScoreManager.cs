using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public int[] score = new int[2];

	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
		
	}
}
