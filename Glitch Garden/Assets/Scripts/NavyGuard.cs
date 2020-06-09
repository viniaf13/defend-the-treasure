﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavyGuard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Defender>())
        {
            GetComponent<Enemy>().Attack(other.gameObject);
        }
    }
}
