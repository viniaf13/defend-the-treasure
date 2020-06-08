using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab = default;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    private bool keepSpawning = true;
    private IEnumerator Start()
    {
        while (keepSpawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Enemy newEnemy = Instantiate
                (enemyPrefab, transform.position, Quaternion.identity) as Enemy;

            //Instantiate as child
            newEnemy.transform.parent = transform;
        }
        
    }
}
