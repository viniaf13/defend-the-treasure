using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float levelTime = 10f;
    private bool isLevelFinished = false;

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
            isLevelFinished = true;
            slider.GetComponent<Animator>().SetBool("isLevelFinished", true);
        }
    }

    public bool IsLevelOver()
    {
        return isLevelFinished;
    }
}
