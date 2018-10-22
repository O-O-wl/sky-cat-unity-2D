using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class barrierController: MonoBehaviour {

    GameObject player;
    float destroyDelta;
    bool destory;
    float destroySpan = 1f;
	// Use this for initialization
	void Start () {
        this.destroyDelta = 0;
        this.player = GameObject.Find("cat");
        this.destory = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = this.player.transform.position;
        if(this.destory){
            this.destroyDelta += Time.deltaTime;
            if(this.destroyDelta>this.destroySpan){
                Destroy(gameObject);
                this.destory = false;
                this.player.GetComponent<PlayerController>().protect = false;
            }
        }
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.name == "slimeAttack(Clone)")
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            this.destory = true;
           
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "SlimePrefab(Clone)")
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);

            this.destory = true;
            
       
        }
    }



}
