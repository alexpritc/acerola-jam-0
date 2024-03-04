using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CircleBar2DController : MonoBehaviour
{
    [SerializeField] GameObject fill;
    private static Controls controller;
    bool moveForward = false;

    Vector2 startScale = new Vector2(0.1f, 0.1f);
    Vector2 endScale = new Vector2(0.8f, 0.8f);
    float stepUp = 0.005f;
    float stepDown = -0.005f;

    [SerializeField] bool fillImmediately = false;

    [SerializeField] Color32 fillColor;

    void Awake()
    {
        fill.GetComponent<SpriteRenderer>().color = fillColor;
        controller = new Controls();
        controller.Player.Space.performed += ctx => { if (fillImmediately) { FillImmediate(); } else { moveForward = true; } };
        controller.Player.Space.canceled += ctx => { if (fillImmediately) { ClearImmediate(); } else { moveForward = false; ; } };
    }

    void FillImmediate()
    {
        fill.transform.localScale = endScale;
        fill.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    void ClearImmediate()
    {
        fill.transform.localScale = startScale;
        fill.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (fillImmediately)
            return;

        fill.GetComponent<SpriteRenderer>().sortingOrder = atStart() ? -1 : 1;

        if (moveForward && !atEnd())
        {
            Fill(stepUp);
        }
        else if (!moveForward && !atStart())
        {
            Fill(stepDown);
        }
    }

    bool atStart()
    {
        return fill.transform.localScale.x <= startScale.x;
    }

    bool atEnd()
    {
        return fill.transform.localScale.x >= endScale.x;
    }

    void Fill(float scaleStep)
    {
        fill.transform.localScale += new Vector3(scaleStep, scaleStep, scaleStep);
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
