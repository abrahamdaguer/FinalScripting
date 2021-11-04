using Ana;
using Maria;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float health = 100;
    public Text winner;
    Movement movement;
    //public Irotation irotation;
    //Gun[] guns;
    Gun gun;
    [SerializeField] Slider healthbar;
    
    public void Hit(float force)
    {
        health -= force;
        healthbar.value = health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }  
    void Start()
    {
        movement = GetComponent<Movement>();
        //irotation = GetComponent<Irotation>();
        //guns = GetComponentsInChildren<Gun>();
        gun = GetComponentInChildren<Gun>();
    }
    void Update()
    {
        movement.movement();
        movement.Sound();
        movement.SetLights();
        //irotation.rotate();
        movement.rotate();
        gun.rotate();
        gun.Shoot();
        /*for (int i = 0; i < guns.Length; i++)
        {
            guns[i].Rotate();
            guns[i].Shoot();
        }  */    
    }
    public void Heal(float recover)
    {
        health += recover;
        if (health > 100)
        {
            health = 100;
        }
        healthbar.value = health;
    }
}
