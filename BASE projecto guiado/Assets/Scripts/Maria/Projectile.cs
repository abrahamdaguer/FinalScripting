using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] HealthSO healthSO;
    [SerializeField] float force = 10, lifetime = 0;
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= 5) Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        if(target.CompareTag("Player"))
        {
            PlayerController player = target.GetComponent<PlayerController>();
            healthSO.OnHealthChanges(force, player);
            //player.Hit(force);
            Destroy(gameObject); //Destruir el proyector para que no haga daño 2 veces

        }
    }
}
