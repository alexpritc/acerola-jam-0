using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsController : MonoBehaviour
{
    private static Controls controller;

    public string nextScene;

    public SpriteRenderer rat;
    public Sprite rat1;
    public Sprite rat2;

    int spamCount = 0;
    int limit = 15;
    
    bool loadScene = false;

    void Awake()
    {
        controller = new Controls();
        controller.Player.SpaceSpam.performed += ctx => { if (spamCount < limit) { ToggleSprite(); } };
    }

    void ToggleSprite()
    {
        spamCount++;

        if (rat.sprite == rat1)
        {
            rat.sprite = rat2;
        }
        else
        {
            rat.sprite = rat1;
        }
    }

    void Update()
    {
        if (spamCount >= limit && !loadScene)
        {
            loadScene = true;
            rat.gameObject.GetComponent<Animator>().enabled = true;
            Invoke("NextScene", 4.5f);
        }
    }

    void NextScene()
    {
        GameManager.Instance.LoadScene(nextScene);
    }

    // Required for the input system.
    void OnEnable()
    {
        controller.Player.Enable();
    }

    void OnDisable()
    {
        controller.Player.Disable();
    }
}
