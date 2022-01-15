using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject projectile;
    public float distance;
    public int Delay;
    private int currentDelay;
    public float speed;
    private void Start()
    {
        currentDelay = Delay;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && currentDelay >= Delay)
        {
            GameObject temp;

           temp = Instantiate(projectile, (transform.position + transform.forward * distance), Quaternion.LookRotation(transform.forward, Vector3.up));
            currentDelay = 0;

            temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward*speed);
        }
        currentDelay++;
    }
}

