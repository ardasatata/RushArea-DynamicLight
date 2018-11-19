using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : MonoBehaviour {


	public void Run (Rigidbody2D rigidBody, float Speed)
	{
		print("Run!!!");
		rigidBody.velocity = new Vector2(Speed, rigidBody.velocity.y);
	}

}
