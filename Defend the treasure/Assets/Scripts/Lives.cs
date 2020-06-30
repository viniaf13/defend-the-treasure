using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
   public List<Transform> hearts = default;

   private int heartNumber = default;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            hearts.Add(child);
        }
        heartNumber = hearts.Count;
    }

    public void RemoveHeart()
    {
        if (heartNumber >= 0)
        {
            heartNumber--;
            hearts[heartNumber].GetComponent<SpriteRenderer>().enabled = false;
        }
        if (heartNumber <= 0)
        {
            heartNumber--;
            Lose();
        }      
    }

    private void Lose()
    {
        FindObjectOfType<LevelController>().HandleLoseCondition();
    }


    /* private void Awake()
     {
         if (FindObjectsOfType<HeartDisplay>().Length > 1)
         {
             Destroy(gameObject);
         }
         else
         {
             DontDestroyOnLoad(gameObject);
         }
     }*/
}
