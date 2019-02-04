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
    float speed, jumpHeight, jumpCooldown, wallJumpBoost;

    bool hasWallJumped = false;
    bool canJump = true;
    bool isFacingRight = true;
    bool isWallSliding = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        wallSlide = GetComponent<PlayerWallSlide>();
        anim = GetComponentInChildren<Animator>();

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

        if(xMov.x != 0 && !IsOnWall())
        {
            anim.SetBool("isRunning", true);
        } else
        {
            anim.SetBool("isRunning", false);
        }

        // stop player sliding so much when stopping
        if (IsGrounded() && !IsOnWall() && (Input.GetAxisRaw("Horizontal") == 0) && !canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x /2, rb.velocity.y);
        }

        if (xMov.x < 0 && isFacingRight){ FlipPlayer(-0.2f);}
        else if(xMov.x > 0 && !isFacingRight) { FlipPlayer(0.2f);}

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
        anim.SetTrigger("doJump");
    }

    void WallJump()
    {
        Vector2 jumpForce = new Vector2(jumpHeight - wallJumpBoost, jumpHeight + wallJumpBoost);
        rb.AddForce(jumpForce, ForceMode2D.Impulse);
        anim.SetTrigger("doWallJump");
    }

    void FlipPlayer(float xRot)
    {
        Vector3 theScale = transform.localScale;
        theScale.x = xRot;
        transform.localScale = theScale;
        if(xRot > 0)
        {
            isFacingRight = true;
        } else if(xRot < 0)
        {
            isFacingRight = false;
        }
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
            anim.SetBool("isWallSliding", isWallSliding);
            FlipPlayer(0.2f);
        } else
        {
            anim.SetBool("isWallSliding", isWallSliding);
            wallSlide.WallSlide(false);
        }
    }

    private bool IsOnWall()
    {
        if (!playerCollider.IsTouching(ground) && playerCollider.IsTouching(wall))
        {
            isWallSliding = true;
            return true;
        }
        isWallSliding = false;
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
