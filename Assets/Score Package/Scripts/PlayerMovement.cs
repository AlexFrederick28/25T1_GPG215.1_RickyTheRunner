using UnityEngine;

// Nick - simple movement for testing (not the actual movement script for the player)

public class PlayerMovement : MonoBehaviour
{
    // NOTE (if you want Spacebar for jump - in Project Settings -> Input Manager -> Axes -> Vertical, change alt postive button to "space"

    #region Variables

    private Rigidbody2D playerRigidBody2D;

    public float moveSpeed;
    public float jumpPower;

    private float moveHorizontal;
    private float moveVertical;

    public bool canMove; // allows player movement if true

    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask ground;

    public AudioClip jumpSound; // sound for jump

    #endregion

    void Start()
    {
        playerRigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 1.1f;
        jumpPower = 20f;
        canMove = true;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) // Movemenet - A and D 
            {
                playerRigidBody2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);

            }

            if (IsGrounded() && moveVertical > 0.1f) // Movement - Spacebar
            {
                Vector2 currentVelocity = playerRigidBody2D.linearVelocity;
                playerRigidBody2D.linearVelocity = new Vector2(currentVelocity.x, 0f);

                playerRigidBody2D.AddForce(new Vector2(0f, moveVertical * jumpPower), ForceMode2D.Impulse);

                if (jumpSound != null)
                {
                    SoundManager.instance.sfxSource.PlayOneShot(jumpSound);
                    Debug.Log("Sound Played.");
                }

                else
                {
                    Debug.Log("Sound Missing.");
                }
            }
        }


    }

    public bool IsGrounded() // check for grounded
    {
        return Physics2D.OverlapCircle(groundChecker.position, 0.1f, ground);
    }

    public void EnableAndDisableMovement() // Swap between allowing movement
    {
        if (canMove == true)
        {
            canMove = false;
        }

        else if (canMove == false)
        {
            canMove = true;
        }
    }
}
