using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float levelTime = 10f;
    private bool isSliderFinished = false;

    private Slider slider = default;
 
    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (isSliderFinished) return; 

        slider.value = Time.timeSinceLevelLoad / levelTime;
        if (slider.value == 1)
        {
            isSliderFinished = true;
            FindObjectOfType<LevelController>().TimerFinished();
            slider.GetComponent<Animator>().SetBool("isLevelFinished", true);
        }
    }
}
