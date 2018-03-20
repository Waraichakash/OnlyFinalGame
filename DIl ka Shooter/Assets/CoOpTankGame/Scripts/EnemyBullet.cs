using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    Rigidbody2D rigidbody;
    public float Speed = 2f;
    SpriteRenderer sprites;
    // Use this for initialization
    public ParticleSystem particle;

    public Sprite bullet1;
    public Sprite bullet2;
    public Sprite bullet3;
    public Sprite bullet4;
    public Sprite bullet5;
    public Sprite bullet6;
    public Sprite bullet7;
    public Sprite bullet8;
    public Sprite bullet9;
    // Use this for initialization
   // Sprite trying;
    public Enemy enemy;
    Player player;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2.5f)
        {
            Destroy(gameObject);
        }
     
    }

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        sprites = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector3.down * Speed;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Destroy(gameObject);
            player.ChangeHealth(1);
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    
    }
    public void BulletPosition(Vector3 position){
        rigidbody.velocity = position * Speed;
    }

    public void ChangeSprite(int i)
    {
        if (i == 1)
        {
            sprites.sprite = bullet1;
        }
        else if (i == 2)
        {
            sprites.sprite = bullet2;
        }
        else if (i == 3)
        {
            sprites.sprite = bullet3;
        }
        else if (i == 4)
        {
            sprites.sprite = bullet4;
        }
        else if (i == 5)
        {
            sprites.sprite = bullet5;
        }
        else if (i == 6)
        {
            sprites.sprite = bullet6;
        }
        else if (i == 7)
        {
            sprites.sprite = bullet7;
        }
        else if (i == 8)
        {
            sprites.sprite = bullet8;
        }else if (i==9)
        {
            sprites.sprite = bullet9;
            transform.localScale = Vector3.one;
        }

    }


}
