using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int PlayerLife = StaticStatesAndVariables.LifeData;
	public int PlayerHealth;

    public Transform StartingPosition;

	public PlayerState PState;

	public GameState GState;
    
	public bool flip;

    public Collider2D colOther;

    public bool immune;

    float counter, immuneTime = 1.5f;

    Animator animator;

    void Start()
    {
        PlayerLife = StaticStatesAndVariables.LifeData;
        nextLevelDisplay.lastStages = false;
        PlayerHealth = StaticStatesAndVariables.HealthData;
        animator = GetComponent<Animator>();
        bgmHandler.playBGM = true;
    }

    // Update is called once per frame
    void Update () {

        animator.SetInteger("PlayerState", (int)PState);
        animator.SetFloat("PlayerSpeed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (immune) {
            counter += Time.deltaTime;
            if (counter >= immuneTime)
                immune = false;
        }
        if (PlayerHealth < 1)
        {
            PState = PlayerState.Dead;
        }

        if (PState == PlayerState.Dead) {
            PlayerLife-=1;
            if (PlayerLife > 0) {
                // temp -> ganti playerpref
                PlayerHealth = StaticStatesAndVariables.HealthData;
                // back to start pos or check point
                RePos();
                PState = PlayerState.OnAir;
                GetComponent<GroundCheck>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = true;
                GState.gameState = GameStates.Running;
            } else if (PlayerLife <= 0){
                // activate game over menu, deactivate player gameobject
                GState.gameState = GameStates.GameOver;
                this.gameObject.SetActive(false);
                Time.timeScale = 0;
            }
			
		} else {
			Time.timeScale = 1;
		}


		if (GState.gameState != GameStates.Running) {
			GetComponent<PlayerControl> ().enabled = false;
		} else {
			GetComponent<PlayerControl> ().enabled = true;
		}

		if (flip) {
			GetComponent<SpriteRenderer> ().flipX = true;
		} else {
			GetComponent<SpriteRenderer> ().flipX = false;
		}

	}

    public void RePos() {
        this.transform.position = StartingPosition.position;
    }


}
