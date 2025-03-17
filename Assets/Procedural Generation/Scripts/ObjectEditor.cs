using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEditor : MonoBehaviour
{
    #region variables

    [Header("Object Travel")]
    [Tooltip("Set the direction of travel")]
    [SerializeField] private Vector3 move;
    [Tooltip("Set the move speed for travel")]
    [SerializeField] private float speed;

    [Space]
    [Header("Sin Movement")]
    [Tooltip("How quick the object moves along sin")]
    [SerializeField] private float frequency;
    [Tooltip("sin curve size")]
    [SerializeField] private float amplitude;

    
    private characterController _CharacterController;

    [Space]
    [Header("Player Interaction")]
    [Tooltip("Activates push function for this object")]
    [SerializeField] private bool pushPlayer;
    [Tooltip("Destroy the object after interaction?")]
    [SerializeField] private bool destroyOnInteraction;
    [Tooltip("Drop the destroy sound here")]
    [SerializeField] private AudioClip destroySound;
    [Tooltip("Set to a negative number to go back (Eg. -50)")]
    [SerializeField] private float pushDirectionX;
    [Tooltip("Set as a positive number to go up (Eg. 10)")]
    [SerializeField] private float pushDirectionY;
    [Tooltip("How effective is the push? (Eg. 100%)")]
    [SerializeField] private float pushMultiplier;
    private bool playerCollided; // if the player touches collider then set true
    

    #endregion

    private void Start()
    {
        GetReferences(); // find references automatically
    }

    private void Update()
    {
        AddSpeedToObject(); // adds direction and speed to objects

        PushPlayerBack(); // if allowed, will push player back and then despawn
    }

    void AddSpeedToObject()
    {

        transform.position += new Vector3(move.x, Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude + move.z) * speed * Time.deltaTime;
        
    }

    void PushPlayerBack()
    {
        if (playerCollided == true)
        {

            Debug.Log("Player hit!");

            _CharacterController.transform.position += new Vector3(pushDirectionX, pushDirectionY, 0) * pushMultiplier * Time.deltaTime;

            if (destroyOnInteraction == true)
            {
                Debug.Log("Explosion");
                StartCoroutine(ExplosionAnimation());
            }

            playerCollided = false;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pushPlayer == true && collision.transform.GetComponent<characterController>())
        {
            playerCollided = true;
        }
        
    }

    private IEnumerator ExplosionAnimation()
    {
        Animator explosion = GetComponent<Animator>();

        explosion.Play("Explosion");
        SoundManager.instance.sfxSource.PlayOneShot(destroySound);

        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();

        circleCollider.enabled = false;

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }

    private void GetReferences()
    {
        if (_CharacterController == null)
        {
            _CharacterController = FindFirstObjectByType<characterController>();
        }
    }

}
