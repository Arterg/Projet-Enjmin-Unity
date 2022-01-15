using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouvement : MonoBehaviour
{
    [Tooltip("vitesse de déplacement")]
    public float linearspeed = 6;
    [Tooltip("vitesse de rotation")]
    public float angularspeed = 1;
    public Transform player;



    void Start()
    {


    }

    private void Update()
    {

    }
    private void FixedUpdate()
    {


        Rigidbody rb = GetComponent<Rigidbody>();
        //récup le component

        if (rb != null)
        {
            Vector3 dirPlayer = player.position - transform.position;
            dirPlayer = dirPlayer.normalized;

            float angle = Vector3.SignedAngle (dirPlayer,
                transform.forward,
                transform.up);

            if (angle > 2)
                rb.AddTorque(transform.up * -10);
            else if (angle < -2)
                rb.AddTorque(transform.up * 10);

            if(Mathf.Abs(angle) < 10 && rb.velocity.magnitude <3)
            {
                rb.AddForce(transform.forward * 40);
            }


            Animator anim = GetComponent<Animator>(); // récup l'animator
            if (anim != null)
            {
                anim.SetFloat("Walk", rb.velocity.magnitude);
            }

          
        }

    }
}