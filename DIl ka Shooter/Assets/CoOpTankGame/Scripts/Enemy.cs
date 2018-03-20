using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Sprite tb1;            //SPRITE FOR TANKS
    public Sprite tr1;
    public Sprite tb2;
    public Sprite tr2;
    public Sprite tb3;
    public Sprite tr3;
    public Sprite tb4;
    public Sprite tr4;
    int k = 0;                       //RANDOM FOR CHOOSING TANK
    public  float movementSpeed = 2; //TANK MOVING SPEED
    public float tankMaxX = 8.5f;    //TANK POSITION FOR
    bool move = true;                //TANK ROTAION
    public EnemyBullet bullet;       // BULLETS
    EnemyBullet go;                  //FOR SENDING EXTRA DATA WITH INSTANTIATE
    Vector3[] bulletPosition = new Vector3[3];  //BULLET POSITION
    int destroyMe = 10;             //DESTROY TANKS
    public Blast blast;             //TANK BLAST
    float time;                     //BULLET DIE AUTOMATICALLY
    float fire;
    Player player;
    SpriteRenderer sprites;


	void Start () {
        
        sprites = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();
        k = (int)Random.Range(1, 8);
        fire = (int)Random.Range(1, 3);
        ChangeSprite(k);
        if (k%2==0)
        {
            movementSpeed = Random.Range(4f, 8f);
        }
        else
        {
            movementSpeed = Random.Range(1f, 3f);
        }
    }
	

	void Update () {
        time += Time.deltaTime;

        if (k%2==0)
        {
            if (transform.position.x > tankMaxX)
            {
                move = true;
            }
            if (transform.position.x < -tankMaxX)
            {
                move = false;
            }
        }else
        {
            if (transform.position.x > tankMaxX)
            {
                move = false;
            }
            if (transform.position.x < -tankMaxX)
            {
                move = true;
            }
        }

        if (move)
        {
            transform.Translate(Vector3.up.normalized * Time.deltaTime * movementSpeed);
        }
        else
        { 
            transform.Translate(Vector3.down.normalized * Time.deltaTime * movementSpeed);
        }

        if (((int)time)==fire)
        {
            if (k%2==0 )
            {
                bulletPosition[0] = new Vector3(1,-1,0);
                bulletPosition[1] =Vector3.down;
                bulletPosition[2] =new Vector3(-1, -1, 0);
              
                for (int i = 0; i < bulletPosition.Length; i++)
                {
                    go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 180));
                    go.SendMessage("ChangeSprite", k);
                    go.SendMessage("BulletPosition",bulletPosition[i]);
                }
            }
             go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 180));
            go.SendMessage("ChangeSprite",k);
            time = 0;
            fire = (int)Random.Range(1, 10);
        }
    }

    public void Destroyer(){

        if (k%2!=0)
        {
            destroyMe -= 2;
        }
        if (destroyMe==5 && k%2==0)
        {
            k -= 1;
            ChangeSprite(k);
            transform.Rotate(new Vector3(0,0,180));
        }
        if (destroyMe<=0)
        {
            player.NewEnemy();
            Instantiate(blast,transform.position,Quaternion.identity);
            player.TanksLeft(-1);
            Destroy(gameObject);
        }

        destroyMe -= 1;

    }

  void   ChangeSprite(int i){
        
        if (i==1)
        {
            sprites.sprite = tb1;
        }else if (i==2)
        {
            sprites.sprite = tr1;
            transform.Rotate(new Vector3(0,0,180));
        }else if (i == 3)
        {
            sprites.sprite = tb2;
        }else if (i == 4)
        {
            sprites.sprite = tr2;
            transform.Rotate(new Vector3(0, 0, 180));
        }else if (i == 5)
        {
            sprites.sprite = tb3;
        }else if (i == 6)
        {
            sprites.sprite = tr3;
            transform.Rotate(new Vector3(0, 0, 180));
        }else if (i == 7)
        {
            sprites.sprite = tb4;
        }else if (i == 8)
        {
            sprites.sprite = tr4;
            transform.Rotate(new Vector3(0, 0, 180));
        }

    }
}
