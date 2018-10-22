using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {
    Rigidbody2D rigidbody2D;
    Animator animator;
    BoxCollider2D boxcol;
    public GameObject attack;
    GameObject player;

    GameObject GameDirector;
    bool die=false;
    int direction;
    float dieDelta;
    float dieSpan;
    float walkSpan;
    float walkDelta;
    float boundDelta;
    float boundSpan;
    float bound;

    float attackSpan;
    float attackDelta;

    int hp;
    float R;
    float G;
    float B;
    Color SlimeColor;
    bool damaged;
    float damagedSpan;
    float damagedDelta;

    RigidbodyConstraints2D originalConstraints;
    bool start;
    // Use this for initialization
    void Start()

    {
        this.attackSpan = 1.7f;
        this.attackDelta = 0;
        this.player = GameObject.Find("cat");
        this.R = Random.Range(0.0f, 1.0f);
        this.G = Random.Range(0.0f, 1.0f);
        this.B = Random.Range(0.0f, 1.0f);
        this.boxcol = GetComponent<BoxCollider2D>();
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.die = false;
        this.dieDelta = 0;
        this.dieSpan = 0.5f;
        this.start = true;
        this.GameDirector = GameObject.Find("GameDirector");
        this.originalConstraints = this.rigidbody2D.constraints;
        this.damaged = false;
        this.damagedDelta = 0;
        this.damagedSpan = 0.5f;
        this.SlimeColor = new Color(0,1,0);
        this.bound = 0.01f;
        this.boundSpan = 0.3f;
        this.boundDelta = 0;

        this.direction = -1;
        this.walkSpan = 1.2f;
        this.walkDelta = 0;
    }
	
	// Update is called once per frame
	void Update () {
        this.attackDelta += Time.deltaTime;
        if(this.attackDelta>this.attackSpan){
            GameObject attack = GameObject.Instantiate(this.attack) as GameObject;
            attack.transform.position = transform.position;
            attack.GetComponent<slimeAttack>().direction = this.direction;
            this.attackDelta = 0;
        }
        if (this.start)
        {
            this.hp = this.GameDirector.GetComponent<GameDirector>().currentLevel;
            this.start = false;
           
                GetComponent<SpriteRenderer>().color = this.SlimeColor;
                this.start = false;

        }
        if(this.player.GetComponent<Rigidbody2D>().velocity.y>0){
            this.rigidbody2D.constraints = this.originalConstraints | RigidbodyConstraints2D.FreezePositionY;
        }
        else{
            this.rigidbody2D.constraints = this.originalConstraints;
            //this.rigidbody2D.freezeRotation = flse;
           //this.rigidbody2D.constraints = RigidbodyConstraints.FreezeRotationX;
            //this.rigidbody2D.constraints = RigidbodyConstraints.FreezeRotationZ;
        }

        this.walkDelta += Time.deltaTime;
        if(this.walkSpan<this.walkDelta){
            this.direction = this.direction*-1;
            this.walkDelta = 0;
        }


        this.transform.localScale = new Vector3(this.direction*-1* 4, 4, 0);
        this.boundDelta += Time.deltaTime;
        if(this.boundDelta>this.boundSpan){
            this.bound *= -1;
            this.boundDelta = 0;
        }

        transform.Translate(this.direction *0.01f,this.bound, 0);
       
        if(this.damaged){
            this.damagedDelta += Time.deltaTime;
            if(this.damagedSpan<this.damagedDelta){
                this.damaged = false;
                this.damagedDelta = 0;
                GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
            }
        }


        if (this.die){
            this.dieDelta += Time.deltaTime;
            gameObject.name = "Silme(die)";
            if(this.dieSpan<this.dieDelta){
                Destroy(gameObject);
            }
        }
    
        
	}
  

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name=="AttackPrefab(Clone)")
        {
            this.hp -= 1;
            GetComponent<AudioSource>().Play();
            transform.Translate(-0.1f * this.direction*-1, 0, 0);
            Debug.Log("HP" + this.hp);
            if (this.hp == 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
                this.animator.SetTrigger("dieTrigger");
                transform.localScale = new Vector3(4.1f, 4.1f, 4.1f);
                this.die = true;
               
            }
            else {
                GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.45f, 0f);
                this.damaged = true;
            }
            other.GetComponent<AttackController>().Touch();
        }
       

    }
}
