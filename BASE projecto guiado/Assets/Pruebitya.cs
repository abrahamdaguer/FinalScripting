using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebitya : MonoBehaviour
{
    int speed = 10;
    Rigidbody rb;
    Vector3 inputVector;
    
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      inputVector = new Vector3();
    }

   
    void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
        rb.velocity = inputVector * speed;
        
    }
}
