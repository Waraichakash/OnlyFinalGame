using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

    public float spaceSpeed = 2f;
    float Timer=0;
    public GameObject space;
    public float time = 6.5f;

	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.fixedDeltaTime;
        transform.position += Vector3.down * spaceSpeed * Time.deltaTime;

        if (Timer>=time)
        {
            Instantiate(space,new Vector3(0.1f,7.9f,0),Quaternion.identity);
            Timer = 0;
            Destroy(gameObject);
        }

    }

}
