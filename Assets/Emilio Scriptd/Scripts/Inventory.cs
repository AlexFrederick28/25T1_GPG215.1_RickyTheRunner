using System.Collections;
using System.Collections.Generic;
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
                isFlying();
            
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
 
    IEnumerator isFlying()
    {
        yield return new WaitForSeconds(5);
        transform.position = new Vector3(-0.31f, 0f);
        capsuleCollider.enabled = true;
        circleCollider.enabled = true;
        rb.gravityScale = 5f;
    }
    private void Start()
    {
        StartCoroutine(isFlying());
    }
}
