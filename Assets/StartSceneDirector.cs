using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartSceneDirector : MonoBehaviour
{
    bool start;
  
    float startDelta;
    float startSpan;
    public Camera camera;
    // Use this for initialization
    void Start()
    {
       
        this.startSpan = 2f;
        this.startDelta = 0;
        this.start = false;
        this.camera.transform.position = new Vector3(0, 0, -10);

    }

    // Update is called once per frame
    void Update()
    {
       // this.main.positoin
      
        if (this.start){
            startDelta += Time.deltaTime;
        if (this.camera.transform.position.x > -7)
        {
            this.camera.transform.Translate(-0.1f, 0, 0);
        }
        if (this.camera.transform.position.y < 3)
        {
                this.camera.transform.Translate(0, 0.05f, 0);
            }

     if (this.startSpan<this.startDelta){
                SceneManager.LoadScene("InGame");
            }
        }

    }
    public void GameStart()
    {
        this.start = true;
        GetComponent<AudioSource>().Play();
        //GameObject.Find("Button").GetComponent<AudioSource>().Play();
        GameObject.Find("TItle").GetComponent<Text>().text = "";
        Destroy(GameObject.Find("Button"));
    }

}