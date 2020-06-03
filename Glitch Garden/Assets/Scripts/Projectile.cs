using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.GetComponent<Enemy>()) && collider.GetComponent<Health>())
        {
            collider.GetComponent<Health>().DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
