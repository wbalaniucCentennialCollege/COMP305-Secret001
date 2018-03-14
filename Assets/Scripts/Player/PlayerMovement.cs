using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float runSpeed = 5.0f;
    public float jumpSpeed = 400.0f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator anim;
    private bool isGrounded;
    private float moveHorizontal;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        if (isGrounded && Input.GetAxis("Jump") > 0 && rBody.velocity.y == 0.0f)
        {
            rBody.AddForce(new Vector2(0.0f, jumpSpeed), ForceMode2D.Impulse);
        }
	}

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        anim.SetBool("Grounded", isGrounded);

        // Debug.Log("Grounded: " + isGrounded);

        anim.SetFloat("vSpeed", rBody.velocity.y);

        if (isGrounded)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));

            rBody.velocity = new Vector2(moveHorizontal * runSpeed, rBody.velocity.y);

            if (rBody.velocity.x > 0.0f)
                sRend.flipX = false;
            else if (rBody.velocity.x < 0.0f)
                sRend.flipX = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
