using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorialControl : MonoBehaviour
{
    
    public GameObject ConP;
    public GameObject Item;

	public AudioSource MouseOver;

    public Button Next;
    public Button Back;
    public Button Menu;

    public bool menu;

    void Start()
    {

        Item.SetActive(false);
        ConP.SetActive(true);

        menu = true;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.J))
        {
			MouseOver.Play ();
            ShowCon();
            //menu = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.L))
        {
			MouseOver.Play ();
            ShowItem();
            //menu = true;
        }

        if (menu && Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O))
        {
			MouseOver.Play ();
            gotoMenu();
        }
    }

    public void ShowItem()
    {
        Item.SetActive(true);
        ConP.SetActive(false);

        Next.GetComponent<Image>().enabled = false;
        Back.GetComponent<Image>().enabled = true;

    }

    public void ShowCon()
    {
        Item.SetActive(false);
        ConP.SetActive(true);
        
        Next.GetComponent<Image>().enabled = true;
        Back.GetComponent<Image>().enabled = false;

    }

    public void gotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}