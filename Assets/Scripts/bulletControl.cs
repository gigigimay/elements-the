using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour {

	public float speedX;

	void Update () {
		this.transform.Translate(speedX,0,0);
	}
}
