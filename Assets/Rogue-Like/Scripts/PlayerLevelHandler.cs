using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Jobs;
using UnityEngine.UI;
using static UnityEngine.Rendering.GPUSort;

public class PlayerLevelHandler : MonoBehaviour
{
    #region PlayerLevel

    [SerializeField] private int maxLevel;
    [SerializeField] private int maxExperience;

    public int currentLevel;
    [SerializeField] private int requiredCoinsForLevelUp;
    [SerializeField] private int experienceAmplifier;

    [SerializeField] private AnimationCurve experienceCurve;

    private ScoreboardManager _ScoreboardManager;
    private CardHandler _CardHandler;
    private ObjectSpawner _ObjectSpawner; 

    public bool levelUp = false;
    public bool activateOnce = false;

    [SerializeField] private GameObject upgradeDisplay;

    public UnityEvent displayCards;
    public UnityEvent pauseGame;

    #endregion

    private void Update()
    {
        GetReferences();
        ExperienceFormula();
    }

    private void ExperienceFormula()
    {
        requiredCoinsForLevelUp = experienceAmplifier;
        if (ScoreboardManager.currentScore >= requiredCoinsForLevelUp)
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
        if (_ScoreboardManager == null || _CardHandler == null || _ObjectSpawner == null)
        {
            _ObjectSpawner = FindAnyObjectByType<ObjectSpawner>();
            _CardHandler = FindAnyObjectByType<CardHandler>();
            _ScoreboardManager = FindAnyObjectByType<ScoreboardManager>();
        }
    }

    private void ShowUpgradeDisplay()
    {
        if (_CardHandler.cardsEmpty == false)
        {
            if (levelUp == true && activateOnce == false)
            {
                Debug.Log("upgrading");
                upgradeDisplay.SetActive(true);
                pauseGame.Invoke();
                displayCards.Invoke();
                _ObjectSpawner.AddLargeObjectToSpawn();
                _ObjectSpawner.AddCoinToSpawn();
                _ObjectSpawner.AddDangerObjectToSpawn();
                _ObjectSpawner.AddGroundObjectToSpawn();
                activateOnce = true;
            }
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
