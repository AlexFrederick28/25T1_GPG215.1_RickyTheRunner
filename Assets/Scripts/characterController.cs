using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] private float jumpPower = 6f;
    private float horizontal;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask ground;
    private Animator anim;

    [SerializeField] private Collider2D circleCollider;
    [SerializeField] private Collider2D capsuleCollider;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
     anim = GetComponent<Animator>();
    }


    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && IsGrounded() || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) && IsGrounded())

        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            anim.SetBool("isJumping", true);

            capsuleCollider.enabled = true;
            circleCollider.enabled = false;
        }
        if (IsGrounded() && Mathf.Abs(horizontal) > 0f)
        {
            anim.SetBool("isRunning", true);

        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        {
           if (anim.GetBool("isJumping") && rb.linearVelocity.y < 0.1f && IsGrounded())
            {
                anim.SetBool("isJumping", false);
            }
         }
        {
            if (Input.GetMouseButton(1) || (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Moved))
            {
                anim.SetBool("isCrouching", true);
                capsuleCollider.enabled = false;
                circleCollider.enabled = true;
            }
            else
                  if (Input.GetMouseButtonUp(1) || (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Moved))
            {
            anim.SetBool("isCrouching", false);

                circleCollider.enabled = false;
                capsuleCollider.enabled = true;

            }
        }

    }
    private void FixedUpdate()
    {
     
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, 0.1f, ground);
    }
}
