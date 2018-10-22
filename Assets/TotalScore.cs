using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalScore : MonoBehaviour {
    int Final_Score;
    int Final_Level;
    int score;
    int level;
	// Use this for initialization
	void Start () {
        this.level = 0;
        this.score = 0;
        this.Final_Level = PlayerPrefs.GetInt("level");
        this.Final_Score = PlayerPrefs.GetInt("score");

	}
	
	// Update is called once per frame
	void Update () {

        if(this.level==this.Final_Level){
        }
     
        else{
            this.level += 1;
        }

        if (this.score == this.Final_Score)
        {
           
        }
        else if (this.score < this.Final_Score - 50)
        {
            this.score += 50;
        }
        else
        {
            this.score += 1;
        }
        GetComponent<Text>().text = "TOTAL\nLEVEL:" + this.level + "\nScore:" + this.score;
    }
}
