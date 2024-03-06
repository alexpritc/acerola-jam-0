using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DiceControllerTest : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private SpriteRenderer effectSpriteRenderer;
    [SerializeField] private Sprite[] effectSprites;

    void Awake()
    {
        GetComponent<SpriteRenderer>().color = GameManager.Instance.colorPalettes[GameManager.Instance.DiceIndex];
        effectSpriteRenderer.color = GameManager.Instance.colorPalettes[GameManager.Instance.DiceIndex + 1];
        
        effectSpriteRenderer.sprite = effectSprites[GameManager.Instance.DiceIndex];

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
        yield return new WaitForSecondsRealtime(2.75f);

        ShowIcon();

        yield return new WaitForSecondsRealtime(0.2f);

        GameManager.Instance.LoadScene(GameManager.Instance.NextSceneCalculator());
    }

    private void ShowIcon()
    {
        effectSpriteRenderer.enabled = true;
    }
}