using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
	public float maxSpeed = 8f;
	public float jumpForce = 7f;
	public float fallMultiplier = 2f;
	public float lowJumpMultipler = 1.5f;
	public Transform groundCheack;
	public LayerMask whatIsGround;

	private bool jump = false;
	private float groundRadius = 0.3f;
	private bool facingRight = true;
	private bool grounded = false;
	private Rigidbody2D myRigidbody2D;
	private Animator myAnimator;
	private Transform myTransform;




	// Use this for initialization
	void Start() {
		myRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		myAnimator = gameObject.GetComponent<Animator>();
		myTransform = gameObject.GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update() {
		if(grounded && Input.GetAxis("Vertical") > 0) {
			jump = true;
		}

		if(myTransform.position.y < -4) {
			GameControler.EndGame();
		}

		if(!grounded) {
			jump = false;
		}

		myAnimator.SetBool("Ground", grounded);
		myAnimator.SetBool("Jump", jump);
	}

	//Update when physics calculates (50 times a min)
	void FixedUpdate() {
		// Cheack ground
		grounded = Physics2D.OverlapCircle(groundCheack.position, groundRadius, whatIsGround);

		//Jumping
		if(jump) {
			myRigidbody2D.velocity = Vector2.up * jumpForce;
		}

		if(!grounded) {
			if(myRigidbody2D.velocity.y < 0) {
				myRigidbody2D.velocity = Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1);
			} else if(Input.GetAxis("Vertical") <= 0) {
				myRigidbody2D.velocity = Vector2.up * Physics2D.gravity.y * (lowJumpMultipler - 1);
			}
		}

		//Movement left/right
		float move = Input.GetAxis("Horizontal");
		myAnimator.SetFloat("Speed", Mathf.Abs(move));
		myRigidbody2D.velocity = new Vector2(move * maxSpeed, myRigidbody2D.velocity.y);

		//Cheack orantiation and flip if needed
		if(move > 0 && !facingRight) {
			Flip();
		} else if(move < 0 && facingRight) {
			Flip();
		}
	}


	/// <summary>
	/// c>Flip</c> translate character the opposit direction it's faceing.
	/// </summary>
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
