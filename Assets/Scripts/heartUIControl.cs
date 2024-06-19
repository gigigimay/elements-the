using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartUIControl : MonoBehaviour {

    public Sprite[] heartSprites = new Sprite[4];
    public GameObject[] heartsP1 = new GameObject[5];
    public GameObject[] heartsP2 = new GameObject[5];
    public GameObject[] players = new GameObject[2];

    void Start () {

        //for real game:
        if (AvatarChoose.CP1 > 0) 
        {
            foreach (GameObject h in heartsP1)
                h.GetComponent<SpriteRenderer>().sprite = heartSprites[AvatarChoose.CP1 - 1];
            foreach (GameObject h in heartsP2)
                h.GetComponent<SpriteRenderer>().sprite = heartSprites[AvatarChoose.CP2 - 1];

        }
        else //for test:
        {
            foreach (GameObject h in heartsP1)
                h.GetComponent<SpriteRenderer>().sprite = heartSprites[2];
            
            foreach (GameObject h in heartsP2)
                h.GetComponent<SpriteRenderer>().sprite = heartSprites[3];
        }
    }
	
	void Update () {
        hpUIUpdate(0, heartsP1);
        hpUIUpdate(1, heartsP2);
    }

    void hpUIUpdate(int p, GameObject[] Hearts)
    {
        foreach (GameObject h in Hearts)
            h.GetComponent<SpriteRenderer>().enabled = false;
        int hp = players[p].GetComponent<p_Control>().hp;
        for (int i = 0; i < hp; i++)
        {
            Hearts[i].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}