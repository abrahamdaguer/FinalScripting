using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChanger : MonoBehaviour
{
    public HealthSO mchannel;
    void Start()
    {
    }
    private void OnEnable()
    {
        mchannel.healthChange += ChangeHealth;
    }

    private void OnDisable()
    {
        mchannel.healthChange -= ChangeHealth;
    }

    void ChangeHealth(float force, PlayerController player)
    {

        Debug.Log("Observer: Changes Health");

        player.health -= force;
        player.healthbar.value = player.health;

        if (player.health <= 0)
        {
            Destroy(player.gameObject);
        }

    }
}
