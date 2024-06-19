using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySoundSelect : MonoBehaviour {

    public AudioSource soundbg;
    public AudioSource soundbg2;
    // Use this for initialization
    void Start()
    {
        soundbg.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex != 3 && SceneManager.GetActiveScene().buildIndex != 4)
        {
            //menustop
            soundbg.Stop();
            soundbg2.Stop();
        }
    }
}
