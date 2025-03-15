using System;
using Unity.VisualScripting;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float jumpPower = 6f;
    private float horizontal;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask ground;
    private Animator anim;
    private bool isJumping;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded() || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            anim.SetBool("isJumping", true);
            isJumping = true;
        }
        else if (Input.GetMouseButtonDown(0) && isJumping == true || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isJumping == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            anim.SetBool("isDoubleJumping", true);
            isJumping = false;
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
        {
            if (Input.GetMouseButtonDown(1) || (Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Moved))
            {
                anim.SetBool("isCrouching", true);
                Debug.Log("Ya Crouch");
            }
            if (Input.GetMouseButtonUp(1) || (Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Ended))
            {
                anim.SetBool("isCrouching", false);
            }
        }
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, 0.1f, ground);
    }
}
    