using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50f;

    private bool isItCloseRange = false;
    private float startTime; 

    private void Start()
    {
        if (GetComponentInParent<Defender>() == null) return;
        isItCloseRange = GetComponentInParent<Defender>().IsDefenderMelee();
        startTime = Time.time;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (isItCloseRange && (Time.time - startTime >= 0.15f))
        {
            Destroy(gameObject);
        }
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
