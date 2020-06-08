using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject projectile = default;
    [SerializeField] GameObject firePos = default;
    [SerializeField] int resourceCost = 10;
    [SerializeField] bool isResourceGenerator = false;


    private EnemySpawner laneSpawner = default;
    Animator anim = default;

    private void Start()
    {
        SetLaneSpawner();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isResourceGenerator) return;

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
        GameObject newProj = Instantiate
            (projectile, firePos.transform.position, Quaternion.identity) as GameObject;
        newProj.transform.parent = transform;
    }

    private bool IsEnemyInLane()
    {
        return laneSpawner.transform.childCount > 0;
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
