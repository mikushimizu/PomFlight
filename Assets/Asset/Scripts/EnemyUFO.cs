using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUFO : MonoBehaviour {
    private Player player;
    private float defaultSpeed;
    private float defaultThrust;
    private float speed;
    private int direction;
    public AudioClip crash;
    AudioSource audioSource;

    private void Start()
    {
        speed = 0.4f;
        direction = 1;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.position += speed * direction * Vector3.left;
        if (transform.position.x < -30)
        {
            direction = -1;
        }else if(transform.position.x > 30)
        {
            direction = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //エフェクトを出す
            audioSource.PlayOneShot(crash);
            player = other.gameObject.GetComponent<Player>();
            defaultSpeed = player.normalSpeed;
            defaultThrust = player.thrust;
            player.normalSpeed = 0;
            player.thrust = 0;
            Invoke("Release", 1.0f); //1秒後にReleaseメソッドを呼び出す
        }
    }
    private void Release()
    {
        player.normalSpeed = defaultSpeed;
        player.thrust = defaultThrust;
    }
}