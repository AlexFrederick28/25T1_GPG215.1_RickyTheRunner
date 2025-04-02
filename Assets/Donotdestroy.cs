using UnityEngine;

public class Donotdestroy : MonoBehaviour
{
    public void Onload()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
