using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacleReaction : MonoBehaviour {
    
    public float Speed;

    public Transform distanceToPlayer;

    Player player;

    public bool b=false;

    void Start()
    {
        this.player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update () {
        if (CheckDistance()) {
            React();
        }
        if (b)
        {
            print("obstacle : " + distanceToPlayer.position.x);
            print("player : " + player.transform.position.x);
        }
        
	}

    public void ReactTo(Player obj)
    {
        if (obj != null)
            this.player = obj;
    }

    bool CheckDistance() {
        bool d=false;
        if (player != null && distanceToPlayer!=null)
        {
           d = (distanceToPlayer.position.x - player.transform.position.x) <= 0;
        }
        return d;
    }

    void React() {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
    }
    
}
