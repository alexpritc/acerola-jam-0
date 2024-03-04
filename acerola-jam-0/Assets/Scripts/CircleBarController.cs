using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CircleBarController : MonoBehaviour
{
    [SerializeField] GameObject fill;
    private static Controls controller;
    bool moveForward = false;

    // The default is for the circle buttons
    [SerializeField] Vector3 startPos = new Vector3(0f, 0f, 0.28f);
    [SerializeField] Vector3 endPos = new Vector3(0f, 0f, -0.01f);
    // Generally keep these the same
    float stepUp = -0.002f;
    float stepDown = 0.002f;

    [SerializeField] Color32 fillColor;

    void Awake()
    {
        fill.GetComponent<MeshRenderer>().material.color = fillColor;
        controller = new Controls();
        controller.Player.Space.performed += ctx => moveForward = true;
        controller.Player.Space.canceled += ctx => moveForward = false;
    }


    // Update is called once per frame
    void Update()
    {
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
        return fill.transform.position.z >= startPos.z;
    }

    bool atEnd()
    {
        return fill.transform.position.z <= endPos.z;
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
