using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopSoundSelect : MonoBehaviour {
	public AudioSource BG_L;
	public AudioSource BG_R;
	public AudioSource EF_L;
	public AudioSource EF_R;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (SceneManager.GetActiveScene ().buildIndex);
		if (SceneManager.GetActiveScene ().buildIndex != 3 && SceneManager.GetActiveScene ().buildIndex != 4) {
			BG_L.Stop ();
			BG_R.Stop ();
		}
	}
}
