using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject projectile = default;
    [SerializeField] GameObject firePos = default;

    [SerializeField] int resourceCost = 10;
    public void Fire()
    {
        Instantiate(projectile, firePos.transform.position, Quaternion.identity);
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
