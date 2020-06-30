using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperAttacker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block Defender")
        {
            GetComponent<Animator>().SetTrigger("isJumping");
        }
        else if (other.gameObject.GetComponent<Defender>())
        {
            GetComponent<Enemy>().AttackMode(other.gameObject);
        }
    }
}
