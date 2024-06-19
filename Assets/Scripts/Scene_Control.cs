using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Control : MonoBehaviour {

    public void goCcharacter()
    {
        SceneManager.LoadScene("playerSelect");
    }

    public void goCfield()
    {
        SceneManager.LoadScene("Cfield");
    }

    public void goMapFire()
    {
        SceneManager.LoadScene("scene1fire");
    }

    public void goMapSnow()
    {
        SceneManager.LoadScene("scene1ice");
    }

    public void goMapEarth()
    {
        SceneManager.LoadScene("scene1earth");
    }

    public void goMapWind()
    {
        SceneManager.LoadScene("scene1wind");
    }

    public void goMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void exit()
    {
        Application.Quit();
    }

}
