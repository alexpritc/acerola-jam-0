using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IntroController : MonoBehaviour
{
    private static Controls controller;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = new Controls();
        controller.Player.SpaceTap.performed += ctx => SkipAnim();
    }

    void SkipAnim()
    {
       //Fetch the current Animation clip information for the base layer
       string clip = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        switch (clip) {
            default:
                break;
            case "friend-walk-in":
                animator.Play("friend-intro");
                break;
            case "friend-intro-1":
                animator.Play("friend-intro-2");
                break;
            case "friend-intro-2":
                animator.Play("friend-intro-3");
                break;
            case "friend-intro-3":
                animator.Play("friend_idle");
                break;
        }   

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
