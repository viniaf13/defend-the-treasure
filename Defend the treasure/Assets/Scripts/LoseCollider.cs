using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            FindObjectOfType<Lives>().RemoveHeart();
        }
        Destroy(collision.gameObject, 2f);
    }
}
