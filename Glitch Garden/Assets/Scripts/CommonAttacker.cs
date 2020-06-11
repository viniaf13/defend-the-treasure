using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAttacker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Defender>())
        {
            GetComponent<Enemy>().AttackMode(other.gameObject);
        }
    }
}
