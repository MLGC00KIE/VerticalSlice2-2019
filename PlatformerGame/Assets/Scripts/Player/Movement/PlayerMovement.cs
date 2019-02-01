using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerWallSlide))]
public class PlayerMovement : MonoBehaviour {

    Collider2D wall;
    Collider2D ground;

    PlayerWallSlide wallSlide;

    Animator anim;

    Rigidbody2D rb;
    Collider2D playerCollider;

    [SerializeField]
    float speed, jumpHeight, jumpCooldown;

    bool hasWallJumped = false;
    bool canJump = true;
    bool isFacingRight = true;
    bool isWallSliding = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        wallSlide = GetComponent<PlayerWallSlide>();
        anim = GetComponent<Animator>();

        ground = GameObject.FindGameObjectWithTag("ground").GetComponent<Collider2D>();
        wall = GameObject.FindGameObjectWithTag("jumpWall").GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }
        CheckForWallSlide();
	}

    void Move()
    {
        Vector2 xMov = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0);
        rb.AddForce(xMov);
        // stop player sliding so much when stopping
        if (IsGrounded() && !IsOnWall() && (Input.GetAxisRaw("Horizontal") == 0) && !canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x /2, rb.velocity.y);
        }

        if (xMov.x < 0 && isFacingRight){ FlipPlayer(); isFacingRight = false; }
        else if(xMov.x > 0 && !isFacingRight) { FlipPlayer(); isFacingRight = true; }

    }

    void TryJump()
    {
        if (IsGrounded() && !IsOnWall() && canJump)
        {
            Jump();
            StartCoroutine(startJumpCooldown());
            return;
        }
        if (!IsGrounded() && IsOnWall() && CanWallJump() && isWallSliding)
        {
            WallJump();
            return;
        }

    }

    void Jump()
    {
        Vector2 jumpForce = new Vector2(0, jumpHeight);
        rb.AddForce(jumpForce, ForceMode2D.Impulse);
    }

    void WallJump()
    {
        Vector2 jumpForce = new Vector2(jumpHeight * 0.75f, jumpHeight * 0.75f);
        rb.AddForce(jumpForce, ForceMode2D.Impulse);
    }

    void FlipPlayer()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private bool IsGrounded()
    {
        if (playerCollider.IsTouching(ground) && !playerCollider.IsTouching(wall))
        {
            hasWallJumped = false;
            return true;
        }
        return false;
    }

    private void CheckForWallSlide()
    {
        if(IsOnWall())
        {
            wallSlide.WallSlide(true);
        } else
        {
            wallSlide.WallSlide(false);
        }
    }

    private bool IsOnWall()
    {
        if (!playerCollider.IsTouching(ground) && playerCollider.IsTouching(wall))
        {
            return true;
        }
        return false;
    }

    private bool CanWallJump()
    {
        if (!playerCollider.IsTouching(ground) && playerCollider.IsTouching(wall) && !hasWallJumped)
        {
            hasWallJumped = true;
            return true;
        }
        return false;
    }

    IEnumerator startJumpCooldown()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.ToString() == "jumpWall")
        {
            isWallSliding = true;
        }
    }
}
