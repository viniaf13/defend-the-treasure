using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender = default;
    [SerializeField] List <Defender> defendersSpawned = default;


    private void OnMouseDown()
    {
        if (!defender) return; //TODO: Display defender not selected msg

        //Get mouse click pos and snaps to grid
        Vector2 mouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 snappedClick = new Vector2 (Mathf.RoundToInt(mouseClick.x),
                                            Mathf.RoundToInt(mouseClick.y));

        if (IsSquareEmpty(snappedClick))
        {
            SpawnDefender(snappedClick);
        }

    }

    private void SpawnDefender(Vector2 defenderPosition)
    {
        Defender newDefender = Instantiate(defender, defenderPosition, Quaternion.identity) as Defender;
        defendersSpawned.Add(newDefender);
    }

    //Loops to all spawned defenders to check if the selected pos is available
    private bool IsSquareEmpty(Vector2 snappedClick)
    {
        if (defendersSpawned != null)
        {
            foreach(Defender defender in defendersSpawned)
            {
                Vector2 currentDefPos = defender.transform.position;
                if (currentDefPos == snappedClick)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

}
