using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiceController : MonoBehaviour
{

    private static Controls controller;
    private bool isDiceRolling = false;
    private Animator animator;
    [SerializeField] private SpriteRenderer effectSprite;
    [SerializeField] Sprite[] effectSprites;

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

        effectSprite.enabled = false;
        isDiceRolling = true;
        animator.Play("Roll");
    }

    private void RollDice()
    {
        if (!isDiceRolling)
            return;

        animator.Play("roll finishing");
        StartCoroutine(CanRollDiceAgain());
    }

    IEnumerator CanRollDiceAgain()
    {
        // TODO: add another condition so it waits for the event to spawn
        // This value is hardcoded based on the "roll finishing" anim
        yield return new WaitForSecondsRealtime(1.8f);
        PickEffect();
        Debug.Log("Can roll dice again");
        isDiceRolling = false;
    }
     
    void PickEffect()
    {
        int i = UnityEngine.Random.Range(0, effectSprites.Length);
        effectSprite.enabled = true;
        effectSprite.sprite = effectSprites[i];
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