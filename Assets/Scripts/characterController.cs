using Unity.VisualScripting;
using UnityEngine;

public class characterController : MonoBehaviour
{
    private float jumpPower = 6f;
    private float horizontal;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask ground;
    [SerializeField] private float maxSwipeTime;
    [SerializeField] private float minSwipeDis;

    private float swipeStartTime;
    private float swipeEndTime;
    private float swipeTime;
    private float swipeLenght;
    private Vector2 startSwipePosition;
    private Vector2 endSwipePosition;
    private Animator anim;

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
        }
        if (Input.GetMouseButtonUp(1) && IsGrounded() || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) && IsGrounded() && rb.linearVelocity.y > 0.7f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.7f);
        }
        {

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
                if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Moved))

                {
                    anim.SetBool("isCrouching", true);
                }
                if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(3).phase == TouchPhase.Ended))
                {
                    anim.SetBool("isCrouching", false);
                }
            }

        }
     
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, 0.1f, ground);
    }
}
