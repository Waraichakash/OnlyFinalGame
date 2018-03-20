using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTry : MonoBehaviour
{

    public Sprite tb1;            //SPRITE FOR TANKS
                     //RANDOM FOR CHOOSING TANK
    public float movementSpeed = 2; //TANK MOVING SPEED
      //TANK POSITION FOR
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


    //trying movement

    float angle = 0;
    int radius = 2;
    float x = 0;
    float orignX;
    float originY;
    float y = 0;
    int k = 3;
    float z = 0;
    void Start()
    {

        sprites = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(0.5f,0.5f,1);
        player = GameObject.Find("Player").GetComponent<Player>();
        fire = (int)Random.Range(2, 3);
        orignX = transform.position.x;
        originY = transform.position.y;


    }


    void Update()
    {
        time += Time.deltaTime;
       


        Vector2 direction = Vector2.zero;
        x = radius * Mathf.Cos(angle)+orignX;
        y = radius * Mathf.Sin(angle)+originY;

        transform.position = new Vector3(x, y, 0);

        angle += 0.04f * Mathf.Rad2Deg * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, 0, z);
        z += 5;
        if (((int)time) == fire)
        {
            go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, -90));
            go.SendMessage("ChangeSprite", 9);
            time = 0;
         //   fire = (int)Random.Range(1, 10);
        }

    }

    public void Destroyer()
    {

        if (k % 2 != 0)
        {
            destroyMe -= 2;
        }
        if (destroyMe == 5 && k % 2 == 0)
        {
            k -= 1;
      
            transform.Rotate(new Vector3(0, 0, 180));
        }
        if (destroyMe <= 0)
        {
            player.NewEnemy();
            Instantiate(blast, transform.position, Quaternion.identity);
            player.TanksLeft(-1);
            Destroy(gameObject);
        }

        destroyMe -= 1;

    }


}
