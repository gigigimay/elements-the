using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultiUIControl : MonoBehaviour {

    public GameObject[] players = new GameObject[2];
    public GameObject[] ultiMeter = new GameObject[2];

    public Sprite[] ultiS0 = new Sprite[4];
    public Sprite[] ultiS1 = new Sprite[4];
    public Sprite[] ultiS2 = new Sprite[4];
    public Sprite[] ultiS3 = new Sprite[4];

    private Sprite[] useSprite1 = new Sprite[4];
    private Sprite[] useSprite2 = new Sprite[4];

    private SpriteRenderer[] m = new SpriteRenderer[2];

    void Start() {

        m[0] = ultiMeter[0].GetComponent<SpriteRenderer>();
        m[1] = ultiMeter[1].GetComponent<SpriteRenderer>();

        if (AvatarChoose.CP1 > 0) //for real:
        {
            useSprite1 = getUseSprite(AvatarChoose.CP1);
            useSprite2 = getUseSprite(AvatarChoose.CP2);
        }
        else //for test:
        {
            useSprite1 = getUseSprite(3);
            useSprite2 = getUseSprite(4);
        }

        m[0].sprite = useSprite1[0];
        m[1].sprite = useSprite2[0];
    }

    private Sprite[] getUseSprite(int cp)
    {
        if (cp == 1)
            return ultiS0;
        else if (cp == 2)
            return ultiS1;
        if (cp == 3)
            return ultiS2;
        if (cp == 4)
            return ultiS3;
        else
            return ultiS0;
    }

    void Update() {
        uUIUpdate(0, useSprite1, m[0]);
        uUIUpdate(1, useSprite2, m[1]);
    }

    void uUIUpdate(int p, Sprite[] u, SpriteRenderer m)
    {
        int charge = players[p].GetComponent<p_Control>().charges;
        m.sprite = u[charge];
    }


}
