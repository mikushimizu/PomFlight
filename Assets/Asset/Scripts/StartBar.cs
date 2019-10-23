using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class StartBar : MonoBehaviour {
    private Slider slider;
    private int[] count = new int [2];
    public static bool[] isAble = new bool[2];

    void Start () {
        slider = GetComponent<Slider>();
        for(int i=0; i<count.Length; i++) {
            count[i] = 0;
            isAble[i] = false;
        }
	}
	
	void Update () {
        switch (gameObject.name)
        {
            case "StartBar1":
                count[0] = JoyconReader.v_count[0];
                slider.value = count[0];
                if (slider.value >= slider.maxValue)
                {
                    isAble[0] = true;
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    JoyconReader.v_count[0]++;
                }
                break;


            case "StartBar2":
                count[1] = JoyconReader.v_count[1];
                slider.value = count[1];
                if (slider.value >= slider.maxValue)
                {
                    isAble[1] = true;
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    JoyconReader.v_count[1]++;
                }
                break;
        }
        /*
        if((StartBar.isAble[0] && StartBar.isAble[1]) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }*/
    }
}