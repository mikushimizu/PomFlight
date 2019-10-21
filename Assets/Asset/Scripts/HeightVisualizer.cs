using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightVisualizer : MonoBehaviour {
    private Slider slider;
    public GameObject player;
    public GameObject handleSlideArea;
    private float skyHeight;
    private RectTransform rect;
    void Start()
    {
        slider = GetComponent<Slider>();
        rect = handleSlideArea.GetComponent<RectTransform>();
    }

    void Update()
    {
        slider.value = player.GetComponent<Player>().Height;
        if(player.transform.position.x < 0) //左側にいたら左に表示
        {
            rect.offsetMin = new Vector2(10, 0);
            rect.offsetMax = new Vector2(10, 0);
        }
        else //右側にいたら右に表示
        {
            rect.offsetMin = new Vector2(10, -15);
            rect.offsetMax = new Vector2(10, -15);
        }
    }
}