using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class DiceControllerTest : MonoBehaviour
{

    private static Controls controller;
    private bool isDiceRolling = false;
    private Animator animator;
    [SerializeField] private SpriteRenderer effectSprite;
    [SerializeField] private GameObject goodParticles;
    [SerializeField] private GameObject neutralParticles;

    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = new Controls();
        controller.Player.Space.performed += ctx => SpinDice();
        controller.Player.Space.canceled += ctx => RollDice();
    }

    private void SpinDice()
    {
        // We don't want to let the player roll the dice unlimited times back-to-back
        if (isDiceRolling)
            return;

        isDiceRolling = true;
        effectSprite.enabled = false;
        animator.Play("Roll");
    }

    private void RollDice()
    {
        // If the dice is not rolling, or the current animator clip isnt roll,
        // then we cannot end the roll.
        if (!isDiceRolling || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Roll")
            return;

        animator.Play("roll finishing");
        StartCoroutine(CanRollDiceAgain());
    }

    IEnumerator CanRollDiceAgain()
    {
        // These values are hardcoded based on the "roll finishing" anim
        // and other timings. DO NOT CHANGE.
        yield return new WaitForSecondsRealtime(1f);

        ToggleParticles(0, true);

        yield return new WaitForSecondsRealtime(0.1f);

        ShowIcon();

        yield return new WaitForSecondsRealtime(0.1f);

        ToggleParticles(0, false);

        yield return new WaitForSecondsRealtime(0.5f);
        isDiceRolling = false;
    }

    void ToggleParticles(int neutrality, bool on)
    {
        GameObject ps = neutralParticles;
        switch (neutrality)
        {
            default:
                // true neutral
                // ps is already set, dont need to do anything
                break;
            case 1:
                // good
                ps = goodParticles;
                break;
            case 2:
                // bad
                break;
        }

        if (on)
        {
            ps.SetActive(true);
        }
        else
        {
            ps.SetActive(false);
        }
    }

    private void ShowIcon()
    {
        effectSprite.enabled = true;
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