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
        if (other.CompareTag("Small"))
        {
            Small();
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
        

        IEnumerator Fly()
        {
            yield return new WaitForSecondsRealtime(3f);
            transform.position = new Vector2(-0.31f, -3.31f);
            rb.gravityScale = 5f;
            capsuleCollider.enabled = true;
            circleCollider.enabled = true;
        }
        StartCoroutine(Fly());
    }
    public void Small()
    {
        transform.localScale = new Vector2(.7f, .7f);
    }
    IEnumerator howLong()
    {
        yield return new WaitForSeconds(3);
        transform.localScale = new Vector2(1f, 1f);
    }
    private void Start()
    {
        StartCoroutine(howLong());
    }
}
