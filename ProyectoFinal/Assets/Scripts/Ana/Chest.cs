using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] GameObject[] powerups;
    [SerializeField] float healthchest = 3;
    new AudioSource audio;
    new Renderer renderer;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            healthchest--;
            if (healthchest == 0)
            {
                int random = Random.Range(0, powerups.Length);
                Instantiate(powerups[random], transform.position, Quaternion.identity);
                renderer.enabled = !renderer.enabled;
                audio.Play();
                Destroy(gameObject, 0.8f);
            }
        }
    }
}
