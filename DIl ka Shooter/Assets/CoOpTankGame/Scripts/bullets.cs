using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour {

    Rigidbody2D rigidbody;
    public float Speed=4f;
    Player player;
    public Sprite left;
    public Sprite center;
    public Sprite right;
    SpriteRenderer s;
    // Use this for initialization
    public ParticleSystem particle;

    float timer;

    Enemy enemy;
	
    private void Awake()
    {
        s = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        s.sprite = center;
        if (player.BulletDirecton()== new Vector3(1,1,0))
        {
            s.sprite = right;
        }else if (player.BulletDirecton() == new Vector3(0, 1, 0))
        {
            s.sprite = center;
        }else if (player.BulletDirecton() == new Vector3(-1, 1, 0))
        {
            s.sprite = left;
        }
        if (player.BulletDirecton()==new Vector3(0,0,0))
        {
            rigidbody.velocity = Vector3.up * Speed;
        }else
        {
            rigidbody.velocity = player.BulletDirecton() * Speed;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer>=10f)
        {
            Destroy(gameObject);
        }
    }
    public void changeBulletSpeed(int speedy){

        Speed = speedy;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            enemy = col.gameObject.GetComponent<Enemy>();
            enemy.Destroyer();
           // Destroy(col.gameObject);
            Destroy(gameObject);
            player.ScoreUpdate(20);
          //  Instantiate(particle,transform.position,Quaternion.identity);
          
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("enemyBullet"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);

        }
        if (col.gameObject.layer == LayerMask.NameToLayer("timerBomb"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);

        }

    }


}
