using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUFO : MonoBehaviour {
    private Player player;
    private float defaultSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //エフェクトを出す
            player = other.gameObject.GetComponent<Player>();
            defaultSpeed = player.normalSpeed;
            player.normalSpeed = 0;
            Invoke("Release", 2.0f); //2秒後にReleaseメソッドを呼び出す
        }
    }
    private void Release()
    {
        player.normalSpeed = defaultSpeed;
    }
}