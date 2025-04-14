using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class PlayerLevelHandler : MonoBehaviour
{
    #region PlayerLevel

    [SerializeField] private int maxLevel;
    [SerializeField] private int maxExperience;

    [SerializeField] private int currentLevel;
    [SerializeField] private int requiredCoinsForLevelUp;
    [SerializeField] private int experienceAmplifier;

    [SerializeField] private AnimationCurve experienceCurve;

    private ScoreboardManager _ScoreboardManager;

    private bool levelUp = false;

    #endregion

    #region UpgradeUI

    [SerializeField] private GameObject upgradeDisplay;
    [SerializeField] private GameObject[] threeCardSlots;

    [SerializeField] private List<GameObject> bronzeCards;
    [SerializeField] private List<GameObject> silverCards;
    [SerializeField] private List<GameObject> goldCards;

    [SerializeField] private List<GameObject> discardPile;

    #endregion

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        ExperienceFormula();
    }

    private void ExperienceFormula()
    {
        requiredCoinsForLevelUp = experienceAmplifier;

        if (_ScoreboardManager.currentScore >= requiredCoinsForLevelUp)
        {
            currentLevel++;
            experienceAmplifier = Mathf.RoundToInt(experienceCurve.Evaluate(Mathf.InverseLerp(0, maxLevel, currentLevel)) * maxExperience);
            levelUp = true;
        }

    }

   
    private void GetReferences()
    {
        if (_ScoreboardManager == null)
        {
            _ScoreboardManager = FindFirstObjectByType<ScoreboardManager>();
        }
    }

    private void ShowUpgradeDisplay()
    {
        if (levelUp == true)
        {
            upgradeDisplay.SetActive(true);
            // Pause game
        }
        else
        {
            upgradeDisplay.SetActive(false);
            // Play game
        }
    }

    public void DrawCards()
    {
        
    }
}
