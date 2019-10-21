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
    private int[] count = new int[2];


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
        for(int i=0; i<count.Length; i++)
        {
            count[i] = 0;
        }
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
                    Disturb(0);
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
                    Disturb(1);
                }
                break;
        }
    }

    public void Rise()
    {
        rb.AddForce(transform.up * thrust);
    }

    public void Attack(float attack)
    {
        attackSpeed = attack;
    }

    public void Disturb(int i)
    {
        //i=0,1
        count[i] = 1 - count[i];
        if (count[i] == 0)
        {
            if(i == 0){
                Attack(-0.3f);
            }
            else
            {
                Attack(0.3f);
            }
            
        }
        else
        {
            if (i == 0)
            {
                Attack(0.3f);
            }
            else
            {
                Attack(-0.3f);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "RightWall":
                Attack(0);
                break;

            case "LeftWall":
                Attack(0);
                break;

            case "Player":
                if(collision.transform.position.y > transform.position.y)
                {
                    if(collision.gameObject.GetComponent<Player>().starScore > 0)
                    {
                        collision.gameObject.GetComponent<Player>().starScore -= 1;
                        GetComponent<Player>().starScore += 1;
                    }
                }
                break;
        }
    }
}