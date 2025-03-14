using UnityEngine;

public class NewParallax : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private Vector2 startPosition;



     void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }
    
}
