using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private GameObject backgroundOne;
    [SerializeField] private GameObject backgroundTwo;
    [SerializeField] private GameObject frameDetection;


    public float movePosition;
    
    [SerializeField] private float speed;

    public bool outOfFrame;

    private void FixedUpdate()
    {
        MoveBackground();

        ChangeBackgroundPosition();
    }
    private void MoveBackground()
    {
        
        Vector3 moveDirectionOne = new Vector3(-21f - backgroundOne.transform.position.x, 0, 0).normalized;
        Vector3 moveDirectionTwo = new Vector3(-21f - backgroundTwo.transform.position.x, 0, 0).normalized;

        backgroundOne.transform.position += speed * Time.deltaTime * moveDirectionOne;
        backgroundTwo.transform.position += speed * Time.deltaTime * moveDirectionTwo;
       

    }

    private void ChangeBackgroundPosition()
    {
        if (backgroundOne.transform.position.x == -20)
        {
            Debug.Log("Background should move");
            backgroundOne.transform.position = new Vector3(movePosition, backgroundOne.transform.position.y, backgroundOne.transform.position.z);
        }
        if (backgroundTwo.transform.position.x == -20)
        {
            backgroundTwo.transform.position = new Vector3(movePosition, backgroundTwo.transform.position.y, backgroundTwo.transform.position.z);

        }

    }
}
