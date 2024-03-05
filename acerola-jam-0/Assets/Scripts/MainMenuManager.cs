using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenuManager : MonoBehaviour
{
    private static Controls controller;

    [SerializeField] CircleBarController[] buttons;
    int buttonIndex = 0;
    CircleBarController selectedButton;

    [SerializeField] Color32 disabledColor;
    [SerializeField] Color32 enabledColor;

    private void Start()
    {
        selectedButton = buttons[buttonIndex];
        EnableButtons();
    }
    // Start is called before the first frame update
    void Awake()
    {
        controller = new Controls();
        controller.Player.SpaceTap.performed += ctx => NextButton();
    }

    void NextButton()
    {
        buttonIndex++;
        if (buttonIndex >= buttons.Length)
        {
            buttonIndex = 0;
        }
        selectedButton = buttons[buttonIndex];
        EnableButtons();
    }

    void EnableButtons()
    {
        foreach (var button in buttons)
        {
            button.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
            button.enabled = false;
            button.fill.transform.localPosition = button.startPos;
            button.gameObject.GetComponent<SpriteRenderer>().color = disabledColor;
        }

        selectedButton.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        selectedButton.enabled = true;
        selectedButton.gameObject.GetComponent<SpriteRenderer>().color = enabledColor;

    }

    public void LoadLevel(string levelName)
    {
       SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
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
