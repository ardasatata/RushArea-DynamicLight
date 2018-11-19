using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour{

	public void Walk (Rigidbody2D rigidBody, float Speed)
	{
		rigidBody.velocity = new Vector2(Speed, rigidBody.velocity.y);
	}


}
