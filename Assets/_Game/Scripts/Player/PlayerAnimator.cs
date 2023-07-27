using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    PlayerMovement m_Movement;
    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Movement = GetComponent<PlayerMovement>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (m_Movement.moveDirection.x != 0 || m_Movement.moveDirection.y != 0)
        {
            m_Animator.SetBool("isMove", true);
            SpriteDerectionChecker();
        }
        else
        {
            m_Animator.SetBool("isMove", false);
            SpriteDerectionChecker();
        }
    }

    private void SpriteDerectionChecker()
    {
        if (m_Movement.moveDirection.x < 0)
        {
            m_SpriteRenderer.flipX = true; // flip player for left direction
        }
        else
        {
            m_SpriteRenderer.flipX = false;
        }
    }
}
