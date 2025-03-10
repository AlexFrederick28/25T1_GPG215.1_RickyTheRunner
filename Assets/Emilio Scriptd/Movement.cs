using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 0f;
    public float jumpPower = 6f;
    private Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask ground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        {
            if (IsGrounded() && Mathf.Abs(speed) < 0f)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, 0.1f, ground);
    }
    void TouchJump()
    {
    
    }
    private void Update()
    {
       
        
    }

}
