using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkControl : MonoBehaviour {

	public int atkPlayerNum;	//Identify who used this attack , set by function 
	public int atkPower;		//Power of attack
	public float atkDuration;	//How long the attack last.

	void Start () {
		Destroy (this.gameObject, atkDuration);
	}

	void Update () {
		
	}
}
