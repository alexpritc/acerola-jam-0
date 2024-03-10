using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // give time for gamemanager to instantiate
       Invoke("LoadMenu", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadMenu(){
        GameManager.Instance.LoadScene("MainMenu");
    }
}
