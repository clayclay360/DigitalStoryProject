using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorReset : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(ResetAnimator());
    }

    IEnumerator ResetAnimator()
    {
        animator.enabled = false;
        yield return null;
        animator.enabled = true;
    }
}
