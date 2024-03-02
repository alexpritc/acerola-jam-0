using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public AudioManager AudioManager { get; private set; }

    public bool Gravity { get; set; }

    public bool OnePhysical { get; set; }

    public int Score { get; set; }

    // Start is called before the first frame update
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Gravity = false;
            OnePhysical = false;
        }

        AudioManager = GetComponentInChildren<AudioManager>();
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
