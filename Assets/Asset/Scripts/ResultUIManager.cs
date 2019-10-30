using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour {
    public Text[] starScoreText = new Text[2];
    public Image[] pomumiImage = new Image[2];
    public Sprite pomumiExcellent;
    public Sprite pomumiVeryGood;
    public Sprite pomumiGood;
    public Sprite pomumiBad;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        for(int i=0; i<scoreManager.score.Length; i++)
        {
            starScoreText[i].text = "★" + scoreManager.score[i].ToString() + "コ";
            if(scoreManager.score[i] < 10)
            {
                pomumiImage[i].sprite = pomumiBad;
            }else if(10 < scoreManager.score[i] && scoreManager.score[i] < 15)
            {
                pomumiImage[i].sprite = pomumiGood;
            }
            else if (15 < scoreManager.score[i] && scoreManager.score[i] < 20)
            {
                pomumiImage[i].sprite = pomumiVeryGood;
            }
            else
            {
                pomumiImage[i].sprite = pomumiExcellent;
            }
        }
    }
}
