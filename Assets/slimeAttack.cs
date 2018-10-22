using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeAttack : MonoBehaviour {



        public bool fire;
        public int direction;
        float span;
        float delta;
        // Use this for initialization
        void Start()
        {


           
            
            this.span = 1f;
            this.delta = 0;

        }

        // Update is called once per frame
        void Update()
        {

            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                Destroy(gameObject);
            }
            transform.Translate(this.direction * 0.1f, 0, 0);






        }

        public void Touch()
        {
            Destroy(gameObject);
        }
    }

