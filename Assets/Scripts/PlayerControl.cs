using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	Player player;

	public Vector2 knockBackVelocity, vel;

	public Vector2 currentVel;

	public float MoveSpeed;
	protected float CurrentSpeed;
	public float JumpForce;
	private Rigidbody2D playerRigidBody;
	private Vector3 position;

	public float ControlDisableTime;

    public bool knockToLeft;

	AMovement action;
	InputMapper imap = InputMapper.Instance;
	BetterJump bj;

    public JumpButton jumpBtn;
    public VirtualJoystick vJoystick;


	// Use this for initialization
	void Awake () {
		playerRigidBody = GetComponent<Rigidbody2D> ();
		action = new AMovement ();
		bj = GetComponent<BetterJump> ();
		player = GetComponent<Player> ();
		CurrentSpeed = MoveSpeed;
		vel = knockBackVelocity;
	}

    bool brake = false; // set it to true to kill the momentum
    float friction = 0.9f; // 1 means no friction, 0 stops instantly


    void Update(){
		
	}


	// Update is called once per frame
	void FixedUpdate () {
		
		currentVel = playerRigidBody.velocity;

		if (player.PState == PlayerState.KnockedBack) {
			CurrentSpeed = 0;
			StartCoroutine ("KnockBack",vel);
            if (knockToLeft)
            {
                vel = new Vector2(Mathf.Abs(vel.x) * -1, vel.y);
                if (vel.x <= 0)
                {
                    vel = new Vector2(vel.x + (knockBackVelocity.x / 15), vel.y);
                }
                
            }
            else {
                if (vel.x >= 0)
                {
                    vel = new Vector2(vel.x - (knockBackVelocity.x / 15), vel.y);
                }
                
            }
            if (vel.y >= -8) {
                vel = new Vector2(vel.x, vel.y - (knockBackVelocity.y / 5));
            }
            
        } else {
            
			if(jumpBtn.buttonDown){
                brake = false;
                
                if (player.PState == PlayerState.OnGround) {
                    Act(InputCode.Jump);
                    sfxHandler.playSFX = 1;
                }
				
            }

            if (!jumpBtn.buttonDown) {
                sfxHandler.playSFX = 0;
            }

			bj.gettingJumpInput (jumpBtn.buttonDown);

			if (/*imap.getKey (InputCode.MoveRight) */vJoystick.MovetoRight() && vJoystick.Moving()) {
				Act(InputCode.MoveRight);
				player.flip = false;
                if (player.PState == PlayerState.OnGround)
                    sfxHandler.playSFX = 2;
                brake = false;
            }
            if (/*imap.getKeyUp(InputCode.MoveRight)*/!vJoystick.Moving()) {
                sfxHandler.playSFX = 0;
            }
            if (/*imap.getKeyUp(InputCode.MoveLeft)*/!vJoystick.Moving())
            {
                sfxHandler.playSFX = 0;
            }
            if (/*imap.getKey (InputCode.MoveLeft) */ !vJoystick.MovetoRight() && vJoystick.Moving()) {
				Act(InputCode.MoveLeft);
				player.flip = true;
                if (player.PState == PlayerState.OnGround)
                    sfxHandler.playSFX = 2;
                brake = false;
            }
            
            brake = true;
        }
        

		if (brake){
			playerRigidBody.velocity = new Vector2( friction*playerRigidBody.velocity.x,playerRigidBody.velocity.y);
			//playerRigidBody.velocity *= friction;
			playerRigidBody.angularVelocity *= friction;
        }

        
	}


	public void Act(InputCode codes)
	{
		switch (codes) {
		case InputCode.Jump:
			    action.Jump (playerRigidBody, JumpForce, jumpBtn.buttonDown);
			break;
		case InputCode.MoveRight:
                //action.Walk (playerRigidBody, CurrentSpeed);
                action.Walk (playerRigidBody, CurrentSpeed * vJoystick.inputVector.x);
                break;
		case InputCode.MoveLeft:
                //action.Walk(playerRigidBody, CurrentSpeed * (-1.0f));
                action.Walk(playerRigidBody, CurrentSpeed * vJoystick.inputVector.x);
                break;
            default:
                sfxHandler.playSFX = 0;
                break;
        }

	}

	IEnumerator KnockBack(Vector2 Velocity) {
		player.PState = PlayerState.KnockedBack;
        
		playerRigidBody.velocity = Velocity;

		yield return new WaitForSeconds(ControlDisableTime);

		GetComponent<GroundCheck> ().enabled = true;
		player.PState = PlayerState.OnAir;
		CurrentSpeed = MoveSpeed;
		vel = knockBackVelocity;
	}


}
