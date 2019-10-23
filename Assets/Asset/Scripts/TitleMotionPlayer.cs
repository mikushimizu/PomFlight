using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMotionPlayer : MonoBehaviour {
    private int counter = 0;
    private Image image;
    public Sprite[] sprites = new Sprite[54];
    float passtime = 0.1f;

    void Start () {
        image = GetComponent<Image>();
	}
	
	void Update () {
        passtime -= Time.deltaTime;
        if (passtime <= 0.0)
        {
            passtime = 0.05f;
            if (counter < sprites.Length)
            {
                image.sprite = sprites[counter];
                counter++;
            }
            
        }
    }
}