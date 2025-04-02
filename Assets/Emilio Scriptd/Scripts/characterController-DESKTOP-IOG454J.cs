using Unity.VisualScripting;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float jumpPower = 6f;
    private float horizontal;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask ground;
    [SerializeField] Collider2D boxCollider;
    
    private Animator anim;
    public bool isJumping;

    [SerializeField] private AudioClip firstJump;
    [SerializeField] private AudioClip secondJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded() || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && IsGrounded())
        {
            isJumping = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            anim.SetBool("isJumping", true);
            boxCollider.enabled = true;

            SoundManager.instance.sfxSource.PlayOneShot(firstJump);


        }

        else if (Input.GetMouseButtonDown(0) && isJumping == true || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isJumping == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            anim.SetBool("isDoubleJumping", true);
            isJumping = false;
            boxCollider.enabled = true;

            SoundManager.instance.sfxSource.PlayOneShot(secondJump);

        }
        else
        {
            anim.SetBool("isDoubleJumping", false);
        }
        if (IsGrounded() && Mathf.Abs(horizontal) > 0f)
        {
            anim.SetBool("isRunning", true);

        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (anim.GetBool("isJumping") && rb.linearVelocity.y < 0.1f && IsGrounded())
        {
            anim.SetBool("isJumping", false);
        }
        if (anim.GetBool("isDoubleJumping") && rb.linearVelocity.y < 0.1f && IsGrounded())
        {
            anim.SetBool("isDoubleJumping", false);
        }
      
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, 0.1f, ground);
    }

}