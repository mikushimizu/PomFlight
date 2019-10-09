using System.Collections;
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
            Destroy(gameObject);
        }
    }
}