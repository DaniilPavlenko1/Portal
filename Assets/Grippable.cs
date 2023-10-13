using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grippable : MonoBehaviour
{
    public bool isGrabbed = false;
    public GameObject Hand;
    Rigidbody body;
    AudioSource aSource;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        aSource = this.gameObject.AddComponent<AudioSource>();
        aSource.clip = Resources.Load<AudioClip>("Sounds/metal_hit_1");
        aSource.playOnAwake = false;
        aSource.spatialBlend = 1;
    }
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (isGrabbed)
        {
            body.AddForce((Hand.transform.position - transform.position) * 100);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(GameObject _Hand = null)
    {
        Hand = _Hand;
        if(isGrabbed == false)
        {
            body.drag = 15.0f;
            body.angularDrag = 15.0f;
            body.mass = 0.1f;
            body.useGravity = false;
            body.isKinematic = false;
            transform.position = Hand.transform.position;
            isGrabbed = true;
        }
        else
        {
            body.useGravity = true;
            body.drag = 0.0f;
            body.angularDrag = 0.0f;
            body.mass = 1;
            isGrabbed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float magnitude = collision.relativeVelocity.magnitude / 10;
        aSource.volume = Mathf.Clamp(magnitude, 0, 1);
        aSource.pitch = Random.Range(0.7f, 1.3f);
        aSource.Play();
    }

    void Kill()
    {
        Destroy(this.gameObject);
    }
}
