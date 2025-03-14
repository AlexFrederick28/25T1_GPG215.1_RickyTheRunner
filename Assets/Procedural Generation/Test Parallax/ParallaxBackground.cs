using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private GameObject backgroundOne;
    [SerializeField] private GameObject backgroundTwo;
    [SerializeField] private GameObject frameDetection;


    public float movePosition;
    
    [SerializeField] private float speed;

    public bool outOfFrame;

    private void Update()
    {
        MoveBackground();

        ChangeBackgroundPosition();
    }

    private void MoveBackground()
    {
        
        Vector3 moveDirection = new Vector3(-21f - backgroundOne.transform.position.x, 0, 0).normalized;

        backgroundOne.transform.position += speed * Time.deltaTime * moveDirection;
        //backgroundTwo.transform.position += speed * Time.deltaTime * moveDirection;
       

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
