using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;

public class PowerUpEditor : MonoBehaviour
{
    public static PowerUpEditor instance;
    [SerializeField] Collider2D circleCollider;
    [SerializeField] Collider2D capsuleCollider;
    [SerializeField] Rigidbody2D rb;

    [Tooltip("Reference found under the GameManager")]
    [SerializeField] private GameObject centreObject;

    [HideInInspector]
    public bool ghostPowerActive = false; 
    private bool shieldPowerActive = false;

    private PowerUps _PowerUps;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        if (ghostPowerActive == true)
        {
            StartCoroutine(CGhostPower());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield"))
        {
            AddShield();

            Destroy(other.gameObject);
        }
        if (other.CompareTag("DangerObject") && ShieldManager.shield != 0) // if player has shield
        {
            // other.gameObject.GetComponent<ObjectEditor>().pushPlayer = false;

            RemoveShield();
        }
        if (other.CompareTag("Ghost"))
        {
            ghostPowerActive = true;

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
        if (ShieldManager.shield != 3)
        {
            ShieldManager.shield++;
        }
    }
    public void RemoveShield()
    {
        if (ShieldManager.shield != 0)
        {
            ShieldManager.shield--;
        }
    }

    public IEnumerator CGhostPower()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();

        boxCollider2D.enabled = false;

        if (transform.position.y != centreObject.transform.position.y)
        {
            rigidbody2D.gravityScale = 0;

            Vector3 floatToMiddle = new Vector3(0, centreObject.transform.position.y - transform.position.y, 0).normalized;

            transform.position += 2 * Time.deltaTime * floatToMiddle;
        }

        yield return new WaitForSeconds(_PowerUps.ghostTime);

        rigidbody2D.gravityScale = 5;

        boxCollider2D.enabled = true;

        ghostPowerActive = false;
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
