using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float movementSpeed = 2;
    public Enemy tb1;  //ENEMIES
    public EnemyTry enemyTry;
    public Sprite p1; //PLAYER SPRITES
    public Sprite p2;
    public Sprite p3;
    public Sprite p4;
    public Sprite otherPlayer;
    SpriteRenderer playerSprite;
    static public float CountdownTime = 0; //TIME BETWEEN CHANGING SCENE
    float y = -3.84f;                       //Y AXIS FOR PLAYER MOVEMENT
    public float maxXForPlayer = 9f;        //X AXIS LIMITS
    float tx,ty;                            //ENEMY PSITIONS
    bool move = true;                       // FOR STOPPING PLAYER AFTER BEFORE DIEING
    Vector3 bulletDirection;                //DIRECTION OF BULLET
    float trying = 0;                       //FOR PLAYER FIRING DIRECTION
    float x = 0;                            //FOR INSTANTIATING NEW ENEMY
    public bullets bullet;
    int scores = 0;                         //UI
    public Text scoreText;
    public float timeGiven = 30;
    public Text timeText;
    public Image healthImage;
    public Image life1;
    public Image life2;
    public Image life3;
    public Text healthText;
    public Text timeOverText;
    public Text tanksScoreLeft;
    float energy = 1;                      //FOR POWER LEVEL

    public Power power;                    //POWER ENDING
    public Astroids astroid;               //ASTROIDS
    float timeAstroid = 0;
    float wallCreate = 0;                  //WALLS FOR LEVEL2
    public walls wall1;
    public walls wall2;
    public walls wall3;
    public walls wall4;
    int numberOfTanks = 0;                 //TANKS COUNT

    public TimeAsset asset;
  

    void Start()
    {

        playerSprite = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(0, y, 0);
        tx = Random.Range(-maxXForPlayer, maxXForPlayer);
        ty = Random.Range(5f, 0);
        Instantiate(tb1, new Vector3(tx, ty, 0), Quaternion.Euler(0, 0, -90));

        numberOfTanks = (int)Random.Range(6, 9);

        for (int i = 0; i < numberOfTanks; i++)
        {
            tx = Random.Range(-maxXForPlayer, maxXForPlayer);
            ty = Random.Range(4f, 0);
            Instantiate(tb1, new Vector3(tx, ty, 0), Quaternion.Euler(0, 0, -90));
        }
        numberOfTanks += 1;

        if (wall1 != null)
        {
            playerSprite.sprite = otherPlayer;
        }

        Instantiate(enemyTry,new Vector3(-4,4,0),Quaternion.Euler(0,0,-90));
        //-----------------
        Instantiate(enemyTry, new Vector3(4, 4, 0), Quaternion.Euler(0, 0, -90));
    }


    void Update()
    {
        timeAstroid += Time.deltaTime;
        energy += Time.deltaTime;


        if (timeAstroid >= 1.5f)
        {
            Instantiate(astroid, new Vector3(Random.Range(-8, 8), 9, 0), Quaternion.identity);
            timeAstroid = 0;
        }
        if (energy >= 10)
        {
            energy = 0;
            Instantiate(power, new Vector3(Random.Range(-7, 7), 5, 0), Quaternion.identity);

            Instantiate(asset, new Vector3(Random.Range(-7, 7), 5, 0),Quaternion.identity);
           
        }
        if (timeGiven <= 0)
        {
            timeOverText.text = "Time Over";
            tanksScoreLeft.text = "Tanks Left = " + numberOfTanks + " \n" + "Scores = " + scores;
            Destroy(tb1);
            move = false;
            StartCoroutine(ExecuteAfterTime(4));
        }
        if (move)
        {
            timeGiven -= Time.deltaTime;
            Movement();
            Shooting();
        }
        uiUpdate();
        Won();
        if (wall1!=null)
        {
            WallsCreated();
        }
    }




    void Shooting()
    {

        if (Input.GetButtonDown("shoot"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }


    public void uiUpdate()
    {

        scoreText.text = "Scores : " + scores;
        timeText.text = "Time Left : " + (int)timeGiven + "s";
        if (timeGiven <= 20)
        {
            timeText.color = Color.red;
        }
        healthText.text = (int)(healthImage.fillAmount * 100) + "%";

    }

    void Won()
    {
        if (numberOfTanks == 0)
        {
            uiUpdate();
            tanksScoreLeft.text = "Tanks Left = " + numberOfTanks + "\n" + "Scores = " + scores;
            timeOverText.text = "WON";
            CountdownTime = 1;
            move = false;
            StartCoroutine(ExecuteTime(4));
        }
    }
    IEnumerator ExecuteTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (wall1 != null)
        {
            SceneManager.LoadScene("Won");
        }
        else
        {
            SceneManager.LoadScene("countdownScene");
        }
        Destroy(gameObject);
    }


    void WallsCreated()
    {
        wallCreate += Time.deltaTime;

        if (wallCreate >= 8)
        {

            int x = Random.Range(1, 4);

            if (x == 1)
            {
                Instantiate(wall1, new Vector3(0, 8, 0), Quaternion.identity);
            }
            else if (x == 2)
            {
                Instantiate(wall2, new Vector3(0, 8, 0), Quaternion.identity);
            }
            else if (x == 3)
            {
                Instantiate(wall3, new Vector3(0, 8, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(wall4, new Vector3(0, 8, 0), Quaternion.identity);
            }
            //Instantiate();
            wallCreate = 0;
        }
    }


    public void NewEnemy()
    {
        if (x % 2 == 0)
        {
            tx = Random.Range(-maxXForPlayer, maxXForPlayer);
            ty = Random.Range(4f, 0);
            Instantiate(tb1, new Vector3(tx, ty, 0), Quaternion.Euler(0, 0, -90));

            numberOfTanks += 1;
        }
        x += 1;
    }


    public void ScoreUpdate(int score)
    {
        scores += score;
    }


    public void TanksLeft(int tankNo)
    {
       numberOfTanks += tankNo;
    }


    public void AddTime(int incTime)
    {

        timeGiven += incTime;
    }

    public void ChangeHealth(int health)
    {
        healthImage.fillAmount -= (float)health / 10;

        if (healthImage.fillAmount <= 0)
        {
            if (life1 != null)
            {
                healthImage.fillAmount = 1;
                Destroy(life1);
            }
            else if (life2 != null)
            {
                healthImage.fillAmount = 1;
                Destroy(life2);
            }
            else if (life3 != null)
            {
                healthImage.fillAmount = 1;
                Destroy(life3);
            }
            else
            {
                uiUpdate();
                tanksScoreLeft.text = "Tanks Left = " + numberOfTanks + "\n" + "Scores = " + scores;
                timeOverText.text = "Player Dead";
                Destroy(tb1); 
                move = false;
                StartCoroutine(ExecuteAfterTime(5));
            }
        }
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject);
    }


    void Movement()
    {

        if (Input.GetButton("left"))
        {
            if (transform.position.x > -maxXForPlayer)
            {
                transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(-maxXForPlayer - 0.1f, y, 0);
            }

        }
        if (Input.GetButton("right"))
        {
            if (transform.position.x < maxXForPlayer)
            {
                transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(maxXForPlayer + 0.1f, y, 0);
            }

        }

        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            if (transform.rotation.z > -0.3)
            {
                trying -= 45f;
                transform.Rotate(new Vector3(0, 0, trying));
                trying = 0;
                if (transform.rotation.z > 0)
                {
                    bulletDirection = new Vector3(-1, 1, 0);
                }
                else if (transform.rotation.z == 0f)
                {
                    bulletDirection = new Vector3(0, 1, 0);
                }
                else
                {
                    bulletDirection = new Vector3(1, 1, 0);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

            if (transform.rotation.z < 0.3)
            {
                trying += 45f;
                transform.Rotate(new Vector3(0, 0, trying));
                trying = 0;
                if (transform.rotation.z > 0)
                {
                    bulletDirection = new Vector3(-1, 1, 0);
                }
                else if (transform.rotation.z == 0f)
                {
                    bulletDirection = new Vector3(0, 1, 0);
                }
                else
                {
                    bulletDirection = new Vector3(1, 1, 0);
                }
            }
        }
    }


    public Vector3 BulletDirecton()
    {
        if (bulletDirection == null)
        {
            return Vector3.up;
        }

        return bulletDirection;
    }
}
