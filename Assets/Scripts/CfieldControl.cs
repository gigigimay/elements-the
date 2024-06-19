using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CfieldControl : MonoBehaviour {

    public GameObject cursor;
    public GameObject SceneControlObject;

	public AudioSource EF_L;
	public AudioSource EF_R;
	public AudioSource MouseOver;

    int x = 3;
    float cursorpos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //select num
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
			MouseOver.Play ();
            switch (x)
            {
                case 0:
                    x = 1;
                    break;
                case 1:
                    x = 0;
                    break;
                case 2:
                    x = 4;
                    break;
                case 3:
                    x = 2;
                    break;
                case 4:
                    x = 3;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.RightArrow))
        {
			MouseOver.Play ();
            switch (x)
            {
                case 0:
                    x = 1;
                    break;
                case 1:
                    x = 0;
                    break;
                case 2:
                    x = 3;
                    break;
                case 3:
                    x = 4;
                    break;
                case 4:
                    x = 2;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.UpArrow))
        {
			MouseOver.Play ();
            switch (x)
            {
                case 0:
                    x = 2;
                    break;
                case 1:
                    x = 4;
                    break;
                case 2:
                    x = 0;
                    break;
                case 3:
                    x = 0;
                    break;
                case 4:
                    x = 1;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			MouseOver.Play ();
            switch (x)
            {
                case 0:
                    x = 3;
                    break;
                case 1:
                    x = 3;
                    break;
                case 2:
                    x = 0;
                    break;
                case 3:
                    x =1;
                    break;
                case 4:
                    x = 1;
                    break;
            }
        }


        //chance cursor
        switch (x)
        {
            case 0:
                cursor.transform.position = new Vector2(-2.271f, 1.372f);
                break;
            case 1:
                cursor.transform.position = new Vector2(2.227f, 1.443f);
                break;
            case 2:
                cursor.transform.position = new Vector2(-4.471f, -2.222f);
                break;
            case 3:
                cursor.transform.position = new Vector2(0f, -2.38f);
                break;
            case 4:
                cursor.transform.position = new Vector2(4.655f, -2.301f);
                break;
        }

        //selected
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.U))
        {
			EF_L.Play();
			EF_R.Play();
            goField(); 
        }

    }

    void goField()
    {
        switch (x)
        {
            case 0:
                SceneControlObject.GetComponent<Scene_Control>().goMapEarth();
                break;
            case 1:
                SceneControlObject.GetComponent<Scene_Control>().goMapWind();
                break;
            case 2:
                SceneControlObject.GetComponent<Scene_Control>().goMapFire();
                break;
            case 3:
                x = Random.Range(0, 5);
                goField();
                break;
            case 4:
                SceneControlObject.GetComponent<Scene_Control>().goMapSnow();
                break;
        }
    }
}
