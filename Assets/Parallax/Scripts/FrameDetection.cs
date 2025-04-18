using UnityEngine;

public class FrameDetection : MonoBehaviour
{
    
    [SerializeField] private ParallaxBackground _ParallaxBackground;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            collision.transform.position = new Vector3(_ParallaxBackground.movePosition, collision.transform.position.y, 0);
        }
    }

}
