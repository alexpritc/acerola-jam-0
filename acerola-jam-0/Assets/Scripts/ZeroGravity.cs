using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : Effect
{
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.Instance.Gravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
