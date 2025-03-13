using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    public void Sart()
    {
        SceneManager.LoadScene(1); // Game
    }

    public void Back()
    {
        SceneManager.LoadScene(0);// Title
    }
    public void Quit()
    {
        Quit();
    }
}
