using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour {


    public GameObject snowPrefab;

float delta1 = 0;

float span1=0.1f;




// Use this for initialization
void Start()
    {
       
}

// Update is called once per frame
void Update()
{
    this.delta1 += Time.deltaTime;
    //this.span1 = 0.5f;
    float px = Random.Range(-8.0f, 7.0f);
    float py = Random.Range(2.0f, 7.0f);


    Vector3 snowVector = new Vector3(px, py, 0);
   // Vector3 snowRotation = new Vector3(0, 0, px*60);


    if (this.delta1 > this.span1)
    {
        this.delta1 = 0;
        GameObject Snow = Instantiate(snowPrefab) as GameObject;
        

        Snow.transform.position = snowVector;
        //    Snow.transform.Rotate(snowRotation);    
    }


}
}