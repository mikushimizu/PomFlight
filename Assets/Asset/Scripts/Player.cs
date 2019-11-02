using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float thrust;
    public float normalSpeed;
    public float attackSpeed;
    public int steelStarCount;
    public AudioClip getStar;
    public AudioClip steelStar;
    public GameObject steelStarParticle;
    public GameObject steeledStarParticle;
    private AudioSource audioSource;
    private Rigidbody rb;
    private float height;
    private int starScore;
    private int[] count = new int[2];
    private Vector3 particlePosition;

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
        steelStarCount = 3;
        particlePosition = new Vector3(0, 5, -1);
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        for (int i=0; i<count.Length; i++)
        {
            count[i] = 0;
        }
    }
    
    void Update()
    {
        Vector3 pos = transform.position + Vector3.up * normalSpeed + Vector3.right * attackSpeed;
        transform.position = new Vector3(Mathf.Clamp(pos.x, -10, 10), Mathf.Clamp(pos.y, 0, 10000), 0);

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
        if (GameManager.battleStart)
        {
            if(rb.velocity.y < 180)
            {
                rb.AddForce(transform.up * thrust);
            }
        }
    }

    public void Attack(float attack)
    {
        attackSpeed = attack;
    }

    public void Disturb(int i)
    {
        if (GameManager.battleStart)
        {
            count[i] = 1 - count[i];
            switch (count[i])
            {
                case 0:
                    if (i == 0)
                    {
                        Attack(-0.3f);
                    }
                    else
                    {
                        Attack(0.3f);
                    }
                    break;

                case 1:
                    if (i == 0)
                    {
                        Attack(0.3f);
                    }
                    else
                    {
                        Attack(-0.3f);
                    }
                    break;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Star":
                audioSource.PlayOneShot(getStar);
                break;

            case "RightWall":
                Attack(0);
                break;

            case "LeftWall":
                Attack(0);
                break;

            case "Player":
                if(collision.transform.position.y > transform.position.y)
                {
                    if(collision.gameObject.GetComponent<Player>().starScore > steelStarCount)
                    {
                        collision.gameObject.GetComponent<Player>().starScore -= steelStarCount;
                        Instantiate(steeledStarParticle, collision.gameObject.transform.position + particlePosition, collision.gameObject.transform.rotation);
                        GetComponent<Player>().starScore += steelStarCount;
                        Instantiate(steelStarParticle, transform.position + particlePosition, transform.rotation);
                        audioSource.PlayOneShot(steelStar);
                    }
                }
                break;
        }
    }
}