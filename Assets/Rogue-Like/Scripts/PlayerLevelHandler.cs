using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class PlayerLevelHandler : MonoBehaviour
{
    [SerializeField] private int currentLevel;
    [SerializeField] private int requiredCoinsForLevelUp;
    

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
        
        requiredCoinsForLevelUp = (currentLevel * 10);

       
    }

   
    private void GetReferences()
    {
        if (_ScoreboardManager == null)
        {
            _ScoreboardManager = FindFirstObjectByType<ScoreboardManager>();
        }
    }
}
