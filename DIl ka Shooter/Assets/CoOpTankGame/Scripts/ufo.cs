using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufo : MonoBehaviour {

    public float movementSpeed = 2; //TANK MOVING SPEED
    public float tankMaxX = 14f;
    public timerBomb bomb;
    bool move = true;
    bool bombed = true;
    Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (transform.position.x > tankMaxX)
        {
            move = true;
        }
        if (transform.position.x < -tankMaxX)
        {
            move = false;
        }
        if (move)
        {
            transform.Translate(Vector3.left.normalized * Time.deltaTime * movementSpeed);
        }
        else
        {
            transform.Translate(Vector3.right.normalized * Time.deltaTime * movementSpeed);
        }

        if ( (int)transform.position.x==(int)player.transform.position.x )
        {
            if (bombed)
            {
                Instantiate(bomb, transform.position, Quaternion.identity);
                bombed = false;
            }
           
        }else
        {
            bombed = true;

            }
    }
}
