using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float thrust;
    public float normalSpeed;
    public float attackSpeed;
    private Rigidbody rb;
    private float height;
    private int starScore;
    private int count;


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
        thrust = 1f;
        normalSpeed = 0.05f;
        attackSpeed = 0.00f;
        rb = GetComponent<Rigidbody>();
        count = 0;
    }
    
    void Update()
    {
        transform.position += Vector3.up * normalSpeed + Vector3.right * attackSpeed;

        switch (gameObject.name) //ちゃんと取得してください
        {
            case "Player1": //enumでUIから選択できるようにする
                Height = Mathf.Floor(gameObject.transform.position.y);
                if (Input.GetKey(KeyCode.F))
                {
                    Rise();
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    count = 1 - count;
                    if (count == 0) { 
                        Disturb(-0.3f);
                    }
                    else
                    {
                        Disturb(0.3f);
                    }
                }
                break;

            case "Player2":
                Height = Mathf.Floor(gameObject.transform.position.y);
                if (Input.GetKey(KeyCode.J))
                {
                    Rise();
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    count = 1 - count;
                    if (count == 0)
                    {
                        Disturb(0.3f);
                    }
                    else
                    {
                        Disturb(-0.3f);
                    }
                }
                break;
        }
    }

    public void Rise()
    {
        rb.AddForce(transform.up * thrust);
    }

    public void Disturb(float attack)
    {
        attackSpeed = attack;
    }

    public void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "RightWall":
                Disturb(0);
                break;

            case "LeftWall":
                Disturb(0);
                break;

            case "Player":

                break;
        }
    }
}