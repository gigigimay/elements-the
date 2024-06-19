using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_ulti_control : MonoBehaviour
{
	public float speedX;

    // Use this for initialization
    public void Start()
    {
		this.GetComponent<CircleCollider2D> ().enabled = false;
        this.transform.localScale = new Vector3(0, 0, 0);
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    float timer;

    public void Update()
    {
        timer += Time.deltaTime;
        bigger();
    }

    public void bigger()
	{
		Vector3 newsize = new Vector3 (0.8f, 0.8f, 0.8f);

		if (timer < 1f) {
			this.transform.localScale = Vector2.Lerp (this.transform.localScale, newsize, 2 * Time.deltaTime);

		} else if (timer >= 1f) {

			this.GetComponent<CircleCollider2D> ().enabled = true;
			this.GetComponent<Rigidbody2D> ().gravityScale = 0.2f;
			this.transform.Translate(speedX,0,0);

		}
	}
}

