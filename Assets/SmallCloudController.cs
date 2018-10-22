using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCloudController : MonoBehaviour {


    BoxCollider2D BoxCollider;
    GameObject player;

    // Use this for initialization
    void Start () {
        this.player = GameObject.Find("cat");
        this.BoxCollider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (this.player.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            this.BoxCollider.enabled = false;
        }
        else
        {
            this.BoxCollider.enabled = true;
        }
    }
}
