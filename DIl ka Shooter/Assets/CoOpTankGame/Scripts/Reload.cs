using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene(string scene){
        

        if (Player.CountdownTime == 1f)
        {
            SceneManager.LoadScene("scene2");

        }
        else
        {
            SceneManager.LoadScene(scene);

        }
    }
}
