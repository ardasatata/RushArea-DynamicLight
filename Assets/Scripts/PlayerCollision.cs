using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    Player player;

    Rigidbody2D rb;

    public bool hitGround;

    public FinishStage finishS;

    public UIFunction UIF;

    // Use this for initialization
    void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Start()
    {
        loading();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Spike")
        {
            if (!player.immune)
            {
                --player.PlayerHealth;
                GetComponent<GroundCheck>().enabled = false;
                GetComponent<PlayerCollision>().enabled = false;
                player.PState = PlayerState.KnockedBack;
                if (player.transform.position.x - other.transform.position.x <= 0)
                {
                    GetComponent<PlayerControl>().knockToLeft = true;
                }
                else
                {
                    GetComponent<PlayerControl>().knockToLeft = false;
                }
            }
        }

        if (other.transform.tag == "death box")
        {
            player.PState = PlayerState.Dead;
            GetComponent<PlayerCollision>().enabled = false;
        }

        

        if (other.transform.tag == "ground")
        {
            hitGround = true;
        }
        else
        {
            hitGround = false;
        }

        if (other.gameObject.tag == "finishbox")
        {
            StartCoroutine("Finish");
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {

        if (other.transform.tag == "ground")
        {
            hitGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "ground")
        {
            hitGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "CheckPoin")
        {
            print("in checkpoin");
            other.gameObject.SetActive(false);
            player.StartingPosition = other.transform;
            StaticStatesAndVariables.CoinData += 5;
        }

        if (other.transform.tag == "canon ball")
        {
            other.gameObject.SetActive(false);
            --player.PlayerHealth;
            
        }
    }

    public void loading() { StartCoroutine("Finish"); }

    IEnumerator Finish()
    {
        bgmHandler.playBGM = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        int lvIndex = StaticStatesAndVariables.CurrentLevel;
        StaticStatesAndVariables.CurrentLevel += 1;

        if (StaticStatesAndVariables.CurrentLevel == finishS.transform.childCount)
        {
            nextLevelDisplay.lastStages = true;
            yield return new WaitForSeconds(3);
            StopAllCoroutines();
            UIF.BackToMainMenu();
        }

        finishS.nextLevelScreen.SetActive(true);
        finishS.nextLevelScreen.GetComponent<nextLevelDisplay>().Show();

        foreach (var s in finishS.Stages)
        {
            s.SetActive(false);
        }
        
        finishS.Stages[lvIndex].SetActive(true);

        player.StartingPosition = finishS.Stages[lvIndex].transform.Find("StartPos").transform;
        player.RePos();

        yield return new WaitForSeconds(3);

        finishS.nextLevelScreen.SetActive(false);
        bgmHandler.playBGM = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}