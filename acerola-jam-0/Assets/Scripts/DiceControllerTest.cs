using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DiceControllerTest : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private SpriteRenderer effectSprite;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void RollDice()
    {
        animator.Play("Roll");
        StartCoroutine(RollAnimationFinished());
    }

    IEnumerator RollAnimationFinished()
    {
        // These values are hardcoded based on the "roll finishing" anim
        // and other timings. DO NOT CHANGE.
        yield return new WaitForSecondsRealtime(2f);

        ShowIcon();
    }

    private void ShowIcon()
    {
        effectSprite.enabled = true;
    }
}