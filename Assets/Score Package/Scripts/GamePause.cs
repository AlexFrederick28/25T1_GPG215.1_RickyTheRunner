using UnityEngine;
using UnityEngine.UI;

// Nick - simple script to change the time scale of the game from 0 - 1 / paused - unpaused


public class GamePause : MonoBehaviour
{

    [SerializeField] private Button pauseButton; // object that will have its image changed
    [SerializeField] private Image buttonImage; // reference to the actual image sprite on the button

    [Tooltip("a check for when the game is paused or not")]
    [SerializeField] private bool isPaused = false;

    [Header("Sprites")]
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite playSprite;


    public void Start()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        buttonImage = pauseButton.GetComponent<Image>();
    }

    public void TogglePause()
    {

        if (isPaused == false) // if game is Not paused
        {
            Time.timeScale = 0.0f; // pause game
            isPaused = true;

            //Debug.Log("Game Paused");

            if (pauseSprite != null)
            {
                buttonImage.sprite = pauseSprite;
            }

            else
            {
                //Debug.Log("Sprite Missing!");
            }
            
        }

        else if (isPaused == true) // if game is paused
        {
            Time.timeScale = 1.0f; // resume game
            isPaused = false;

            //Debug.Log("Game Resumed");

            if (playSprite != null)
            {
                buttonImage.sprite = playSprite;
            }

            else
            {
                //Debug.Log("Sprite Missing!");
            }

        }
       
    }

}
