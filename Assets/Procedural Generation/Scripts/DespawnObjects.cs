using UnityEngine;

public class DespawnObjects : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ObjectEditor>())
        {
            Destroy(collision.gameObject);

            Debug.Log("Destroy gameObject");
        }
    }
}
