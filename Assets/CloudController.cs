using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {
    int state;
    AudioSource audio;
    bool audioOn = false;
    GameObject GameDirector;
    float crashDelta;
    float crashSpan;
    bool crash;
    BoxCollider2D BoxCollider;

    Rigidbody2D rigidbody2D;
    GameObject player;

    int bound;
    float boundDelta;
    float boundSpan;

    int Probability;
    bool existSlime;

    float soundDelta;
    float soundSpan;
    // Use this for initialization
    void Start () {
        this.state = (int)Random.Range(0, 50.0f);
        this.player = GameObject.Find("cat");
        GameDirector = GameObject.Find("GameDirector");
        this.BoxCollider = GetComponent<BoxCollider2D>();
        this.existSlime = false;
        this.audio = GetComponent<AudioSource>();
        this.bound = 1;
        this.boundSpan = 0.05f;
        this.boundDelta = 0;
        this.crash = false;
        this.crashSpan = 2.0f;
        this.crashDelta = 0;
    
        this.Probability = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //      Debug.Log(this.state);
        if(audioOn){
            soundDelta += Time.deltaTime;
            if(soundDelta>soundSpan){
                audioOn = false;
            }
        }
     
        if(this.player.GetComponent<Rigidbody2D>().velocity.y>0){
            this.BoxCollider.enabled = false;
        }
        else{
            this.BoxCollider.enabled = true;
        }
        this.Probability = this.GameDirector.GetComponent<GameDirector>().currentLevel;
        if (this.crash){

            GetComponent<SpriteRenderer>().color = new Color(0.9f,0.4f,0.4f);

            this.crashDelta += Time.deltaTime;
            this.boundDelta += Time.deltaTime;
            transform.Translate(0, this.bound * 0.01f, 0);
            if(this.boundSpan<this.boundDelta){
                this.bound *= -1;
                this.boundDelta = 0;
            }
            if(this.crashDelta>this.crashSpan){
                this.crashDelta = 0;
                Destroy(gameObject);
            }

        }
        
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.name=="SlimePrefab(Clone)"&&this.crash!=true){
            this.existSlime = true;
        }

        if (collision.gameObject.name=="cat")
        {
           
          //  Debug.Log("ssss");
            //Debug.Log(this.existSlime);
            if (this.existSlime != true&&this.crash!=true&&collision.collider is CircleCollider2D)
            {
                if (this.state <= this.Probability)
                {
                   //Debug.Log(this.Probability);
                    this.crash = true;
                    if (audioOn != true)
                    {
                        this.audio.Play();
                        audioOn = true;
                    }
                }
            }

        }
    }
}
