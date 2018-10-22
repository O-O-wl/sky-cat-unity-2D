
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    // Use this for initialization
    GameObject GameDirector;
    public GameObject barrierPrefab;
    bool getBarrier;
    AudioSource audio;
    public bool magnet;
    public bool protect;
    public float magnetDelta;
    public float magnetSpan = 10f;
    public AudioClip DeadPlayerSound;
    public AudioClip GetPointSound;
    public AudioClip DamagedPlayerSound;
    public AudioClip JumpSound;
    Animator animator;
    BoxCollider2D boxCol;
    CircleCollider2D circol;
    GameObject plusPoint;
   // AudioSource
    Rigidbody2D rigidbody2D;
    float jumpForce = 500.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 4.0f;

    public bool jump;

    bool damaged;
    float damagedSpan;
    float damagedDelta;



    public bool die;
    float dieSpan;
    float dieDelta;
    //float diePoint;

    int key;
    public int direction;
    void Start()
    {
        this.protect = false;
        this.jump = false;
        this.boxCol = GetComponent<BoxCollider2D>();
        this.circol = GetComponent<CircleCollider2D>();
        this.plusPoint = GameObject.Find("Point");
        this.GameDirector = GameObject.Find("GameDirector");
        this.getBarrier = false;
        this.audio = GetComponent<AudioSource>();

        this.damaged = false;
        this.animator = GetComponent<Animator>();
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.key = 0;

        this.damagedSpan = 1f;
        this.damagedDelta = 0;
        this.direction = 1;
        this.magnet = false;
        this.dieDelta = 0;
        this.die = false;
        this.dieSpan = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.getBarrier){
          

            //barrierPrefab.transform.position = new Vector3(-5.8f, 15.5f, 0);
        }
        if(rigidbody2D.velocity.y<0){
            this.jump = false;
        }
      
        if(transform.position.y<-10f&&this.die!=true&&gameObject.name=="cat"){
            this.rigidbody2D.velocity = new Vector3(0, 0, 0);
            Die();
           // GameObject.Find("hpGage").GetComponent<Image>().fillAmount = 0;
        }

        if (this.die)
        {
            this.rigidbody2D.velocity = new Vector3(0, rigidbody2D.velocity.y, 0);

            // this.dieDelta += Time.deltaTime;
            //if(this.dieDelta<0.5f){
            //    transform.Translate(0, 0.1f, 0);

            // }
            //  else{
            //    transform.Translate(0, -0.1f, 0);
            //   }
            this.dieDelta += Time.deltaTime;

            if (this.dieSpan < this.dieDelta)
            {
               // this.die = false;

                this.plusPoint.GetComponent<AudioSource>().clip = this.plusPoint.GetComponent<PointController>().GameOverSound;

                this.plusPoint.GetComponent<AudioSource>().Play();
                this.dieDelta = 0;
                this.dieSpan = 1000f;
                //Destroy(gameObject);
            }
        }
        if(this.magnet){
            if(!this.damaged){
                GetComponent<SpriteRenderer>().color = new Color(0, 1, 1);
            }
            this.magnetDelta += Time.deltaTime;
            if(this.magnetDelta>this.magnetSpan){
                this.magnet = false;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                this.magnetDelta = 0;
            }

        }

        this.key = 0;
        // 방향을 제외한 속도 
        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);

        // 플레이어방향에 따른 좌우 반전
        if (this.damaged)
        {

            this.damagedDelta += Time.deltaTime;
            // transform.Translate(0.1f*this.direction*-1, 0, 0);
            if (this.damagedSpan < this.damagedDelta)
            {
                this.damagedDelta = 0;
                this.damaged = false;
                
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            }
        }

     if(this.rigidbody2D.velocity.y > 0 ||this.die){
            this.circol.enabled=false;

        }
        else {
            this.circol.enabled = true;
           
        }
        if (Input.GetKeyDown(KeyCode.Space) && this.rigidbody2D.velocity.y == 0 )
        {
            this.animator.SetTrigger("JumpTrigger");
            this.jump = true;
            this.boxCol.isTrigger = true;
            this.plusPoint.GetComponent<AudioSource>().clip =this.JumpSound;

            this.plusPoint.GetComponent<AudioSource>().Play();
            rigidbody2D.AddForce(transform.up * jumpForce);
        }
      
        if (this.rigidbody2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;

        }
        else
        {
            this.animator.speed = 1.0f;
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            GameObject barrierPrefab = GameObject.Instantiate(this.barrierPrefab) as GameObject;
            //  this.getBarrier = true;
            this.protect = true;
            barrierPrefab.transform.position = transform.position;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.key = -1;
            this.direction = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.key = 1;
            this.direction = 1;
        }
        if (this.key != 0)
        {

            transform.localScale = new Vector3(this.key, 1, 1);
        }
        if(this.die){
            this.boxCol.enabled = false;
            this.circol.enabled = false;
        }

        //속도계산 
        // walkForce는 플레이어가 걸을 때 가하는 힘
        //speedx는 플레이어 속도 
        //velocity.x는 현재 리기드바디의 x로의 속도 
        //속도의 절대값을 플레이어의 속도

        if (speedx < this.maxWalkSpeed)
        {
            this.rigidbody2D.AddForce(transform.right * this.key * this.walkForce);
        }
    }


    // 생선아이템과 충돌할때의 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "magnetPrefab(Clone)" & collision is CircleCollider2D&this.magnet)
        {
            collision.GetComponent<magnetController>().tracking = true;

        }

            if (collision.gameObject.name == "magnetPrefab(Clone)" & collision is BoxCollider2D)
            {

              
                // GameObject.FindWithTag("SlimePrefab(Clone)").GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
                this.audio.clip = this.GetPointSound;
                this.audio.Play();
                this.magnet = true;
                Destroy(collision.gameObject);


            }
        if (collision.gameObject.name == "shieldPrefab(Clone)" & collision is CircleCollider2D & this.magnet)
        {
            collision.GetComponent<shieldController>().tracking = true;

        }

        if (collision.gameObject.name == "shieldPrefab(Clone)" & collision is BoxCollider2D)
        {


            // GameObject.FindWithTag("SlimePrefab(Clone)").GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            this.audio.clip = this.GetPointSound;
            this.audio.Play();
            //this.magnet = true;
            GameObject barrierPrefab = GameObject.Instantiate(this.barrierPrefab) as GameObject;
            barrierPrefab.transform.position = transform.position;
            //  this.getBarrier = true;
            this.protect = true;
            Destroy(collision.gameObject);
        }




        // 생선트리거

        if (collision.gameObject.name == "fishPrefab(Clone)" & collision is CircleCollider2D&this.magnet){
            collision.GetComponent<fishController>().tracking = true;
        }
        if (collision.gameObject.name=="fishPrefab(Clone)"& collision is BoxCollider2D)
        {

            this.plusPoint.GetComponent<Text>().text = "+" +this.GameDirector.GetComponent<GameDirector>().currentLevel*collision.GetComponent<fishController>().Point + "point";
            this.plusPoint.GetComponent<Text>().color = collision.GetComponent<fishController>().fishColor;
            this.plusPoint.GetComponent<PointController>().get = true;
           // GameObject.FindWithTag("SlimePrefab(Clone)").GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            this.audio.clip = this.GetPointSound;
            this.audio.Play();
            this.GameDirector.GetComponent<GameDirector>().inCreaseHp(collision.GetComponent<fishController>().Point);
            this.GameDirector.GetComponent<GameDirector>().score += this.GameDirector.GetComponent<GameDirector>().currentLevel * collision.GetComponent<fishController>().Point;
            this.plusPoint.GetComponent<PointController>().pointDelta = 0;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.name=="slimeAttack(Clone)"&&this.damaged!=true){

            this.damaged = true;
            this.audio.clip = this.DamagedPlayerSound;
            this.audio.Play();
            this.rigidbody2D.AddForce(transform.right * (collision.GetComponent<slimeAttack>().direction  * (300)));
            this.GameDirector.GetComponent<GameDirector>().deCreaseHp();
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 0.5f);
            collision.GetComponent<slimeAttack>().Touch();
        }

        // 목표점트리거
        if(collision.gameObject.name=="flagPrefab(Clone)"){
            //transform.position = new Vector3(30, 30, 30);
            this.plusPoint.GetComponent<Text>().text = "LEVEL UP!";
            this.plusPoint.GetComponent<Text>().color = new Color(1, 1, 1);
            this.plusPoint.GetComponent<PointController>().levelUp = true;
            this.GameDirector.GetComponent<GameDirector>().currentLevel += 1;
            Destroy(collision.gameObject);
            transform.position = new Vector3(-5.8f, 15.5f, 0);
            rigidbody2D.velocity = new Vector3(0, 0, 0);
            this.plusPoint.GetComponent<AudioSource>().clip= this.plusPoint.GetComponent<PointController>().LevelUpSound;
            this.GameDirector.GetComponent<GameDirector>().DestroyAllGameObjects();
            this.plusPoint.GetComponent<AudioSource>().Play();
            //this.plusPoint.GetComponent<PointController>().levelUpDelta = 0;
        }
        if (collision.gameObject.name == "snowPrefab(Clone)"){
            Destroy(collision.gameObject);
        }
        else{
            return;
        }
    }




    // 죽을때 실행되는 함수

    public void Die()
    {
        this.boxCol.enabled = false;
        this.circol.enabled = false;
        //gameObject.name = "cat(die)";
        this.audio.clip = this.DeadPlayerSound;
        this.audio.Play();
        //this.diePoint = transform.position.x;
        this.rigidbody2D.AddForce(transform.up * 500);
        this.die = true;
        this.rigidbody2D.velocity = new Vector3(0, rigidbody2D.velocity.y, 0);
        GameDirector.GetComponent<GameDirector>().gameOver();

        //this.GameDirector.GetComponent<GameDirector>().gameOver();
    }


    // 슬라임과의 충돌
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.damaged != true)
        {

            if (collision.gameObject.name == "SlimePrefab(Clone)")
            {
                if (this.protect)
                {
                 
                    return;

                }
                this.damaged = true;
                this.audio.clip = this.DamagedPlayerSound;
                this.audio.Play();
                this.rigidbody2D.AddForce(transform.right * (this.direction * (-1) * (300)));
                this.GameDirector.GetComponent<GameDirector>().deCreaseHp();
                GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 0.5f);
            }
        }


    }
}
