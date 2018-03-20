using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : MonoBehaviour {

    Rigidbody2D rigid;
    public Blast blast;
    Player player;
	// Use this for initialization
	void Start () {
        
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();

	}


	void Update () {
        
        rigid.velocity = Vector2.down * 3;

	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            Destroy(gameObject);
            player.ChangeHealth(5);
         }
        if (col.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
