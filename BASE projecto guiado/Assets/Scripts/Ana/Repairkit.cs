using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repairkit : MonoBehaviour
{
    /*
    GameObject player1, player2;
    PlayerController healthp1, healthp2;
    */
    new AudioSource audio;
    new Renderer renderer;

    [SerializeField] float recover = 25;
    void Start()
    {
        /*
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");

        healthp1 = player1.GetComponent<PlayerController>();
        healthp2 = player2.GetComponent<PlayerController>();
        */

        audio = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player1" && GameMaster.Instance.p1.health < 100)
        {
            GameMaster.Instance.p1.Heal(recover);
            //healthp1.Heal(recover);
            renderer.enabled = !renderer.enabled;
            audio.Play();
            Destroy(gameObject, 2f);
        }
        if (other.gameObject.name == "player2" && GameMaster.Instance.p2.health < 100)
        {
            GameMaster.Instance.p2.Heal(recover);
            //healthp2.Heal(recover);
            renderer.enabled = !renderer.enabled;
            audio.Play();
            Destroy(gameObject, 2f);
        }
    }
}
