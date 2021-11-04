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
    Gun[] guns;
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
        guns = GetComponentsInChildren<Gun>();
    }
    void Update()
    {
        movement.Move();
        movement.Sound();
        movement.SetLights();
        movement.Rotate();
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].Rotate();
            guns[i].Shoot();
        }      
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
