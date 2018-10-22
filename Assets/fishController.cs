using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fishController : MonoBehaviour {

    // Use this for initialization


    float Dx;
    float Dy;
    float R;
    
    float G;
    float B;
    public bool tracking;
    public int Point;
    GameObject GameDirector;
    public Color fishColor;
    public bool eat ;
    int updown;
    float boundSpan;
    float boundDelta;
    bool start=true;

	void Start () {
        this.tracking = false;
        this.eat = false;
        this.R = Random.Range(0.0f, 1.0f);
        this.G = Random.Range(0.0f, 1.0f);
        this.B = Random.Range(0.0f, 1.0f);
        this.boundSpan = 0.8f;
        this.boundDelta = 0;
        this.updown = 1;
        this.GameDirector = GameObject.Find("GameDirector");
        this.fishColor = new Color(this.R,this.G , this.B);
        this.Point = (int)((this.R + this.G + this.R) * 100);

           }
	
	// Update is called once per frame
	void Update () {

       

        if (this.tracking){
            this.Dx = GameObject.Find("cat").transform.position.x - transform.position.x;
            this.Dy = GameObject.Find("cat").transform.position.y - transform.position.y;
            transform.Translate(this.Dx /7,this.Dy / 7, 0);
            this.boundSpan = 100;
            
        }
        this.boundDelta += Time.deltaTime;
        if(this.boundSpan<this.boundDelta){
            this.boundDelta = 0;
            updown *= -1;

        }
        this.transform.Translate(0, 0.02f * updown, 0);
   
        if (this.start)
        {
          
            GetComponent<SpriteRenderer>().color = this.fishColor;
            this.start = false;
        }
    //   Debug.Log(this.Point);
		
	}
 



}

