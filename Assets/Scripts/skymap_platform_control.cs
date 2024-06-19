using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skymap_platform_control : MonoBehaviour
{
    public int P;

    bool godown;
    bool goup;



    // Use this for initialization
    void Start()
    {
        if (P == 1)
            godown = true;
        else
            godown = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.rotation.z);
        if (P == 1)
        {
            if (this.transform.rotation.z >= 0.05f)
            {
                godown = true;
            }
            else if (this.transform.rotation.z <= -0.2f)
            {
                godown = false;
            }

            if (godown)
            {
                this.transform.Rotate(0, 0, -0.2f);
            }
            else
            {
                this.transform.Rotate(0, 0, 0.2f);
            }
        }

        else if (P == 2)
        {
            if (this.transform.rotation.z >= 0.2f)
            {
                godown = true;
            }
            else if (this.transform.rotation.z <= -0.05f)
            {
                godown = false;
            }

            if (godown)
            {
                this.transform.Rotate(0, 0, -0.2f);
            }
            else
            {
                this.transform.Rotate(0, 0, 0.2f);
            }
        }

        else if (P == 3)
        {
            this.transform.Rotate(0, 0, -0.2f);
        }

        else if (P == 4)
        {
            this.transform.Rotate(0, 0, 0.2f);
        }

        else if (P == 5)
        {
            this.transform.Rotate(0, 0, -0.5f);
        }

        else if (P == 6)
        {
            this.transform.Rotate(0, 0, 0.5f);
        }
    }
}
