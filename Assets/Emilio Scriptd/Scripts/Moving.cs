using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.CompareTag("Player"))
     Destroy(gameObject);
    }
}


