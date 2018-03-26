using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float maxSpeed = 10f;
	public float jumpForce = 100f;
	public float airSpeed = 5f;
	public Transform groundCheack;
	public LayerMask whatIsGround;
	public bool lift = false;

	private bool jump = false;
	private float groundRadius = 0.2f;
	private bool facingRight = true;
	private bool grounded = false;
	private Rigidbody2D myRigidbody2D;
	private Animator myAnimator;




	// Use this for initialization
	void Start() {
		myRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		myAnimator = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		if (grounded && Input.GetAxis("Vertical") > 0 && !lift) {
			jump = true;
		}

	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheack.position, groundRadius, whatIsGround);
		myAnimator.SetBool("Ground", grounded);
		myAnimator.SetBool("Jump", jump);

		if(jump) {
			if(lift) {
				myRigidbody2D.AddForce(new Vector2(0,jumpForce));
			}
		}
		if (lift && !grounded) {
			lift = false;
			jump = false;
		}

		float move = Input.GetAxis("Horizontal");

		myAnimator.SetFloat("Speed", Mathf.Abs(move));

		if (grounded && !jump)
			myRigidbody2D.velocity = new Vector2(move * maxSpeed, myRigidbody2D.velocity.y);
		else {
			if(myRigidbody2D.velocity.x + (move * airSpeed) <= maxSpeed)
				myRigidbody2D.AddForce(new Vector2(move * airSpeed, 0));
		}

		if (move > 0 && !facingRight)
			Flip();

		else if (move < 0 && facingRight)
			Flip();
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
