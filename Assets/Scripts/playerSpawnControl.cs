using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawnControl : MonoBehaviour {

	public Vector2 p1SpawnPos;
	public Vector2 p2SpawnPos;

	public GameObject[] characters = new GameObject[4];
	public GameObject[] playerMark = new GameObject[2];


    public GameObject canvasObj;

	Vector2 spawnPos;
	int LayerP;
    GameObject refObj;

	KeyCode[] keyBind;
	/*	0:up   1:left   2:right   3:atk   4:ultimate   */

	void Start () {
        startRound();
	}

    public void startRound() //called via MatchControl
    {

        if (AvatarChoose.CP1 > 0) //for real:
        {
            playerSpawn(characters[AvatarChoose.CP1 - 1], 0); //p1
            playerSpawn(characters[AvatarChoose.CP2 - 1], 1); //p2
        }
        else
        {
            //for test:
            playerSpawn(characters[0], 0); //p1
            playerSpawn(characters[3], 1); //p2
        }
    }

	void playerSpawn(GameObject charr, int playerNum){

		if (playerNum == 0) {
			spawnPos = p1SpawnPos;
			LayerP = 8;
			keyBind = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.D, KeyCode.E, KeyCode.Q };

        } else if (playerNum == 1) {
			spawnPos = p2SpawnPos;
			LayerP = 9;
			keyBind = new KeyCode[] { KeyCode.I, KeyCode.J, KeyCode.L, KeyCode.O, KeyCode.U };
		}

		//player
		GameObject p = Instantiate (charr, spawnPos, Quaternion.identity) as GameObject;
		p.layer = LayerP;
		p.GetComponent<p_Control> ().keyBind = keyBind;
		p.GetComponent<p_Control> ().playerNum = playerNum;
        if (playerNum == 1) //set p2 facing direction
            p.transform.localScale = new Vector2(p.transform.localScale.x * -1, p.transform.localScale.y);


        //activate UI
        this.GetComponent<heartUIControl>().enabled = true;
        this.GetComponent<ultiUIControl>().enabled = true;

        //set p1p2 parameter
        this.GetComponent<MatchControl>().players[playerNum] = p;
        this.GetComponent<heartUIControl>().players[playerNum] = p;
        this.GetComponent<ultiUIControl>().players[playerNum] = p;
        this.GetComponent<PauseMenu>().players[playerNum] = p;


        //P1 P2 mark
        Vector2 markPos = new Vector2 (p.transform.position.x, p.transform.position.y + 1.5f);
		GameObject mark = Instantiate (playerMark [playerNum], markPos, Quaternion.identity) as GameObject;
		mark.transform.SetParent (p.transform);
		Destroy (mark.gameObject, 5);
	}
}