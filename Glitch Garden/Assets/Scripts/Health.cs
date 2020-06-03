using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float characterHealth = 100f;
    [SerializeField] int deathDelay = 2;

    private Animator anim = default;

    private void Start()
    {
        anim = GetComponent<Animator>();   
    }

    private IEnumerator Die()
    {
        if (anim != null)
        {
            anim.SetTrigger("Death");
            yield return new WaitForSeconds(2);
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
