using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerBomb : MonoBehaviour {

    SpriteRenderer sprite;
    public Sprite bomb2;
    public Sprite bomb3;
    public Blast blast;
    public float fallSpeed =3;
    float timer = 0;
    Player player;
    float y = -3.84f;   
	// Use this for initialization
	void Start () {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {



        if (transform.position.y<=y)
        {
            timer += Time.deltaTime;

            if (timer>0.6)
            {
                Instantiate(blast,transform.position,Quaternion.identity);
                if (player.transform.position.x - transform.position.x <= 3)
                {
                    player.ChangeHealth(2);
                }
                Destroy(gameObject);
            }else if (timer>0.4)
            {
                sprite.sprite = bomb3;
            }else if (timer>0.2)
            {
                sprite.sprite = bomb2;
            }

           

        }else
        {
            transform.position += Vector3.down*Time.deltaTime*fallSpeed;
            }


    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Destroy(gameObject);
            player.ChangeHealth(2);
            Instantiate(blast, transform.position, Quaternion.identity);

        }

    }
}
