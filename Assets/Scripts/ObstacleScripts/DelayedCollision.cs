using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedCollision : MonoBehaviour {
    Player objName;

    public float delay;

    void Start()
    {
        if (GetComponent<ObstacleReaction>().reactionType == ObstacleReactionType.ByDelayedCollision)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }

        }
        objName = GameObject.Find("Player").GetComponent<Player>();

    }

    public void ReactTo(Player obj)
    {
        if (obj!=null)
            objName = obj;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (objName != null)
        {
            if (col.gameObject.tag == objName.tag)
            {
                React();
            }
        }
        
    }

    void React() {
        StartCoroutine("waiting", delay);
    }

    IEnumerator waiting(float delay) {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
