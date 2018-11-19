using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMovement : MonoBehaviour {

	JumpScript jump = new JumpScript ();
	WalkScript walk = new WalkScript ();
	RunScript run = new RunScript ();

	public void Jump (Rigidbody2D rigidBody, float force, bool stillJumping)
	{
		jump.Jump (rigidBody, force, stillJumping);
	}

	public void Walk (Rigidbody2D rigidBody,float speed)
	{
		walk.Walk (rigidBody, speed);
	}

	public void Run (Rigidbody2D rigidBody,float speed)
	{
		run.Run (rigidBody, speed);
	}

}
