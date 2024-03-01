using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public string name;
    public Sprite diceSprite;
    public int numberOfTimesRolled = 0;
    public bool scoresPoints = false;
    public int numberOfPoints = 10;
    /// <summary>
    /// 0 = neutral,
    /// 1 = good, 
    /// 2 = bad
    /// </summary>
    public int neutrality = 0;

    private AudioSource audioSource;

    public AudioClip spawnNoise;
    public AudioClip idleNoise;

    private void Awake()
    {
        
    }

    

}
