using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGenerator : MonoBehaviour {
    public GameObject AttackPrefab;
    GameObject player;
    AudioSource audio;
    // Use this for initialization
    void Start () {
        this.player = GameObject.Find("cat");
        this.audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.A)){
            GameObject go=Instantiate(this.AttackPrefab) as GameObject;
           
            go.transform.localScale = new Vector3(this.player.GetComponent<PlayerController>().direction* 0.1f, 0.1f, 0.1f);
            this.audio.Play();
            go.transform.position = new Vector3(this.player.transform.position.x+ this.player.GetComponent<PlayerController>().direction*0.7f, this.player.transform.position.y,this.player.transform.position.z);           }
	}
}

