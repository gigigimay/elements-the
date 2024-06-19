using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markControl : MonoBehaviour {
	public int playerNum;
    void Update()
    {
        if (this.transform.parent != null)
        {
            if (this.transform.parent.gameObject.transform.localScale.x > 0)
                this.transform.localScale = new Vector2(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y);
            else
                this.transform.localScale = new Vector2(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y);
        }
    }
}
