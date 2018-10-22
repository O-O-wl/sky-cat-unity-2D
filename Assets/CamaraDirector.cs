using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraDirector : MonoBehaviour {
    Camera camera;
    GameObject player;
	// Use this for initialization
	void Start () {
        this.player = GameObject.Find("cat");
	}
	
	// Update is called once per frame
	void Update () {
        if(this.player.GetComponent<PlayerController>().die!=true)
        transform.position = new Vector3(this.player.transform.position.x,this.player.transform.position.y, transform.position.z);
	}
}
