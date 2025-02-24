        using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothtime = 0.25f;
    private Vector3 Velocity = Vector3.zero;
    [SerializeField] Transform target;

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, smoothtime);
    }
}
