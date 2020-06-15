using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float levelTime = 10f;

    private Slider slider = default;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelTime;

        if (slider.value == 1)
        {
            Debug.Log("Level finished: " + slider.value);
        }
    }
}
