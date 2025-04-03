using UnityEngine;
using UnityEngine.Events;

public class ObjectToCentre : MonoBehaviour
{
    [SerializeField] private GameObject centreObject;
    [SerializeField] private GameObject objectToCentre;

    [SerializeField] private float speed;

    public UnityEvent AddSpeed;

    private void OnEnable()
    {
        UpgradeEvents.UpgradeSpeedToCentre += SpeedUpgrade;
    }
    private void OnDisable()
    {
        UpgradeEvents.UpgradeSpeedToCentre -= SpeedUpgrade;
    }

    private void Start()
    {
        centreObject.transform.position = objectToCentre.transform.position;
    }

    private void Update()
    {
        MoveObjectToCentre();
    }

    private void SpeedUpgrade()
    {
        speed += 0.05f;
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
