using UnityEngine;

public class ObjectEditor : MonoBehaviour
{
    #region variables

    [Tooltip("Set the direction of travel")]
    [SerializeField] private Vector3 move;
    [Tooltip("Set the move speed for travel")]
    [SerializeField] private float speed;

    #endregion


    private void Update()
    {
        AddSpeedToPlatform();
    }

    void AddSpeedToPlatform()
    {
        transform.position += move * speed * Time.deltaTime;
    }

   
}
