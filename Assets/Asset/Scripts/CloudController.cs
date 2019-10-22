using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {
    private float speed;
    private int direction;

    void Start () {
        speed = 0.1f;
    }
	
	void Update () {
        transform.position += speed * Vector3.right;
        if (transform.position.x > 70)
        {
            transform.position += new Vector3(-140, 0, 0);
        }
    }
}