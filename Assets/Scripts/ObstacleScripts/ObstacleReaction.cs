using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleReaction : MonoBehaviour {

	Player player;

	public ObstacleReactionType reactionType;

	PopOutObstacleReaction popOut;
    MovingObstacleReaction movingObs;
    DelayedCollision delay;
    FakeWallReaction fakeObs;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        popOut = this.GetComponent<PopOutObstacleReaction>();
        movingObs = this.GetComponent<MovingObstacleReaction>();
        delay = this.GetComponent<DelayedCollision>();
        fakeObs = this.GetComponent<FakeWallReaction>();
    }

    void Update(){
		switch (reactionType) {
		case ObstacleReactionType.ByHidenCollision:
				popOut.ReactTo (player);
			break;
        case ObstacleReactionType.ByDistance:
                switch (gameObject.tag) {
                    case "ball":
                        movingObs.ReactTo(player);
                        break;
                    case "fakeWall":
                        fakeObs.ReactTo(player);
                        break;

                }
            break;
        case ObstacleReactionType.ByDelayedCollision:
                delay.ReactTo(player);
            break;
        }
	}

}
