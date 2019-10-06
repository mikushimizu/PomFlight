using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private float thrust;
    public float normalSpeed;
    private Rigidbody rb;
    private float height;
    private int starScore;

    public float Height
    {
        get { return height; }
        set { height = value; }
    }
    public int StarScore
    {
        get { return starScore; }
        set { starScore = value; }
    }

    void Start () {
        thrust = 10f;
        normalSpeed = 0.05f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position += Vector3.up * normalSpeed;
        switch(gameObject.name)
        {
            case "Player1":
                Height = Mathf.Floor(gameObject.transform.position.y);
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    AddForce();
                }
                break;
            case "Player2":
                Height = Mathf.Floor(gameObject.transform.position.y);
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    AddForce();
                }
                break;
        }
    }

    public void AddForce()
    {
        rb.AddForce(transform.up * thrust);
    }
    public void AddForceR()
    {
        rb.AddForce(transform.right * thrust);
    }
}
