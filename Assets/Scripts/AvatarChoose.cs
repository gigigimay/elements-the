using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarChoose : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;

    //--- up down left right
    private KeyCode[] keyP1 = new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    private KeyCode[] keyP2 = new KeyCode[] { KeyCode.I, KeyCode.K, KeyCode.J, KeyCode.L };
    
    //Avatars
    public GameObject[] avatars1 = new GameObject[4];
    public GameObject[] avatars2 = new GameObject[4];
    //0=fire 1=water 2=wind 3-earth

    //cursor
    public GameObject Cp1;
    public GameObject Cp2;

    //selected
    public GameObject FireS;
    public GameObject WaterS;
    public GameObject EarthS;
    public GameObject WindS;

    //Ready
    public GameObject R1;
    public GameObject R2;

    //PlayerNum
    public static int CP1;
    public static int CP2;
    int x=2;
    int y=3;

    //Position
    public Vector2 P1Pos;
    public Vector2 P2Pos;

    //Check
    bool p1Selected;
    bool p2Selected;

    private float time;
    private float readyTime;
    private bool wait = false;

    public AudioSource BG_L;
    public AudioSource BG_R;
    public AudioSource EF_L;
    public AudioSource EF_R;
	public AudioSource MouseOver;
    bool selectsound = false;
	int checks=0;
    

    void Start()
    {
        CP1 = -1;
        CP2 = -1;

		BG_L.Play ();
		BG_R.Play ();

        p1Selected = false;
        p2Selected = false;
    }

    void Update()
    {
        time += Time.deltaTime;
        P1Choose();
        P2Choose();

        checkWait();
    }

    void P1Choose()
    {
        if (!p1Selected)
        {
            if (Input.GetKeyDown(KeyCode.Q) && x != CP2)
            {
				if (checks < 3) {
					Debug.Log (checks);
					EF_L.Play ();
					BG_L.volume = 0.5f;
					checks++;
				}
                p1Selected = true;
                CP1 = x;
                R1.SetActive(true);

                //***
                checkBothSel();

                if (CP1 == 1)
                    FireS.transform.position = new Vector2(0, 1.85f);
                else if (CP1 == 2)
                    WaterS.transform.position = new Vector2(-2, -0.15f);
                else if (CP1 == 3)
                    WindS.transform.position = new Vector2(2, -0.15f);
                else if (CP1 == 4)
                    EarthS.transform.position = new Vector2(0, -2.15f);
            }

            //up l r dwn
            if (Input.GetKeyDown(keyP1[0]) && CP2 != 1)
            {
				MouseOver.Play ();
                setCharClear(1);
                setCharActive(avatars1[0], 1);
                Cp1.transform.position = new Vector2(0,1.85f);
                x = 1;
            }
            else if (Input.GetKeyDown(keyP1[2]) && CP2 != 2)
            {
				MouseOver.Play ();
                setCharClear(1);
                setCharActive(avatars1[1], 1);
                Cp1.transform.position = new Vector2(-2, -0.15f);
                x = 2;
            }
            else if (Input.GetKeyDown(keyP1[3]) && CP2 != 3)
            {
				MouseOver.Play ();
                setCharClear(1);
                setCharActive(avatars1[2], 1);
                Cp1.transform.position = new Vector2(2, -0.15f);
                x = 3;
            }
            else if (Input.GetKeyDown(keyP1[1]) && CP2 != 4)
            {
				MouseOver.Play ();
                setCharClear(1);
                setCharActive(avatars1[3], 1);

                Cp1.transform.position = new Vector2(0, -2.15f);
                x = 4;
            }
        }
    }

    void P2Choose()
    {
        if (!p2Selected)
        {
            if (Input.GetKeyDown(KeyCode.U) && y != CP1)
            {
				if (checks<3)
                {
                    EF_R.Play();
                    BG_R.volume = 0.5f;
					checks++;
                }
                p2Selected = true;
                CP2 = y;
                R2.SetActive(true);

                //***
                checkBothSel();

                if (CP2 == 1)
                    FireS.transform.position = new Vector2(0, 1.85f);
                else if (CP2 == 2)
                    WaterS.transform.position = new Vector2(-2, -0.15f);
                else if (CP2 == 3)
                    WindS.transform.position = new Vector2(2, -0.15f);
                else if (CP2 == 4)
                    EarthS.transform.position = new Vector2(0, -2.15f);
            }
        
            //up l r dwn
            if (Input.GetKeyDown(keyP2[0]) && CP1 != 1)
            {
				MouseOver.Play ();
                setCharClear(2);
                setCharActive(avatars2[0], 2);
                Cp2.transform.position = new Vector2(0, 1.85f);
                y = 1;
            }
            else if (Input.GetKeyDown(keyP2[2]) && CP1 != 2)
            {
				MouseOver.Play ();
                setCharClear(2);
                setCharActive(avatars2[1], 2);
                Cp2.transform.position = new Vector2(-2, -0.15f);
                y = 2;

            }
            else if (Input.GetKeyDown(keyP2[3]) && CP1 != 3)
            {
				MouseOver.Play ();
                setCharClear(2);
                setCharActive(avatars2[2], 2);
                Cp2.transform.position = new Vector2(2, -0.15f);
                y = 3;
            }
            else if (Input.GetKeyDown(keyP2[1]) && CP1 != 4)
            {
				MouseOver.Play ();
                setCharClear(2);
                setCharActive(avatars2[3], 2);
                Cp2.transform.position = new Vector2(0, -2.15f);
                y = 4;
            }
        }
    }

    void checkBothSel()
    {
        if(p1Selected && p2Selected && !wait)
        {
            readyTime = time;
            wait = true;
            Debug.Log("Both Selected");
            
        }
    }

    void checkWait()
    {
        if(wait && time >= readyTime + 2f)
        {
            Debug.Log("Advance to next scene...");
            wait = false;
            SceneManager.LoadScene("Cfield");
        }
    }

    void setCharActive(GameObject c, int p)
    {
        if (p == 1)
            c.transform.position = P1Pos;
        if (p == 2)
            c.transform.position = P2Pos;
    }

    void setCharClear(int p)
    {
        Vector2 clearPos = new Vector2(0, -8.5f);
        if (p == 1)
        {
            foreach(GameObject a in avatars1)
                a.transform.position = clearPos;
        }
        if(p == 2)
        {
            foreach (GameObject a in avatars2)
                a.transform.position = clearPos;
        }
    }


}
