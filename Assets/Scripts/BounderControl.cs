﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounderControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<p_Control>().hp = 0;
        }
        Destroy(other.gameObject);
    }
}
