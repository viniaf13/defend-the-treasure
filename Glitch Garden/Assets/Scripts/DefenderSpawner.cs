using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] Defender defender = default;

    private void OnMouseDown()
    {
        //Get mouse click pos and snaps to grid
        Vector2 mouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 snappedClick = new Vector2 (Mathf.RoundToInt(mouseClick.x),
                                            Mathf.RoundToInt(mouseClick.y));
        SpawnDefender(snappedClick);
    }

    private void SpawnDefender(Vector2 defenderPosition)
    {
        Defender newDefender = Instantiate(defender, defenderPosition, Quaternion.identity) as Defender;
    }

}
