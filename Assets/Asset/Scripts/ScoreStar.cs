using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStar : MonoBehaviour {
    private int point;
    public AudioClip getStar;
    AudioSource audioSource;

    void Start () {
        point = 1;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(getStar);
            collision.gameObject.GetComponent<Player>().StarScore += point;
            Destroy(gameObject);
        }
    }
}