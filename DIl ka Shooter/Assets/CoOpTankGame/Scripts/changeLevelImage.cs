using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeLevelImage : MonoBehaviour {

   // public Image level1;
    public Sprite level2;
    public Sprite level1;
   
    Image image;
	// Use this for initialization
	void Start () {
       
        image = gameObject.GetComponent<Image>();
        image.sprite = level1;
       
        if (Player.CountdownTime == 1f)
        {
            image.sprite = level2;

        }

    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        if (Player.CountdownTime == 1f)
        {
            SceneManager.LoadScene("scene2");
        }else
        {
            SceneManager.LoadScene("scene1");
            }

        Destroy(gameObject);
    }

	
	// Update is called once per frame
	void Update () {
        StartCoroutine(ExecuteAfterTime(15));
	}
}
