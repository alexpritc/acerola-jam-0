using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class EyesController : MonoBehaviour
{
    public GameObject[] eyes;
    int index = 0;

    bool allEyesSpawned = false;

    private static Controls controller;

    public string nextScene;

    void Awake()
    {
        controller = new Controls();
        controller.Player.SpaceTap.performed += ctx => ToggleEye();
        controller.Player.SpaceHold.performed += ctx => { if (allEyesSpawned) { Blink(); }; };
    }

    public void ToggleEye()
    {
        if (index < eyes.Length)
        {
            // each eye will play their awake anim
            eyes[index].SetActive(true);

            index++;
            if (index >= eyes.Length)
            {
                allEyesSpawned = true;
            }
        }
    }

    public void Blink()
    {
        // all eyes blink 
        foreach (var e in eyes)
        {
            e.GetComponent<Animator>().Play("blink-2");
        }
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        // These values are hardcoded based on stuff
        // and other timings. DO NOT CHANGE.

        yield return new WaitForSecondsRealtime(1.5f);

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
