using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowmotion : MonoBehaviour {
    private float Slomo = 0.1f;
    private float normTime = 1.0f;
    private bool doSlomo = false;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (doSlomo)
            {
                Time.timeScale = normTime;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                doSlomo = false;
          
            }
            
        }
        else
        {
            if(!doSlomo)
            {
                Time.timeScale = Slomo;
                Time.fixedDeltaTime = 0.5f * Time.timeScale;
                doSlomo = true;
            }
        }

    }

}
