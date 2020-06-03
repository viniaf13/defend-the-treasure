using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float characterHealth = 100f;
    [SerializeField] float deathDelay = 2f;

    private Animator animator = default;

    private void Start()
    {
        animator = GetComponent<Animator>();   
    }

    private IEnumerator Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Death");
            yield return new WaitForSeconds(deathDelay);
            Destroy(gameObject);
        }

    }

    public void DealDamage(float damage)
    {
        characterHealth -= damage;
        if (characterHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

}
