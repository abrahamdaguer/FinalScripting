using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winnertext : MonoBehaviour
{
    /*
    GameObject player1, player2;
    PlayerController win1, win2;
    */
    void Start()
    {
        /*
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");

        win1 = player1.GetComponent<PlayerController>();
        win2 = player2.GetComponent<PlayerController>();

        win2.winner.enabled = false;
        win1.winner.enabled = false;
        */
        GameMaster.Instance.p1.winner.enabled = false;
        GameMaster.Instance.p2.winner.enabled = false;
    }
    void Update()
    {
        if (GameMaster.Instance.p1.health == 0)
        {
            GameMaster.Instance.p2.winner.enabled = true;
            //win2.winner.enabled = true;
        }
        else if (GameMaster.Instance.p2.health == 0)
        {
            GameMaster.Instance.p1.winner.enabled = true;
            //win1.winner.enabled = true;
        }
    }
}
