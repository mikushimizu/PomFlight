﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStar : MonoBehaviour {
    private int point;

    void Start () {
        point = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().StarScore += point;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 1.0f);
        }
    }
}