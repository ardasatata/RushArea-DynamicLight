using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

	private float fallMultiplier = 2.5f;
	private float lowJumpMultiplier = 2f;

	Rigidbody2D rb;

	bool stillJumping;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (rb.velocity.y > 0 && !stillJumping) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

	}

	public void gettingJumpInput (bool getInput){
		stillJumping = getInput;
	}

}
