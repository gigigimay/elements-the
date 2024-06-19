using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_Control : MonoBehaviour {

    //Character Element
    public int elementID;
    //0=fire 1=water 2=wind 3=earth

    //Player Identity
    public int playerNum;
	private float runSpeed;
	public int hp;
	public int charges;
	private bool atkBoosted;

    //Control Buttons
	public KeyCode[] keyBind = new KeyCode[5];
	/*	0:up   1:left   2:right   3:atk   4:ultimate   */

    //Components
    public Animator anim;
    private Rigidbody2D rb;
	private SpriteBlinking blinks;

	//Status
	private bool isInAir = true;
	private bool isDead  = false;
	private bool isAtking = false;
	private float timer = 0; //For chechking about jumping and landing
	//public static float timeenterfloor;

	//ulti var
	private float endx;
	private int u = 0;
    
    //Associated GameObjects
	public GameObject[] atkPrefab = new GameObject[3]; //0=normal 1=bullet 2=ulti
	public GameObject[] effects = new GameObject[2];
//	public BoxCollider2D footcollider;


    void Start()
	{
		hp = 5;
		runSpeed = 5;
		charges = 0;
		anim = this.GetComponent<Animator> ();
		rb = this.GetComponent<Rigidbody2D> ();
		blinks = this.GetComponent<SpriteBlinking> ();
	}

    void Update()
    {
		timer += Time.deltaTime;

        

		if (!isDead )
        {
			if (!isAtking && u == 0) {
				Run();
				Atk();
				Ultimate();
                if(!isInAir)
				Jump();
			}
        }

		//** GODLIKE
		if(Input.GetKey(KeyCode.Space)){
			charges = 3;
			atkBoosted = true;
		}
    }

    void Run()
	{
		if (!blinks.startBlinking || blinks.spriteBlinkingTotalTimer >= 0.05f) { //temporary immobilize player if player is hurting
			if (Input.GetKey (keyBind[1])) {
				this.transform.Translate (-0.8f * Time.deltaTime * runSpeed, 0, 0);
			} else if (Input.GetKey (keyBind[2])) {
				this.transform.Translate (0.8f * Time.deltaTime * runSpeed, 0, 0);
			} else if (Input.GetKeyUp (keyBind[1]) || Input.GetKeyUp (keyBind[2])) {
				anim.SetBool ("Running", false);
			}
			
			//set facing direction
			if (Input.GetKeyDown (keyBind[2])) {
				anim.SetBool ("Running", true);
				this.transform.localScale = new Vector2 (Mathf.Abs (this.transform.localScale.x), this.transform.localScale.y);
			} else if (Input.GetKeyDown (keyBind[1])) {
				anim.SetBool ("Running", true);
				this.transform.localScale = new Vector2 (-Mathf.Abs (this.transform.localScale.x), this.transform.localScale.y);
			}

		}
	}

    void Jump()
    {
        if (Input.GetKeyDown(keyBind[0]) && !isInAir)
        {
            rb.velocity = new Vector2(0, 0); //remove all previous force to informally fix flying bug
            rb.AddForce(Vector2.up * 400);
            anim.SetBool("Jumping", true);
            isInAir = true;
        }
    }

    public void ResetAtk(){
        isAtking = false;
        anim.SetBool("Atking", false);
        anim.SetBool("Ulti1", false);
        anim.SetBool("Ulti2", false);
        anim.SetBool("Ulti3", false);
		anim.SetBool("Hurting", false);
        u = 0;
	}

    void Atk()
	{
		if (!blinks.startBlinking || blinks.spriteBlinkingTotalTimer >= 0.05f){ //checck if player is hurting
			
			if (Input.GetKeyDown (keyBind[3]) && !isAtking) {
				anim.SetBool ("Atking", true);
				anim.SetBool ("Running", false);
				isAtking = true;
			}
		}
    }

	void AtkSpawn()		//Activate this function at the appropriate animation frame. //For NORMAL attack
	{ 
		float atkSpawnX = this.transform.localScale.x;
		if (atkSpawnX > 0) {
			atkSpawnX += 0.015f;
		} else {
			atkSpawnX -= 0.015f;
		}
		Vector2 atkSpawnPos = new Vector2 (this.transform.position.x + atkSpawnX, this.transform.position.y - 0.5f);

		GameObject atk = Instantiate (atkPrefab[0], atkSpawnPos, this.transform.rotation) as GameObject; //Spawn HITBOX for normal attack
		atk.GetComponent<AtkControl> ().atkPlayerNum = playerNum; //identify who used the attack

        //Super Special SHOOTING STAR attack
        if (atkBoosted)
        {
            atkBoosted = false;
            GameObject star = Instantiate(atkPrefab[1], atkSpawnPos, this.transform.rotation) as GameObject; //Spawn HITBOX
            star.GetComponent<AtkControl>().atkPlayerNum = playerNum; //identify who used the attack

            if (this.transform.localScale.x < 0) //set direction
            {
                star.GetComponent<bulletControl>().speedX *= -1f;
                star.transform.localScale = new Vector2(-Mathf.Abs(star.transform.localScale.x), star.transform.localScale.y);
            }

            //buff effect delete
            foreach (Transform child in this.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
	}

	private void OnCollisionEnter2D(Collision2D other) //Collision with floor
	{
		if (other.transform.CompareTag ("Floor") && isInAir ) {
			//ResetAtk ();
			
			isInAir = false;
            anim.SetBool("Jumping", false);
        }
	}

	void OnTriggerEnter2D (Collider2D other)		//got attacked
	{		
		if (other.gameObject.CompareTag ("Atk") && other.GetComponent<AtkControl> ().atkPlayerNum != playerNum) {
			Destroy (other.gameObject);

			if(!blinks.startBlinking){
				Hurt (other.transform.position.x, other.GetComponent<AtkControl> ().atkPower); //Call hurt function.

				GameObject hit = Instantiate(effects[0],this.transform.position,this.transform.rotation) as GameObject; 	//Create HIT effect
				if(other.transform.position.x > this.transform.position.x){												//Set direction for the effect
					hit.transform.localScale = new Vector2 (-Mathf.Abs (hit.transform.localScale.x), hit.transform.localScale.y);
				}
			}
		}
	}

	public void Hurt(float otherX, int power)   //otherX: for checking direction of knockback force
	{
        Debug.Log("hurt");
        hp -= power;

        anim.SetBool("Hurting", true);      //***BUG***
        anim.SetBool("Running", false);

        blinks.startBlinking = true;        //start blinking effect

        //Knockback
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(Vector2.up * 150);
        if (otherX > this.transform.position.x)
        {
            rb.AddForce(Vector2.left * 200);
        }
        else
        {
            rb.AddForce(Vector2.right * 200);
        }
    }

	public void resetHurt()
	{
		Debug.Log ("resethurt");
		anim.SetBool ("Hurting", false);
		if (hp <= 0) { 								//check Dead
			anim.SetBool ("Dead", true);

			isDead = true;
		}
	}

	void dead(){
		//Destroy (this.gameObject);
	}

	void Ultimate(){
		if (Input.GetKeyDown (keyBind[4]) && charges == 3) {
			charges = 0;
            u = 1;
            anim.SetBool("Ulti1", true);
            
            if (elementID == 0)
                ultiFire();
            else if (elementID == 1)
                ultiWater();
            else if (elementID == 2)
                ultiWind();
            else if (elementID == 3)
                ultiEarth();
        }
	}

	void ultianim() //Animation of Ultimate move control
	{
		if (u == 1)
		{
			anim.SetBool("Ulti1", false);
			anim.SetBool("Ulti2", true);
			u = 2;
		}
		else if(u == 2)
		{
			anim.SetBool("Ulti2", false);
			anim.SetBool("Ulti3", true);
			u = 3;
		}
		else if (u == 3)
		{
			anim.SetBool("Ulti1", false);
			anim.SetBool("Ulti2", false);
			anim.SetBool("Ulti3", false);
			u = 0;
		}
	}
		
	public void itemEffect(int itemID){  //Effect of item, called from itemsControl script;
        switch (itemID)
        {
            case 0: //hp
                if (hp < 5)
                    hp++;
                break;
            case 1: //ulti
                if (charges < 3)
                    charges++;
                break;
            case 2: //star
                atkBoosted = true;
                //buff effect
                Vector2 markPos = new Vector2(this.transform.position.x , this.transform.position.y + 0.8f);
                GameObject mark = Instantiate(effects[1], markPos, Quaternion.identity) as GameObject;
                mark.transform.SetParent(this.transform);
                break;
        }
	}

    private void ultiFire()
    {
        Vector2 spawnpos = new Vector2(this.transform.position.x, this.transform.position.y + 2);
        
        GameObject u = Instantiate(atkPrefab[2], spawnpos, this.transform.rotation) as GameObject;
        u.GetComponent<AtkControl>().atkPlayerNum = playerNum; //identify who used the attack
        u.GetComponent<fire_ulti_control>().bigger();

        if (this.transform.localScale.x > 0) //right faced
            u.GetComponent<fire_ulti_control>().speedX = 0.2f;
        else
            u.GetComponent<fire_ulti_control>().speedX = -0.2f;
    }

    private void ultiWater()
    {
        Vector2 spawnpos = new Vector2(this.transform.position.x, this.transform.position.y + 0.8f);
        GameObject u = Instantiate(atkPrefab[2], spawnpos, this.transform.rotation) as GameObject;
        Destroy(u.gameObject, 3);

        hp += 3;
        if (hp > 5)
            hp = 5;
    }

    private void ultiWind()
    {
        
        Vector2 spawnPos = new Vector2(this.transform.position.x, this.transform.position.y-0.5f);
        GameObject u = Instantiate(atkPrefab[2], spawnPos, Quaternion.identity) as GameObject;
        u.GetComponent<AtkControl>().atkPlayerNum = playerNum; //identify who used the attack
        u.transform.SetParent(this.transform);
    }
    private void ultiEarth()
    {
        Vector2 spawnpos = new Vector2(this.transform.position.x, this.transform.position.y + 1);

        GameObject u = Instantiate(atkPrefab[2], spawnpos, this.transform.rotation) as GameObject;
        u.GetComponent<AtkControl>().atkPlayerNum = playerNum; //identify who used the attack
        u.GetComponent<ultiEarthControl>().bigger();

        if(playerNum == 0)
        {
            u.layer = 9;
        }
        else
        {
            u.layer = 8;
        }
    }

    //reset paramiters
    public void resetSelf()
    {
        hp = 5;
        isInAir = true;
        isDead = false;
        isAtking = false;
        resetHurt();
        ResetAtk();
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        anim.SetBool("Dead", false);

        atkBoosted = false;
        //buff effect delete
        foreach (Transform child in this.transform)
            GameObject.Destroy(child.gameObject);
    }

}