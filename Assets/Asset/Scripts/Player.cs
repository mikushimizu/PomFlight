using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float thrust;
    public Rigidbody rb;
    public static float player1Height;
    public static float player2Height;

    void Start () {
        thrust = 10f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch(gameObject.name)
        {
            case "Player1":
                player1Height = Mathf.Floor(gameObject.transform.position.y);
                break;
            case "Player2":
                player2Height = Mathf.Floor(gameObject.transform.position.y);
                break;
        }
    }

    public void AddForce()
    {
        rb.AddForce(transform.up * thrust);
    }
}
