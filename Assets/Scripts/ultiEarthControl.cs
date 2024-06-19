using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultiEarthControl : MonoBehaviour
{



    // Use this for initialization
    public void Start()
    {
        this.GetComponent<PolygonCollider2D>().enabled = false;
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
        float n = 0.4f;
        Vector3 newsize = new Vector3(n, n, n);

        if (timer < 1f && timer > 0.5f)
        {
            this.transform.localScale = Vector2.Lerp(this.transform.localScale, newsize, 4 * Time.deltaTime);

        }
        else if (timer >= 1f)
        {

            this.GetComponent<PolygonCollider2D>().enabled = true;
            this.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

    }
}
