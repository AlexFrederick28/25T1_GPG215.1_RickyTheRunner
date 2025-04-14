using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class PlayerLevelHandler : MonoBehaviour
{
    [SerializeField] private int maxLevel;
    [SerializeField] private int maxExperience;

    [SerializeField] private int currentLevel;
    [SerializeField] private int requiredCoinsForLevelUp;
    [SerializeField] private int experienceAmplifier;

    [SerializeField] private AnimationCurve experienceCurve;

    private ScoreboardManager _ScoreboardManager;

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

        if (ScoreboardManager.currentScore >= requiredCoinsForLevelUp)
        {
            currentLevel++;
            experienceAmplifier = Mathf.RoundToInt(experienceCurve.Evaluate(Mathf.InverseLerp(0, maxLevel, currentLevel)) * maxExperience);
        }

    }

   
    private void GetReferences()
    {
        if (_ScoreboardManager == null)
        {
            _ScoreboardManager = FindFirstObjectByType<ScoreboardManager>();
        }
    }
}
