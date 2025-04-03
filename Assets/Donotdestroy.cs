using UnityEngine;

public class Donotdestroy : MonoBehaviour
{
    private void Start()
    {
     DontDestroyOnLoad(gameObject);
    }
}
