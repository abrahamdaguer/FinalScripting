using Ana;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Ammunition : MonoBehaviour
{
    GameObject player1, player2;
    Gun gunp1, gunp2;
    new AudioSource audio;
    new Renderer renderer;

    [SerializeField] float value = 3;
    void Start()
    {
        //gun = FindObjectOfType<Gun>();
        player1 = GameObject.Find("TankTurret1");
        player2 = GameObject.Find("TankTurret2");

        gunp1 = player1.GetComponent<Gun>();
        gunp2 = player2.GetComponent<Gun>();

        audio = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
    }
    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.name == "player1" && gunp1.ammo < gunp1.bullets)
       { 
           gunp1.Amount(value);
           renderer.enabled = !renderer.enabled;
           audio.Play();
           Destroy(gameObject, 2f);
       }

       if (other.gameObject.name == "player2" && gunp2.ammo < gunp2.bullets)
       {
           gunp2.Amount(value);
           renderer.enabled = !renderer.enabled;
           audio.Play();
           Destroy(gameObject, 2f);
       }
    }
}
