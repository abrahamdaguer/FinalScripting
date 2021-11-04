using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    [SerializeField] float force = 10, lifetime = 0;
    public HealthSO healthso;
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
            healthso.OnHealthChanges(force, player);
            //player.Hit(force);
            Destroy(gameObject); //Destruir el proyector para que no haga daño 2 veces

        }
    }
}
