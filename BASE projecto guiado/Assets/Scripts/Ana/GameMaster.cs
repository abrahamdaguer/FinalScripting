using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Singleton<GameMaster>
{

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    public PlayerController p1;
    public PlayerController p2;

    private void Start()
    {
        p1 = player1.GetComponent<PlayerController>();
        p2 = player2.GetComponent<PlayerController>();
    }
}
