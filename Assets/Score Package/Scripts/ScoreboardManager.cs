using System.Collections;
using TMPro;
using UnityEngine;

// Nick - general manager for handling of the score including UI and changing the value

public class ScoreboardManager : MonoBehaviour
{

    #region Variables

    public static ScoreboardManager instance;

    [Tooltip("This is the player's current score")]
    public int currentScore; // current score for the player

    [Tooltip("For the text number that will show the score")]
    public TextMeshProUGUI scoreText; // timer UI

    public Leaderboard leaderboard;

    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // used to reset score when game starts
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(DeathRoutine());
        }
    }

    public void AddScore(int scoreAdd) // used to add score for the player
    {
        currentScore += scoreAdd; // add text

        scoreText.text = currentScore.ToString(); // change text

        //Debug.Log("Current score: [" + currentScore + "]");
    }

    IEnumerator DeathRoutine()
    {
        yield return leaderboard.SubmitScoreRoutine(currentScore);
        Debug.Log("Death Routine");
    }


}
