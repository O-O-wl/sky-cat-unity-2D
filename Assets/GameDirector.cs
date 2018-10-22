using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameDirector : MonoBehaviour {
    public int score;
    GameObject hpGage;
    GameObject Score;
    GameObject player;
    GameObject Level;
    GameObject plusPoint;
    GameObject GameStarter;
    float scoreDelta;
    float scoreSpan;

    public int currentLevel;
	// Use this for initialization
	void Start () {
        this.GameStarter = GameObject.Find("GameStarter");

        this.scoreDelta = 0;
        this.scoreSpan = 1;

        this.hpGage = GameObject.Find("hpGage");

        this.score = 0;
        this.Score = GameObject.Find("Score");
        
        this.player = GameObject.Find("cat");

        this.Level = GameObject.Find("Level");

        this.currentLevel = 1;
        this.plusPoint = GameObject.Find("Point");
	}
    public void inCreaseHp(int point){
        float hp = point / 3000f+this.currentLevel;
        this.hpGage.GetComponent<Image>().fillAmount += hp;
    }
    public void deCreaseHp(){
        this.hpGage.GetComponent<Image>().fillAmount -= 0.07f*this.currentLevel;
    }
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetInt("level", this.currentLevel);
        PlayerPrefs.SetInt("score", this.score);


        this.Level.GetComponent<Text>().text ="LEVEL :" + this.currentLevel;
        if (Input.GetKeyDown(KeyCode.U))
        {
            this.currentLevel += 1;
            this.plusPoint.GetComponent<PointController>().levelUp = true;
        }


        if(this.hpGage.GetComponent<Image>().fillAmount<=0){
            this.player.GetComponent<PlayerController>().Die();
            this.hpGage.GetComponent<Image>().fillAmount =0.0001f;
        }
        this.scoreDelta += Time.deltaTime;
        if(this.scoreSpan<this.scoreDelta){
            this.scoreDelta = 0;
            this.score += 1*currentLevel;
        }
        
        this.Score.GetComponent<Text>().text = "Score:" + this.score;

		
	}

    public void gameOver(){
        this.plusPoint.GetComponent<PointController>().gameOver = true;
        this.plusPoint.transform.localPosition = new Vector3(5, 500, 0);
        this.plusPoint.transform.localScale = new Vector3(10, 10, 10);


    }
    public void DestroyAllGameObjects()
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            if(GameObjects[i].gameObject.name=="magnetPrefab(Clone)"| GameObjects[i].gameObject.name == "shieldPrefab(Clone)" | GameObjects[i].gameObject.name == "flagPrefab(Clone)"||GameObjects[i].gameObject.name == "AttackPrefab(Clone)"||GameObjects[i].gameObject.name=="slimeAttack(Clone)"||GameObjects[i].gameObject.name=="fishPrefab(Clone)"|| GameObjects[i].gameObject.name == "cloudPrefab(Clone)" || GameObjects[i].gameObject.name == "SlimePrefab(Clone)")
            Destroy(GameObjects[i]);
        }

        this.player.transform.position = new Vector3(-7f, 3f, 0);
        this.GameStarter.GetComponent<GameStarter>().CreateObject();



    }
}


