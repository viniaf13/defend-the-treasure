using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Color32 unselectedColor = new Color32(87, 56, 56, 255);

    private void OnMouseDown()
    {
        DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();

        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = unselectedColor;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
