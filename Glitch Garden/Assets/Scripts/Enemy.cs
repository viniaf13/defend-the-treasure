using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0f,2f)][SerializeField] float moveSpeed = 1f;
    [SerializeField] float damage = 20f;

    private GameObject currentTarget;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void AttackMode(GameObject target)
    {
       animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeTarget()
    {
        if (!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();
        if (health) health.DealDamage(damage);
    }
}
