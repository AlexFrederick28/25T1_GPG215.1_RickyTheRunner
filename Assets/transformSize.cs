using UnityEngine;

public class transformSize : MonoBehaviour
{
    [SerializeField] Sprite sheild;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        float pixelsPerUnit = sheild.pixelsPerUnit * 16;
    } 
}
