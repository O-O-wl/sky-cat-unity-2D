using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{

    // Use this for initialization
    public GameObject cloudPrefab;
    public GameObject SilmePrefab;
    public GameObject fishPrefab;
    public GameObject magnetPrefab;
    public GameObject smallcloudPrefab;
    public GameObject flag;
    public GameObject shieldPrefab;
    bool sponSlime;
    int sponCount=0;
    float sponSpan;
    float sponDelta;

    bool sponFish;
    float fishDelta;
    float fishSpan=0.03f;
    int fishCount = 0;

    public bool restart;
    Vector3[] cloudVector = {
        new Vector3(-7f, 13.5f, 0),new Vector3(-7,12,0),new Vector3(-5,10.5f,0),new Vector3(-2.5f,12,0),
        new Vector3(-1,13,0),new Vector3(1,14,0),new Vector3(-3,9),new Vector3(-1.2f,9),
        new Vector3(2.2f,8,0),new Vector3(4,8,0),new Vector3(-1.8f,6,0),new Vector3(0,6,0),
        new Vector3(6.8f,5.5f,0),new Vector3(-4,5,0),new Vector3(-5,3,0),new Vector3(-3.3f,2,0),
        new Vector3(-1.6f,3,0),new Vector3(0.2f,3,0),new Vector3(2,3,0),new Vector3(5,2,0)};

    Vector3[] slimeVector = {
        new Vector3(2f,1,0),new Vector3(1,4,0),new Vector3(0,7,0),new Vector3(4.3f,8.5f,0),new Vector3(-1,9.5f,0)
    };
    Vector3[] fishVector = {
        new Vector3(2,9.5f,0),new Vector3(6,7,0),new Vector3(7.6f,7,0),new Vector3(6.8f,7,0),
        new Vector3(-1.7f,4,0),new Vector3(-6.5f,6,0),new Vector3(-4,7,0),new Vector3(-2.5f,13,0),
        new Vector3(3,13,0),new Vector3(3.5f,6,0),new Vector3(2,6,0),new Vector3(0,1,0),
        new Vector3(1,16,0), new Vector3(3,15,0)
    };
    Vector3[] smallcloudVector = {
        new Vector3(1.3f,6.7f,0),new Vector3(0.5f,8.5f,0),new Vector3(-3.5f,11,0),new Vector3(-7.2f,4,0),new Vector3(2,6.7f,0),new Vector3(4.2f,1,0),new Vector3(5.2f,4.2f,0),
        new Vector3(-2.9f,0,0),new Vector3(-2.2f,0,0),new Vector3(-1.5f,0,0),new Vector3(-0.8f,0,0),
        new Vector3(-0.1f,0,0),new Vector3(0.6f,0,0),new Vector3(1.3f,0,0),new Vector3(2.0f,0,0),new Vector3(2.7f,0,0),
        new Vector3(-6.3f,-2,0),new Vector3(-7f,-2,0),new Vector3(-7.7f,-2,0),new Vector3(-5.5f,-0.5f,0),new Vector3(-4.1f,-0.5f,0),
        new Vector3(-4.8f,-0.5f,0),new Vector3(3.5f,1,0),new Vector3(-6.5f,4,0),new Vector3(4.5f,4.2f,0),new Vector3(-6,15,0),
        new Vector3(3.4f,0,0),new Vector3(-6,15,0),new Vector3(-6.2f,-0.5f,0),new Vector3(-5.6f,-2,0)
    };

    Vector3[] magnetVector = { new Vector3(3.5f, 2, 0), new Vector3(-1.8f, 7.7f, 0) };
    void Start()
    {
        this.sponSpan = 1;
        this.sponDelta = 0;
        this.sponSlime = true;
        this.restart = true;
        
        this.fishDelta = 0;
        this.fishSpan = 0.1f;
       // this.restart = true;
       /* for (int i = 0; i < cloudVector.Length; i++)
        {
            GameObject cloud = GameObject.Instantiate(this.cloudPrefab) as GameObject;
            cloud.transform.position = cloudVector[i];
        }
        for (int i = 0; i < fishVector.Length; i++)
        {
            GameObject fish = GameObject.Instantiate(this.fishPrefab) as GameObject;
            fish.transform.position = fishVector[i];
        }
        for (int i = 0; i < smallcloudVector.Length; i++)
        {
            GameObject smallcloud = GameObject.Instantiate(this.smallcloudPrefab) as GameObject;
            smallcloud.transform.position = smallcloudVector[i];
        }
        for (int i = 0; i < slimeVector.Length; i++)
        {
            GameObject silme = GameObject.Instantiate(this.SilmePrefab) as GameObject;
            silme.transform.position = slimeVector[i];
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(this.restart){
            CreateObject();
            restart = false;
        }

        if (this.sponSlime){
            this.sponDelta += Time.deltaTime;
            if (this.sponSpan < this.sponDelta)
            {
                if(this.sponCount==5){
                    this.sponCount = 0;
                    this.sponSlime = false;
                    GameObject flag = GameObject.Instantiate(this.flag) as GameObject;
                    flag.transform.position = new Vector3(-5.8f, 15.5f, 0);
                    return;

                }
                this.sponDelta = 0;


                   
                    GameObject silme = Instantiate(this.SilmePrefab) as GameObject;
                    silme.transform.position = slimeVector[sponCount];
                this.sponCount += 1;
            }
               



        }
      
        if (this.sponFish)
        {
            this.fishDelta += Time.deltaTime;
            if (this.fishSpan < this.fishDelta)
            {
                if (this.fishCount == fishVector.Length)
                {
                    this.fishCount = 0;
                    this.sponFish = false;
                    return;
                }
                this.fishDelta = 0;



                GameObject fish = Instantiate(this.fishPrefab) as GameObject;
                fish.transform.position = fishVector[fishCount];
                this.fishCount += 1;
            }




        }


    }


    public void CreateObject()
    {
        for (int i = 0; i < cloudVector.Length; i++)
        {
            GameObject cloud = GameObject.Instantiate(this.cloudPrefab) as GameObject;
            cloud.transform.position = cloudVector[i];
        }
        //for (int i = 0; i < fishVector.Length; i++)
        // {
        //     GameObject fish = GameObject.Instantiate(this.fishPrefab) as GameObject;
        //     fish.transform.position = fishVector[i];
        //  }
        for (int i = 0; i < smallcloudVector.Length; i++)
        {
            GameObject smallcloud = GameObject.Instantiate(this.smallcloudPrefab) as GameObject;
            smallcloud.transform.position = smallcloudVector[i];
        }
        for (int i = 0; i < magnetVector.Length; i++)
        {
            GameObject magnet = GameObject.Instantiate(this.magnetPrefab) as GameObject;
            magnet.transform.position = magnetVector[i];
        }


        GameObject shield = GameObject.Instantiate(this.shieldPrefab) as GameObject;
        shield.transform.position = new Vector3(4.8f, 5.5f, 0);
        //this.restart = true;
        this.sponSlime = true;
        this.sponFish = true;
    }
}
