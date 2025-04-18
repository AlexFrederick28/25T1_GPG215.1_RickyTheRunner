using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditor.ShaderGraph;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;

public class PowerUpEditor : MonoBehaviour
{
    public static PowerUpEditor instance;
    //[SerializeField] Collider2D circleCollider;
    [SerializeField] Collider2D playerCollider;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] AnimatorController ghostPlayer;

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
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color currentColour = Color.white;
        currentColour.a = 0.5f;
        spriteRenderer.color = currentColour;

        float yLevel = centreObject.transform.position.y;
        Vector3 floatToMiddle = new Vector3(transform.position.x, yLevel, transform.position.z);
        transform.position = floatToMiddle;

        yield return new WaitForSeconds(_PowerUps.ghostTime);

        boxCollider2D.enabled = true;
        currentColour.a = 1f;
        spriteRenderer.color = currentColour;
        rb.mass = 1.0f;

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
