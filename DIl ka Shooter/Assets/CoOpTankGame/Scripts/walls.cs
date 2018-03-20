using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walls : MonoBehaviour {

    public float movementSpeed = 1;
    Player player;
   
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(Vector3.down.normalized * Time.deltaTime * movementSpeed);

        if (transform.position.y<-15)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Destroy(gameObject);
            player.ChangeHealth(10);
           
        }

    }
   
}
