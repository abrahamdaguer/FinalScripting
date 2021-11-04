using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ana
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] float rotSpeed = 90;
        public float ammo = 0;
        public float bullets = 0;
        [SerializeField] string horizontal = "Horizontal", shoot = "Fire1";
        [SerializeField] float attackSpeed = 2f;//cooldown = T= 1/fr
        [SerializeField] GameObject originalProjectile;
        [SerializeField] GameObject fireSpot;
        
        AudioSource gun;
        ParticleSystem ps;
        
        float t = 0;
        void Start() 
        {
            ammo = bullets;
            gun = GetComponent<AudioSource>();
            gun.volume = 1f;
            ps = GetComponentInChildren<ParticleSystem>();
            t = 1 / attackSpeed; //para que el primer ataque este disponible
        }
        public void Rotate()
        {
            Vector3 dirRot = new Vector3(0, 1, 0);
            Vector3 velocityRot = rotSpeed * dirRot * Input.GetAxis(horizontal);
            transform.eulerAngles += velocityRot * Time.deltaTime;
        }
        public void Shoot()
        {
            if (Input.GetButtonDown(shoot) && t >= 1/attackSpeed && ammo !=0) {
                ammo--;
                t = 0;
                gun.Play();
                ps.Play();

                Vector3 position = fireSpot.transform.position;
                Quaternion rotation = fireSpot.transform.rotation;

                GameObject clon=Instantiate(originalProjectile,position,rotation);
                clon.GetComponent<Rigidbody>().AddForce(transform.forward * 800 * 1);
            }
            t += Time.deltaTime;
        }
        
        public void Amount(float value)
        {
            if (ammo < bullets) 
            {
                ammo += value;
                if (ammo > bullets)
                {
                  ammo = bullets;
                }
            }
        }
        
    }
}