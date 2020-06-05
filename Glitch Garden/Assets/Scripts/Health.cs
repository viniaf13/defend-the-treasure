using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float characterHealth = 100f;
    [SerializeField] float deathDelay = 1f;

    private bool dead = false;

    private IEnumerator Die()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)   animator.SetTrigger("Death");

        yield return new WaitForSeconds(deathDelay);
        Destroy(gameObject);
    }

    public void DealDamage(float damage)
    {
        characterHealth -= damage;
        if (characterHealth <= 0 && !dead)
        {
            dead = true;
            StartCoroutine(Die());
        }
    }

    public void DestroyCollider()
    {
        Collider2D enemyCollider = GetComponent<Collider2D>();
        if (enemyCollider != null)
        {
            Destroy(enemyCollider);
        }
    }

}
