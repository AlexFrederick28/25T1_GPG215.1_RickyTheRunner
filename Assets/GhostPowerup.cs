using UnityEngine;

public class GhostPowerup : MonoBehaviour
{
    public float speed = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.CompareTag("Player"))
     Destroy(gameObject);
    }
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
