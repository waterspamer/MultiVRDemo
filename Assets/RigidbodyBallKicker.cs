using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyBallKicker : MonoBehaviour
{
    
    Vector3 lastPosition = Vector3.zero;
    private float speed;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity.x * 5, GetComponent<Rigidbody>().velocity.y * 5,
              //  GetComponent<Rigidbody>().velocity.z * 5);
            
              other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(5000f * speed, transform.position, .4f);
        }
    }

    private void Update()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        Debug.Log(speed);
    }
}
