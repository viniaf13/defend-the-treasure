using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//This class was very lazily implemented. If I comeback to the game, I will redesign it.
public class TutorialScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tutorialTextbox = default;
    [SerializeField] GameObject nextButton = default;

    [SerializeField] Sprite[] tutorialSnapshots = default;
    [TextArea(5, 5)] [SerializeField] string[] tutorialTexts = default;

    private Image tutorialImage;
    private int currentTutorialStep = 0;

    private void Start()
    {
        tutorialImage = GetComponent<Image>();
        tutorialImage.sprite = tutorialSnapshots[currentTutorialStep];
        tutorialTextbox.text = tutorialTexts[currentTutorialStep];
    }
    public void LoadNextTutorialStep()
    {
        currentTutorialStep += 1;
        bool isTutorialOver = (currentTutorialStep == tutorialSnapshots.Length);
        if (isTutorialOver)
        {
            SkipTutorial();
            return;
        }
        tutorialImage.sprite = tutorialSnapshots[currentTutorialStep];
        tutorialTextbox.text = tutorialTexts[currentTutorialStep];

        nextButton.GetComponent<Button>().enabled = false;
        nextButton.GetComponent<Button>().enabled = true;
    }
    public void SkipTutorial()
    {
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        levelLoader.LoadMainMenu();
        levelLoader.LoadNextLevel();
    }
}
