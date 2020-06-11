using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject projectile = default;
    [SerializeField] GameObject firePos = default;
    [SerializeField] int resourceCost = 10;
    [SerializeField] bool noAttack = false;


    private EnemySpawner laneSpawner = default;
    Animator anim = default;

    private void Start()
    {
        SetLaneSpawner();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (noAttack) return;

        if (IsEnemyInLane())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
        
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate
            (projectile, firePos.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = transform;

        Animation projectileAnimation = newProjectile.GetComponent<Animation>();
        if (projectileAnimation != null) projectileAnimation.playAutomatically = true;
    }

    //Check if theres an enemy in front of the attacker
    private bool IsEnemyInLane()
    {
        if (laneSpawner.transform.childCount > 0)
        {
            foreach (Transform child in laneSpawner.transform)
            {
                if (child.transform.position.x > transform.position.x)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            if (transform.position.y == spawner.transform.position.y)
            {
                laneSpawner = spawner;
            }
        }
    }

    public int GetCost()
    {
        return resourceCost;
    }

    //Only for Sunny
    public void GenerateResources(int amount)
    {
        FindObjectOfType<ResourceDisplay>().AddResources(amount);
    }
}
