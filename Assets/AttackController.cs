using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackController : MonoBehaviour
{
    GameObject player;
    Animator animator;
    Rigidbody2D rigidbody2D;

    

    bool fire;
    int direction;
    float span ;
    float delta;
    // Use this for initialization
    void Start()
    {

        
        this.player = GameObject.Find("cat");
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.direction = this.player.GetComponent<PlayerController>().direction;
        this.span = 0.2f;
        this.delta = 0;

    }

    // Update is called once per frame
    void Update()
    {
       
        this.delta +=Time.deltaTime ;
        if(this.delta>this.span){
            Destroy(gameObject);
        }
            transform.Translate(this.direction * 0.3f, 0, 0);
      





    }

    public void Touch(){
        Destroy(gameObject);
    }
}

