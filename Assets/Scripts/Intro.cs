using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
	public AudioSource MouseOver;
	void Update () {
        if (Input.anyKeyDown)
        {
			MouseOver.Play ();
            Debug.Log("Loading menu...");
            Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        }
    }
    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
