using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maria
{
    public class Movement : MonoBehaviour, Idash, Ilights, ImotorSound, Irotation, Imove
    {
        [SerializeField] float dashForce = 1500, linearspeed = 8f, rotSpeed = 90;
        [SerializeField]
        string horizontal = "Horizontal", vertical = "Vertical", dash = "dash";


        Rigidbody rbody;
        AudioSource motor;
        Light lightL;
        Light lightR;
        void Start()
        {
            motor = GetComponent<AudioSource>();
            lightL = transform.Find("LeftLight").GetComponent<Light>();
            lightR = transform.Find("RightLight").GetComponent<Light>();
        }

        void Update()
        {
            Dash();
        }

        public void Dash()
        {
            if (Input.GetButtonDown(dash))
            {
                Vector3 dir = (transform.forward * 5 + transform.up * 1).normalized;
                Vector3 force = dashForce * dir * 1;
                rbody.AddForce(force);
            }
        }

        public void rotate()
        {
            Vector3 dirRot = new Vector3(0, 1, 0);
            Vector3 velocityRot = rotSpeed * dirRot * Input.GetAxis(horizontal);
            transform.eulerAngles += velocityRot * Time.deltaTime;
            rbody = GetComponent<Rigidbody>();
        }

        public void SetLights()
        {
            if (Input.GetAxis(vertical) < 0)
            {
                lightL.intensity = 2;
                lightR.intensity = 2;
            }
            else
            {
                if (Input.GetAxis(horizontal) < 0)
                {
                    lightL.intensity = 2;
                    lightR.intensity = 0;
                }
                else if (Input.GetAxis(horizontal) > 0)
                {
                    lightL.intensity = 0;
                    lightR.intensity = 2;
                }
                else if (Input.GetAxis(horizontal) == 0)
                {
                    lightL.intensity = 0;
                    lightR.intensity = 0;
                }
            }
        }


        public void Sound()
        {
            if (Input.GetAxis(horizontal) != 0 || Input.GetAxis(vertical) != 0)
            {
                motor.volume = 0.2f;
            }
            else
            {
                motor.volume = 0.03f;
            }
        }

        public void movement()
        {
            Vector3 dirZ = transform.forward;
            Vector3 velocityZ = linearspeed * dirZ * Input.GetAxis(vertical);
            transform.position += velocityZ * Time.deltaTime;
        }


    }
}
