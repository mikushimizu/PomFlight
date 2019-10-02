using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float thrust;
    private Rigidbody rb;
    private float height;
    
    public float Height
    {
        get { return height; }
        set { height = value; }
    }

    void Start () {
        thrust = 10f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
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
}
