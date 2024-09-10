using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    public ParticleSystem fireShoot;
    public GameObject bullet;
    public Transform gun;
    public float bulletSpeed = 50f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            ShootFire();
    }

    private void ShootFire()
    {
        fireShoot.Play();

        GameObject bulletCreated = Instantiate(bullet) as GameObject;
        bulletCreated.transform.position = transform.position;
        bulletCreated.transform.rotation = transform.rotation;
        bulletCreated.transform.Translate(0, 0, 1.5f, Space.Self);
        bulletCreated.GetComponent<Rigidbody>().AddRelativeForce(bulletCreated.transform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
