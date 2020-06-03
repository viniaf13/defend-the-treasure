using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] Defender defender = default;

    private void OnMouseDown()
    {
        Vector2 mouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SpawnDefender(mouseClick);
    }

    private void SpawnDefender(Vector2 defenderPosition)
    {
        Defender newDefender = Instantiate(defender, defenderPosition, Quaternion.identity) as Defender;
    }

}
