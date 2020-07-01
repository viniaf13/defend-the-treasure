using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = default;
    [SerializeField] Color32 unselectedColor = default;

    private void Start()
    {
        CreateCostLabel();
    }

    private void CreateCostLabel()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText) return;
        costText.text = defenderPrefab.GetCost().ToString();
    }

    //Highlight the defender selected ans sets it on defender spawner
    private void OnMouseDown()
    {
        DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();

        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = button.unselectedColor;
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

}
