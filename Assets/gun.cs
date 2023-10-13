using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float gunDistance = 23.0f;
    public float gunForce = 20.0f;
    public float gunDamage = 100.0f;
    public Camera PlayerCamera;
    public GameObject Bullet;

    public AudioClip laser_shot;
    AudioSource AudioSource;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().Play("gun_shot");
        }
    }

    public void Shoot()
    {
        AudioSource.clip = laser_shot;
        AudioSource.Play();
        GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
        bullet.GetComponent<Rigidbody>().AddForce((PlayerCamera.gameObject.transform.forward * 100), ForceMode.Impulse);

        RaycastHit hit;
        Debug.DrawRay(PlayerCamera.transform.position, PlayerCamera.transform.TransformDirection(Vector3.forward) * gunDistance, Color.red);
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, gunDistance))
        {
            hit.transform.gameObject.BroadcastMessage("TakeDamage", gunDamage, SendMessageOptions.DontRequireReceiver);
            if (hit.transform.gameObject.GetComponent<Rigidbody>())
            {
                hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(PlayerCamera.transform.forward * gunForce, ForceMode.Impulse);
            }
        }
    }
}
