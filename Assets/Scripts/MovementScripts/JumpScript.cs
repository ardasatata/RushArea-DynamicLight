using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {


	public void Jump (Rigidbody2D rigidBody, float force, bool stillJumping)
	{
		rigidBody.velocity = Vector2.up * force;

	}

}
