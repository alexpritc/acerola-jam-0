using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class CircleBarController : MonoBehaviour
{
    public GameObject fill;
    private static Controls controller;
    bool moveForward = false;

    // The default is for the circle buttons
    public Vector3 startPos = new Vector3(0f, 0f, 0.28f);
    public Vector3 endPos = new Vector3(0f, 0f, -0.01f);
    // Generally keep these the same
    public float stepUp = -0.002f;
    public float stepDown = 0.002f;

    public Color32 fillColor;

    public UnityEvent buttonFilled;
    bool hasButtonEventFired;

    void Awake()
    {
        Debug.Log(GameManager.Instance.DiceIndex);
        if (GameManager.Instance.IsDiceScene)
        {
            fill.GetComponent<MeshRenderer>().material.color = GameManager.Instance.colorPalettes[GameManager.Instance.DiceIndex + 1];
            foreach (var slider in GetComponentsInChildren<SpriteRenderer>())
            {
                slider.color = GameManager.Instance.colorPalettes[GameManager.Instance.DiceIndex];
            }
        }
        else
        {
            fill.GetComponent<MeshRenderer>().material.color = fillColor;

        }

        controller = new Controls();
        controller.Player.SpaceHold.performed += ctx => moveForward = true;
        controller.Player.SpaceHold.canceled += ctx => moveForward = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (atEnd() && hasButtonEventFired)
            return;

        if (moveForward && !atEnd())
        {
            Fill(stepUp);
        }
        else if (!moveForward && !atStart())
        {
            Fill(stepDown);
        }
    }

    public bool atStart()
    {
        return fill.transform.position.z >= startPos.z;
    }

    public bool atEnd()
    {
        bool end = fill.transform.position.z <= endPos.z;
        if (end && !hasButtonEventFired)
        {
            buttonFilled.Invoke();
            hasButtonEventFired = true;
        }

        return end;
    }

    void Fill(float zStep)
    {
        fill.transform.position += new Vector3(0f, 0f, zStep);
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
