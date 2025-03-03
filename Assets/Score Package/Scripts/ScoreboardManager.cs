using TMPro;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{

    #region Variables

    public static ScoreboardManager instance;

    [Tooltip("This is the player's current score")]
    public int currentScore; // current score for the player

    [Tooltip("For the text number that will show the score")]
    public TextMeshProUGUI scoreText; // timer UI

    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }

    public void AddScore(int scoreAdd) // used to add score for the player
    {
        currentScore += scoreAdd; // add text

        scoreText.text = currentScore.ToString(); // change text

        Debug.Log("Current score: [" + currentScore + "]");
    }

}
