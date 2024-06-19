using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySoundBg : MonoBehaviour {

    public AudioSource soundbg;
	// Use this for initialization
	void Start () {
        soundbg.Play();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 2)
        {
            //menustop
            soundbg.Stop();
        }
    }
}
