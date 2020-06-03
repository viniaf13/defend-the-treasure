using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] Defender defender = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        Vector2 mouseClick = GetSquareClicked();
        SpawnDefender(mouseClick);
    }

    private void SpawnDefender(Vector2 defenderPosition)
    {
        Defender newDefender = Instantiate(defender, defenderPosition, Quaternion.identity) as Defender;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }
}
