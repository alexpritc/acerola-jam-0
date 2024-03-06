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

    public int Score { get; set; }

    public int DiceIndex = -2;
    public bool IsDiceScene = false;

    public Color32[] colorPalettes;

    // Start is called before the first frame update
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        AudioManager = GetComponentInChildren<AudioManager>();
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName == "Dice")
        {
            IsDiceScene = true;
            DiceIndex += 2;
        }
        else
        {
            IsDiceScene = false;

        }

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenLink()
    {
        Debug.Log("Open URL");
    }

    public string NextSceneCalculator()
    {
        string nextLevel = "";

        switch (DiceIndex)
        {
            case 0:
                nextLevel = "Eyes";
                break;
            case 2:
                nextLevel = "WaitingRoom";
                break;
            case 4:
                break;
            default:
                break;
        }

        return nextLevel;
    }
}
