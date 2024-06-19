using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultiWindControl : MonoBehaviour
{
    float timer;
    Rigidbody2D playerRB;
    bool moved;
    public float castTime;

    // Use this for initialization
    public void Start()
    {
        timer = 0;
        moved = false;
        playerRB = this.transform.parent.gameObject.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        timer += Time.deltaTime;


        if (timer >= castTime && !moved)
        {
            moved = true;
            this.GetComponent<BoxCollider2D>().enabled = true;
            playerRB.velocity = new Vector2(0, 0); //remove all previous force
            if (this.transform.localScale.x < 0) //set direction
            {
                playerRB.AddForce(Vector2.left * 600);
            }
            else
            {
                playerRB.AddForce(Vector2.right * 600);
            }
        }
    }
}

