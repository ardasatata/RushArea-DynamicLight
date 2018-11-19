using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopOutObstacleReaction : MonoBehaviour {

	Player objName;

	void Start(){
		if (GetComponent<ObstacleReaction>().reactionType == ObstacleReactionType.ByHidenCollision)
			this.GetComponent<SpriteRenderer>().enabled = false;

        this.objName = GameObject.Find("Player").GetComponent<Player>();
	}

	public void ReactTo(Player obj){
        if(obj!=null)
            this.objName = obj;
       // Debug.Log(objName.name);
	}

	void OnCollisionEnter2D(Collision2D col){
        if (objName != null)
        {
            if (col.gameObject.tag == objName.tag)
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<ObstacleReaction>().reactionType = ObstacleReactionType.None;
                this.GetComponent<PopOutObstacleReaction>().enabled = false;
            }
        }
		
	}

}
