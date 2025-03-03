using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    #region Variables

    public string coinRarity; // rarity

    [Tooltip("Amount of score the coin will give to the player")]
    public int scoreValue; // amount of score

    public AudioClip coinPickup; // audio

    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // checks to make sure the player collides with coin
        {
            Debug.Log("Coin: [" + coinRarity + "] Worth: [" + scoreValue + "]");
            ScoreboardManager.instance.AddScore(scoreValue);

            #region Sound Check
            if (coinPickup != null)
            {
                SoundManager.instance.sfxSource.PlayOneShot(coinPickup);
                Debug.Log("Sound Played.");
            }
            else
            {
                Debug.Log("Coin Sound Missing.");
            }
            #endregion 

            Destroy(gameObject);
        }
    }
}
