using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestruction : MonoBehaviour
{
    public float life_time = 5;

    void Start()
    {
        Destroy(this.gameObject, life_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
