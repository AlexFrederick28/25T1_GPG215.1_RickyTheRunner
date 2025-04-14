using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{
    public ScoreboardManager scoreboardManager;


    private void Start()
    {
        scoreboardManager = FindAnyObjectByType<ScoreboardManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(scoreboardManager.DeathRoutine());
            //SceneManager.LoadScene(3);
        }
    }
}
