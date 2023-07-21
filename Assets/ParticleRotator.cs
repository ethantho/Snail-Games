using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotator : MonoBehaviour
{
    ParticleSystem ps;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SyncParticles()
    {
        var main = ps.main;
       // main.startRotationZ = transform.rotation.
    }
}
