using UnityEngine;
using System.Collections;

public class FakeWallReaction : MonoBehaviour
{
    public float Speed;

    public Transform distanceToPlayer;

    Player player;

    public bool b = false;

    void Start()
    {
        this.player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckDistance())
        {
            React();
        }

    }

    public void ReactTo(Player obj)
    {
        if (obj != null)
            this.player = obj;
    }

    bool CheckDistance()
    {
        bool d = false;
        if (player != null && distanceToPlayer != null)
        {
            d = (Mathf.Abs(distanceToPlayer.position.x) - Mathf.Abs(player.transform.position.x)) <= 0;
        }
        return d;
    }

    void React()
    {
        this.gameObject.SetActive(false);
    }

}
