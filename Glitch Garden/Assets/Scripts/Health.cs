using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float baseHealth = 100f;
    [SerializeField] float deathDelay = 1f;

    private bool dead = false;
    private float characterHealth;
    
    //Increases Enemy health based on game difficulty. Defenders are not affected
    private void Awake()
    {
        if (GetComponent<Enemy>() != null)
        {
            characterHealth = baseHealth * PlayerPrefsController.GetGameDifficulty();
        }
        else
        {
            characterHealth = baseHealth;
        }
    }

    private IEnumerator Die()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)   animator.SetTrigger("isDead");

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
