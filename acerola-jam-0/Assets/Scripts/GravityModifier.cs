using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    private bool flying;
    private Animator animator;

    private void Start()
    {
        GameManager.Instance.OnePhysical = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Gravity
             && !flying)
        {
            animator.SetBool("IsFlying", true);
            flying = true;
        }
    }
}
