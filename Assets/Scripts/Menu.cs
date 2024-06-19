using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public AudioSource MouseOver;

    public GameObject Pic1;
    public GameObject Pic2;
    public GameObject Pic3;
    int index = 0;
    public int totalIndex = 2;
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K))
        {
			MouseOver.Play ();
            if (index < totalIndex)
            {
                index++;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.I))
        {
			MouseOver.Play ();
            if (index > 0)
            {
                index--;
            }
        }
        if (index == 0)
        {
            Pic1.SetActive(true);
            Pic2.SetActive(false);
            Pic3.SetActive(false);

        }
        else if (index == 1)
        {
            Pic1.SetActive(false);
            Pic2.SetActive(true);
            Pic3.SetActive(false);
        }
        else if (index == 2)
        {
            Pic1.SetActive(false);
            Pic2.SetActive(false);
            Pic3.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O))
        {
			MouseOver.Play ();
            if (index == 0)
            {
                Play();
            }
            else if (index == 1)
            {
                Tutor();
            }
            else if (index == 2)
            {
                QuitGame();
                Debug.Log("Quitting game...");
            }
        }
    }
    
    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("playerSelect");
    }
    public void Tutor()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("tutorial");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
