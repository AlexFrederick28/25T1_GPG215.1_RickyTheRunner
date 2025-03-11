using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
  
 public void onPlay()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began))
            SceneManager.LoadScene(1);
    }
    public void Options()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began))
            SceneManager.LoadScene(2);

      void Quit()
        {
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began))
                Quit();
        }
          
    }
    public void Back()
    {
    if (Input.GetMouseButtonDown(0) || (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began))
        {
        SceneManager.LoadScene(0);
        }
    }
}
