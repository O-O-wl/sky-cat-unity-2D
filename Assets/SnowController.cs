
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{


    int DropType = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        this.DropType = Random.Range(1, 3);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
        else if (this.DropType == 1)
        {
            transform.Translate(-0.2f, -0.1f, 0);

        }
        else
        {
            transform.Translate(0.1f, -0.1f, 0);
        }
    }
}
