using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

    Rigidbody2D rigid;
    public bullets bullet;


  
    Player player;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {
        rigid.velocity = Vector2.down * 5;
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            bullet.changeBulletSpeed(10);
            player.ChangeHealth(-5);
            Destroy(gameObject);
        }
    }
}
