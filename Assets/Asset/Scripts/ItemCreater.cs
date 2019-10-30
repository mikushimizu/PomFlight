using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreater : MonoBehaviour {
    public GameObject[] Star = new GameObject[3];
    public GameObject Ufo;
    private int starCount;
    private int starColor;
    private int ufoCount;
    private Vector3 position;

    void Start () {
        starCount = 100;
        ufoCount = 10;
        //P1 Course
		for(int i = 1; i < starCount; i++)
        {
            position = new Vector3(-10, 38 * i, 0);
            starColor = Random.Range(0, 3);
            Instantiate(Star[starColor], position, Quaternion.Euler(-90, 0, 0));
        }

        //P2 Course
        for (int i = 1; i < starCount; i++)
        {
            position = new Vector3(10, 38 * i, 0);
            starColor = Random.Range(0, 3);
            Instantiate(Star[starColor], position, Quaternion.Euler(-90, 0, 0));
        }

        //neutral Course
        for (int i = 1; i < starCount; i++)
        {
            position = new Vector3(0, 38 * i + 19, 0);
            starColor = Random.Range(0, 3);
            Instantiate(Star[starColor], position, Quaternion.Euler(-90, 0, 0));
        }

        for (int i = 1; i < ufoCount; i++)
        {
            position = new Vector3(26, 300 * i, 0);
            Instantiate(Ufo, position, Quaternion.identity);
        }
    }
}