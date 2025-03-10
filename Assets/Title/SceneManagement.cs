using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
  
 public void onPlay()
    {
        if (Input.GetMouseButtonDown(1) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            Debug.Log("LoadedSceneOne");
    }
    public void Options()
    {
        if (Input.GetMouseButtonDown(1) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            Debug.Log("LoadedOptions");
    }
    public void Quit()
    {
        if (Input.GetMouseButtonDown(1) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        Quit();
    }
}
