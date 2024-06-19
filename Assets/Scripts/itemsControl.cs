using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsControl : MonoBehaviour {

    public int itemID;

    public GameObject blink;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (!other.gameObject.GetComponent<p_Control>().anim.GetBool("Dead"))
            {
                Destroy(this.gameObject);
                blinkFX(this.gameObject);
                other.gameObject.GetComponent<p_Control>().itemEffect(itemID);
            }
        }
    }

    void blinkFX(GameObject spwnRef)
    {
        GameObject e = Instantiate(blink, spwnRef.transform.position, spwnRef.transform.rotation) as GameObject;
    }
}
