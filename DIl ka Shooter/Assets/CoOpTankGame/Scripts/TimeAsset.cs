using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAsset : MonoBehaviour {


    Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
        transform.position += Vector3.down * Time.deltaTime * 4;

        if (transform.position.y<-10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Destroy(gameObject);
            player.AddTime(7);

        }

    }
}
