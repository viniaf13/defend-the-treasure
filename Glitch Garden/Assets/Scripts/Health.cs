using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float characterHealth = 100f;

    void Update()
    {
        if (characterHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void DealDamage(float damage)
    {
        characterHealth -= damage;
    }

}
