using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Camera.main.backgroundColor = GameManager.Instance.colorPalettes[GameManager.Instance.DiceIndex + 1];
    }
}
