using UnityEngine;

public class FrameDetection : MonoBehaviour
{

    [SerializeField] private ParallaxBackground _ParallaxBackground;

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<ObjectEditor>())
        {
            Debug.Log("Collided");
            collision.gameObject.transform.position = new Vector3(_ParallaxBackground.movePosition, 0, 0);
        }
        
    }
}
