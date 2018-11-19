using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	Player player;

	// Use this for initialization
	void Start () {
		player = GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		player.PState = GetComponent<PlayerCollision>().hitGround == true && Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround) ? PlayerState.OnGround : PlayerState.OnAir;

	}
}
