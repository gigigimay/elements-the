using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBlinking : MonoBehaviour {

    private float spriteBlinkingTimer = 0.0f;
    private float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
	private float spriteBlinkingTotalDuration = 1.0f;

	public bool startBlinking = false; //set to TRUE to start effect

	void Update()
	{ 
		if(startBlinking == true)
			SpriteBlinkingEffect();
	}

	private void SpriteBlinkingEffect()
	{
		spriteBlinkingTotalTimer += Time.deltaTime;
		if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
		{
			startBlinking = false;
			spriteBlinkingTotalTimer = 0.0f;
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   // according to your sprite

            //call resethurt function
            this.gameObject.GetComponent<p_Control>().resetHurt();
            this.gameObject.GetComponent<p_Control>().ResetAtk();

            return;
		}

		spriteBlinkingTimer += Time.deltaTime;
		if(spriteBlinkingTimer >= spriteBlinkingMiniDuration)
		{
			spriteBlinkingTimer = 0.0f;
			if (this.gameObject.GetComponent<SpriteRenderer> ().enabled == true) {
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;  //make changes
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   //make changes
			}
		}
	}
}
