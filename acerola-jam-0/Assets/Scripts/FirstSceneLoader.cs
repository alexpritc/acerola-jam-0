using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // give time for gamemanager to instantiate
       Invoke("LoadMenu", 0.1f);
    }

    void LoadMenu(){
        GameManager.Instance.LoadScene("MainMenu");
    }
}
