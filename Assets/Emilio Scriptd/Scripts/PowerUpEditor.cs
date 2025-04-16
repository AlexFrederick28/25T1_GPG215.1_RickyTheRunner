using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PowerUpEditor : MonoBehaviour
{
    public static PowerUpEditor instance;
    [SerializeField] Collider2D circleCollider;
    [SerializeField] Collider2D capsuleCollider;
    [SerializeField] Rigidbody2D rb;

    [Space]
    [Header("Cards")]
    [SerializeField] private Card coin;
    [Space]
    [SerializeField] private Card ghost;
    [Space]
    [SerializeField] private Card shrink;
    [SerializeField] private float shrinkTime;
    [SerializeField] private float shrinkSize;
    [Space]
    [SerializeField] private Card shield;

    private void Update()
    {
        PowerStatus();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield"))
        {
            AddShield();

            Destroy(other.gameObject);
        }
        if (other.CompareTag("Bomb"))
        {
            RemoveShield();
        }
        if (other.CompareTag("Ghost"))
        {
            canFly();

            Destroy(other.gameObject);
        }
        if (other.CompareTag("Small"))
        {
            Small();

            Destroy(other.gameObject);
        }
    }
    public void AddShield()
    {
        ShieldManager.shield++;
    }
    public void RemoveShield()
    {
        ShieldManager.shield--;
    }
    public void canFly()
    {

        Debug.Log("FLYING");
        transform.position = new Vector2(-0.31f, -0.63f);
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
        transform.localScale = new Vector2(shrinkSize, shrinkSize);

        StartCoroutine(ShrinkDuration());
    }
    IEnumerator ShrinkDuration()
    {
        yield return new WaitForSeconds(shrinkTime);
        transform.localScale = new Vector2(1f, 1f);
    }

    private void PowerStatus()
    {
        // COIN
        if (coin.isBronze)
        {

        }
        else if (coin.isSilver)
        {

        }
        else if (coin.isGold)
        {

        }

        // GHOST
        if (ghost.isBronze)
        {

        }
        else if (ghost.isSilver)
        {

        }
        else if (ghost.isGold)
        {

        }

        // SHRINK
        if (shrink.isBronze)
        {
            // shrink duration stays as set in inspector
            // shrink size stays as set in inspector
        }
        else if (shrink.isSilver)
        {
            
        }
        else if (shrink.isGold)
        {
            
        }

        // SHIELD
        if (shield.isBronze)
        {

        }
        else if (shield.isSilver)
        {

        }
        else if (shield.isGold)
        {

        }
    }
}
