using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] Collider2D circleCollider;
    [SerializeField] Collider2D capsuleCollider;
    [SerializeField] Rigidbody2D rb;
   [SerializeField] SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Add();
        }
        if (other.CompareTag("Bomb"))
        {
            Remove();
        }
        if (other.CompareTag("Ghost"))
        {
            canFly();
        }
    }
    public void Add()
    {
        SheildManager.sheild++;
    }
    public void Remove()
    {
        SheildManager.sheild--;
    }
    public void canFly()
    {
        transform.position = new Vector2( - 0.31f, 0f);
        rb.gravityScale = 0f;
        capsuleCollider.enabled = false;
        circleCollider.enabled = false;
        spriteRenderer.enabled = false;
        

        IEnumerator Fly()
        {
            yield return new WaitForSecondsRealtime(3f);
            transform.position = new Vector2(-0.31f, -3.31f);
            rb.gravityScale = 5f;
            capsuleCollider.enabled = true;
            circleCollider.enabled = true;
            spriteRenderer.enabled = true;
        }
        StartCoroutine(Fly());
    }
}
