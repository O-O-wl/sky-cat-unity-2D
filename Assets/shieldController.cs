using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldController : MonoBehaviour
{
    public bool tracking;
    int updown;
    float boundSpan;
    float boundDelta;
    float Dx;
    float Dy;
    // Use this for initialization
    void Start()
    {

        this.boundSpan = 0.8f;
        this.boundDelta = 0;
        this.updown = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tracking)
        {
            this.Dx = GameObject.Find("cat").transform.position.x - transform.position.x;
            this.Dy = GameObject.Find("cat").transform.position.y - transform.position.y;
            transform.Translate(this.Dx / 7, this.Dy / 7, 0);
            this.boundSpan = 100;

        }
        this.boundDelta += Time.deltaTime;
        if (this.boundSpan < this.boundDelta)
        {
            this.boundDelta = 0;
            updown *= -1;

        }
        this.transform.Translate(0, 0.02f * updown, 0);


    }
}
