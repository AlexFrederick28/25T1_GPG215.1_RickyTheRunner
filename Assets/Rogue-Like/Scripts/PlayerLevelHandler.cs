using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;
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

    public bool levelUp = false;
    public bool activateOnce = false;

    [SerializeField] private GameObject upgradeDisplay;

    public UnityEvent displayCards;
    public UnityEvent pauseGame;

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
            if (levelUp == false)
            {
                currentLevel++;
                experienceAmplifier = Mathf.RoundToInt(experienceCurve.Evaluate(Mathf.InverseLerp(0, maxLevel, currentLevel)) * maxExperience);
                levelUp = true;
                ShowUpgradeDisplay();
            }

        }
        HideUpgradeDisplay();
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
        if (levelUp == true && activateOnce == false)
        {
            Debug.Log("upgrading");
            upgradeDisplay.SetActive(true);
            pauseGame.Invoke();
            displayCards.Invoke();
            activateOnce = true;
        }
    }

    private void HideUpgradeDisplay()
    {
        if (levelUp == false)
        {
            upgradeDisplay.SetActive(false);
        }
    }

}
