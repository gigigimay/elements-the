using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MatchControl : MonoBehaviour
{
    float timer;
    int playtime = 60; //time per round
    int countdownTime = 5;
    int roundEndTime = 3;
    int round = 0;

    int P1hp, P2hp;
    int P1point, P2point;

    public GameObject[] players = new GameObject[2];

    public GameObject scoreUI;

    public Text timeUI;
    public GameObject startfightUI;
    public GameObject endUI;
    public Text TextWin;

    //score UI
    public Sprite[] scoreUISprite = new Sprite[2];
    public GameObject[] scoreIcon1 = new GameObject[2];
    public GameObject[] scoreIcon2 = new GameObject[2];

    bool endinground;
    float timeend = 0;
    // Use this for initialization
    void Start()
    {
        timer = playtime + countdownTime;
        round = 1;

        timeUI.text = playtime + "";

        P1point = P2point = 0;
        endUI.SetActive(false);
        startfightUI.SetActive(false);
        endinground = false;
        endRoundUI2.SetActive(false);

        this.GetComponent<PauseMenu>().enabled = false; //disable pause menu
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        //countDownText
        countDownText();

        //score UI
        UIupdate(P1point, scoreIcon1);
        UIupdate(P2point, scoreIcon2);

        if (timer <= playtime && timer >= 0 && !endinground) //game time text update
        {
            timeUI.text = (int)timer + "";
            if (!this.GetComponent<PauseMenu>().enabled) //enable pause menu
                this.GetComponent<PauseMenu>().enabled = true;
        }
  
        phaseControl();
        hpUpdate();
        checkEndRound();
        afterEnd();
        if (endinground)
        {
            endround();
            timeUI.text = 0 + "";
        }
    }

    void hpUpdate()
    {
        P1hp = players[0].GetComponent<p_Control>().hp;
        P2hp = players[1].GetComponent<p_Control>().hp;
    }

    void phaseControl()
    {
        if (timer > playtime) //countdown phase
        {
            players[0].GetComponent<p_Control>().enabled = false;
            players[1].GetComponent<p_Control>().enabled = false;
            if (!endUI.activeSelf)
                startfightUI.SetActive(true);

        }
        else if (!PauseMenu.GameIsPause)//play phase
        {
            startfightUI.SetActive(false);
            players[0].GetComponent<p_Control>().enabled = true;
            players[1].GetComponent<p_Control>().enabled = true;
        }
    }

    void checkEndRound()
    {
        if (!endinground)
        {
            if (timer <= 0) //time out
            {
                if (P1hp > P2hp)
                {
                    P1point++;
                }
                else if (P2hp > P1hp)
                {
                    P2point++;
                }
                else if( P1hp == P2hp)
                {
                    P1point++;
                    P2point++;
                }
                endroundUI.text = "Time Over.";
                endinground = true;
                timeend = timer;
                Debug.Log("by T");
            }
            else if (P1hp <= 0 || P2hp <= 0) //someone K.O.
            {
                //set point
                if (P1hp <= 0) 
                {
                    P2point++;
                }
                else
                {
                    P1point++;
                }
                endroundUI.text = "K.O.";
                endinground = true;
                timeend = timer;
                Debug.Log("by HP");
            }
        }
        
    }

    void checkEndGame()
    {
        
        if (P1point == 2 || P2point == 2) //game end
        {
            if (P1point == P2point)
            {
                TextWin.text = "Draw!";
            }
            else if (P1point == 2)
            {
                TextWin.text = "Player 1\nWins!";
            }
            else if (P2point == 2)
            {
                TextWin.text = "Player 2\nWins!";
            }

           Time.timeScale = 0f;

            timeUI.text = "0";

            players[0].GetComponent<p_Control>().enabled = false;
            players[1].GetComponent<p_Control>().enabled = false;

            

            endUI.SetActive(true);
        }
        
    }
    public Text endroundUI;
    public GameObject endRoundUI2;

    public void endround()
    {
        //endroundUI.text = "Round " + round + " End";
        endRoundUI2.SetActive(true);
        endinground = true;
        if (timeend - timer >= 5)
        {
            endinground = false;
            endRoundUI2.SetActive(false);
            checkEndGame();
            newround();
        }
            
    }

    GameObject[] items;
    void newround()
    {
        endRoundUI2.SetActive(false);
        endinground = false;
        timeend = 0;
        items = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in items)
        {
            Destroy(item);
        }
        round++;
        if (P1point != 2 || P2point != 2)
        {
            timer = playtime + countdownTime;

            //reset hp
            players[0].GetComponent<p_Control>().resetSelf();
            players[1].GetComponent<p_Control>().resetSelf();

            //relocate
            players[0].transform.position = this.GetComponent<playerSpawnControl>().p1SpawnPos;
            players[1].transform.position = this.GetComponent<playerSpawnControl>().p2SpawnPos;
            players[0].transform.localScale = new Vector2(Mathf.Abs(players[0].transform.localScale.x), players[0].transform.localScale.y);
            players[1].transform.localScale = new Vector2(Mathf.Abs(players[1].transform.localScale.x) * -1, players[0].transform.localScale.y);

            this.GetComponent<PauseMenu>().enabled = false; //disable pause menu
        }
    }

    void afterEnd()
    {
        if (endUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O))
            {
                P1point = P2point = 0;
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.U))
            {
                P1point = P2point = 0;
                Time.timeScale = 1f;
                SceneManager.LoadScene("Intro");
            }
        }
    }

    void countDownText()
    {
        if (startfightUI.activeSelf)
        {
            if (timer <= playtime + 1f)
            {
                startfightUI.GetComponent<Text>().text = "FIGHT!";
            }
            else if (timer <= playtime + 2f)
            {
                startfightUI.GetComponent<Text>().text = "1";
            }
            else if (timer <= playtime + 3f)
            {
                startfightUI.GetComponent<Text>().text = "2";
            }
            else if (timer <= playtime + 4f)
            {
                startfightUI.GetComponent<Text>().text = "3";
            }
            else
            {
                startfightUI.GetComponent<Text>().text = "Round " + round;
            }
        }
    }

    void UIupdate(int p, GameObject[] s)
    {
        if (p >= 1)
            s[0].GetComponent<SpriteRenderer>().sprite = scoreUISprite[1];
        if (p >= 2)
            s[1].GetComponent<SpriteRenderer>().sprite = scoreUISprite[1];
    }
}