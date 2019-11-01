using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionMotionPlayer : MonoBehaviour {
    private int counter = 0;
    private Image image;
    public Sprite[] sprites = new Sprite[55];
    public static int hide; //2のとき画面は隠せている状態, 1のとき隠せていない状態
    float passtime = 0.1f;

    void Start () {
        image = GetComponent<Image>();
        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                hide = 0;
                break;

            case "Main":
                hide = 2;
                break;

            case "Main1P":
                hide = 2;
                break;

            case "Result":
                hide = 2;
                break;
        }
        
	}
	
	void Update () {
        switch (hide)
        {
            case 0:
                break;

            case 1:
                FeedIn();
                break;

            case 2:
                FeedOut();
                break;
        }
    }

    void FeedIn()
    {
        passtime -= Time.deltaTime;
        if (passtime <= 0.0)
        {
            passtime = 0.05f;
            if (counter < sprites.Length / 2)
            {
                image.sprite = sprites[counter];
                counter++;
            }

        }
    }

    void FeedOut()
    {
        passtime -= Time.deltaTime;
        if (passtime <= 0.0)
        {
            passtime = 0.05f;
            if (counter < sprites.Length)
            {
                image.sprite = sprites[counter + sprites.Length/2];
                counter++;
            }
        }
    }
}