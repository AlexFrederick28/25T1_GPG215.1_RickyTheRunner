
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 0f;
    public float jumpPower = 6f;
    private bool shouldJump = false;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask ground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded() || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
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