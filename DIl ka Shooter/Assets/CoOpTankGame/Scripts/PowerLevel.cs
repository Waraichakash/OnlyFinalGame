using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLevel : MonoBehaviour {

    public bullets bullet;
    float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		
        if (timer>=30)
        {
            bullet.changeBulletSpeed(4);
            Destroy(gameObject);
        }
    }
}
