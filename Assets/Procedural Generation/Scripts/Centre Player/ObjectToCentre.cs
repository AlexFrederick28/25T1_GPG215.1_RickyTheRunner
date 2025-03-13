using UnityEngine;

public class ObjectToCentre : MonoBehaviour
{
    [SerializeField] private GameObject centreObject;
    [SerializeField] private GameObject objectToCentre;

    [SerializeField] private float speed;

    private void Start()
    {
        centreObject.transform.position = objectToCentre.transform.position;
    }

    private void Update()
    {
        MoveObjectToCentre();
    }

    private void MoveObjectToCentre()
    {
        if (objectToCentre.transform.position.x != centreObject.transform.position.x)
        {
            Vector3 movePosition = new Vector3(centreObject.transform.position.x - objectToCentre.transform.position.x, 0f, 0f).normalized;

            objectToCentre.transform.position += speed * Time.deltaTime * movePosition;

            //Vector3 moveToCentre = new Vector3(1, 0, 0);

            //objectToCentre.transform.position += moveToCentre * speed * Time.deltaTime;
        }
        else if (objectToCentre.transform.position.x == centreObject.transform.position.x)
        {
            objectToCentre.transform.position = objectToCentre.transform.position;
        }
    }
}
