using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float minX, maxX;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    public Transform minWalk, maxWalk;

    private Animator animator;
    private SpriteRenderer sRend;
    private bool isGrounded = false;
    private Rigidbody2D rBody;
    private bool isRight = true;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        sRend = GetComponent<SpriteRenderer>();

        rBody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(minWalk.position.x, this.transform.position.y, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        animator.SetBool("Grounded", isGrounded);

        if (isGrounded)
        {
            if (isRight)
            {
                sRend.flipX = false;
                rBody.velocity = new Vector2(5, 0);

                if (this.transform.position.x >= maxWalk.position.x)
                {
                    isRight = false;
                }
            }
            if (!isRight)
            {
                sRend.flipX = true;
                rBody.velocity = new Vector2(-5, 0);

                if (this.transform.position.x <= minWalk.position.x)
                    isRight = true;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector3(minX, -3.0f, 0), new Vector3(maxX, -3.0f, 0));
    }
}
