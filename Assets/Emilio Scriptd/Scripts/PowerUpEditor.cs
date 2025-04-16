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

    private PowerUps _PowerUps;

    private void Start()
    {
        GetReferences();
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
            GhostPower();

            Destroy(other.gameObject);
        }
        if (other.CompareTag("Shrink"))
        {
            ShrinkPower();

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
    public void GhostPower()
    {

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
    public void ShrinkPower()
    {
        transform.localScale = new Vector2(_PowerUps.shrinkSize, _PowerUps.shrinkSize);

        StartCoroutine(ShrinkDuration());
    }
    IEnumerator ShrinkDuration()
    {
        yield return new WaitForSeconds(_PowerUps.shrinkTime);
        transform.localScale = new Vector2(1f, 1f);
    }

    private void GetReferences()
    {
        if (_PowerUps == null)
        {
            _PowerUps = FindAnyObjectByType<PowerUps>();
        }
    }
}
