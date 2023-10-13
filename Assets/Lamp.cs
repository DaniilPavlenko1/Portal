using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    AudioSource aSource;
    public float breakForce = 5;
    public AudioClip electric_break;
    public bool alive = true;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > breakForce && alive)
        {
            aSource.clip = electric_break;
            aSource.loop = false;
            aSource.Play();
            alive = false;

            GetComponentInChildren<Light>().enabled = false;
            this.gameObject.AddComponent<Rigidbody>();
        }
    }
}
