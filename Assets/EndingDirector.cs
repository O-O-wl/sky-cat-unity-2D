using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingDirector : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButton(0))
        { SceneManager.LoadScene("InGame"); }   
    }

}
