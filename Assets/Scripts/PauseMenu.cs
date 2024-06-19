using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public AudioSource BgsoundVolume;
    public GameObject MuteSound;
    public GameObject UnMuteSound;
    public GameObject[] players = new GameObject[2];
    int index = 0;
    public int totalIndex = 2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K))
                {
                    if (index < totalIndex - 1)
                    {
                        index++;
                    }

                    else if(index == 3)
                    {
                        index = 1;
                    }
                }
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.I))
                {
                    if (index == 1)
                    {
                        index = 3;
                    }
                    else if (index > 0)
                    {
                        index--;
                    }

                    
                }
                if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.U))
                {
                    if (index == 1)
                    {
                        Resume();
                    }
                    else if (index == 2)
                    {
                        
                        LoadMenu();
                    }
                    else if (index == 3)
                    {
                        QuitGame();
                    }
                }
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        BgsoundVolume.volume = 1;
        players[0].GetComponent<p_Control>().enabled = true;
        players[1].GetComponent<p_Control>().enabled = true;
    }
    GameObject[] star;
    void Pause()
    {
        players[0].GetComponent<p_Control>().enabled = false;
        players[1].GetComponent<p_Control>().enabled = false;

        star = GameObject.FindGameObjectsWithTag("Atk");
        foreach (GameObject eachstar in star){
            if(eachstar.GetComponent<bulletControl>() != null)
            eachstar.GetComponent<bulletControl>().enabled = false;
        }

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        BgsoundVolume.volume = 0.125f;
    }

    public void LoadMenu()
    {
        //reset hp
        players[0].GetComponent<p_Control>().resetSelf();
        players[1].GetComponent<p_Control>().resetSelf();

        Resume();
        Debug.Log("Loading menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Intro");


    }
    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
        MuteSound.SetActive(false);
        UnMuteSound.SetActive(true);
    }
    public void UnMute()
    {
        AudioListener.pause = !AudioListener.pause;
        UnMuteSound.SetActive(false);
        MuteSound.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}


