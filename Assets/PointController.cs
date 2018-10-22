using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PointController : MonoBehaviour
{
    public AudioClip GameOverSound;
    public AudioClip LevelUpSound;
    public GameObject PointPrefab;
     GameObject GameDirector;
    float pointSpan;
    public float pointDelta;
    public bool get;

    float gameOverSpan;
    public float gameOverDelta;
    public bool gameOver;

    float levelUpSpan;
    public float levelUpDelta;
    public bool levelUp;
    Vector3 initScale;
    // Use this for initialization
    void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector");
         this.initScale = transform.localScale;
        this.levelUp = false;
        this.levelUpSpan = 2.0f;
        this.levelUpDelta = 0;
        this.gameOverSpan=5.0f;
        this.gameOverDelta=0;
        this.gameOver=false;

        this.pointSpan = 1.0f;
        this.get = false;
        this.pointDelta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.levelUp){
            transform.Translate(0, 0.1f, 0);
            transform.localScale *= 1.03f;//new Vector3(transform.localScale.x+1,)
            this.levelUpDelta += Time.deltaTime;
            if (this.levelUpSpan < this.levelUpDelta)
            {
                this.levelUp = false;
                transform.localPosition = new Vector3(5.0f, -10.0f, 0.0f);
                this.levelUpDelta = 0;
                transform.localScale = initScale;



                //디스트로이드메소드
               // this.GameDirector.GetComponent<GameDirector>().DestroyAllGameObjects();

            }
        }
        else if(this.gameOver){
                GetComponent<Text>().text = "GAME OVER";
                GetComponent<Text>().color = new Color(1, 0, 0);
            //GameObject.Find("hpGage").GetComponent<Image>().fillAmount = 0;
            GameObject.Find("hpGage").transform.Translate(100, 100, 100);

            //transform.localScale *= 1.03f;
            if (transform.localPosition!=new Vector3(5.0f,0,0)){
                transform.Translate(0, -50f, 0);
            }
            //transform.localScale *= 1.03f;//new Vector3(transform.localScale.x+1,)
            this.gameOverDelta += Time.deltaTime;
            if (this.gameOverSpan < this.gameOverDelta)
                {
                    this.gameOver = false;
                    transform.localPosition = new Vector3(5.0f, -10.0f, 0.0f);
                    this.gameOverDelta = 0;
                    transform.localScale = initScale;
                    SceneManager.LoadScene("GameOverScene");



                }
        }

        else if (this.get)
        {
            transform.Translate(0, 0.1f, 0);
            transform.localScale *= 1.01f;//new Vector3(transform.localScale.x+1,)
            this.pointDelta += Time.deltaTime;
            if (this.pointSpan < this.pointDelta)
            {
                this.get = false;
                transform.localPosition = new Vector3(5.0f, -10.0f, 0.0f);
                transform.localScale = initScale;

            }
        }
            else
            {
                GetComponent<Text>().text= "";
            }

    }
}
