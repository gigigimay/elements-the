using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemspawnControl : MonoBehaviour {

    float timer;
    float spwntime;
    public float delayitemspwn;
    public GameObject[] item;

	public AudioSource ItemDrop;

    void Start () {
        spwntime = 0;
	}
	

	void Update () {

        timer += Time.deltaTime;

		if(timer - spwntime >= delayitemspwn)
        {
			ItemDrop.Play ();
            spwntime = timer;
            this.transform.position = new Vector2(Random.Range(-8f, 8f), this.transform.position.y);
            GameObject Nitem = Instantiate(item[Random.Range(0,item.Length)], this.transform.position, this.transform.rotation) as GameObject;
        }
	}
}
