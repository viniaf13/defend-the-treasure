using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender = default;
    private GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    //Cached reference
    ResourceDisplay resourcePool = default;

    private void Start()
    {
        resourcePool = FindObjectOfType<ResourceDisplay>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent) defenderParent = new GameObject(DEFENDER_PARENT_NAME);
    }

    private void OnMouseDown()
    {
        if (!defender) return; //TODO: Display defender not selected msg

        //Get mouse click pos and snaps to grid
        Vector2 mouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 snappedClick = new Vector2 (Mathf.RoundToInt(mouseClick.x),
                                            Mathf.RoundToInt(mouseClick.y));

        if (HasEnoughResources())
        {
            SpawnDefender(snappedClick);
        }
    }

    private void SpawnDefender(Vector2 defenderPosition)
    { 
        Defender newDefender = Instantiate(defender, defenderPosition, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
        resourcePool.SpendResources(defender.GetCost());
    }

    //Check if player has enough resources for the defender
    private bool HasEnoughResources()
    {
        int currentResource = resourcePool.GetTotalResources();

        return (currentResource >= defender.GetCost());
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

}
