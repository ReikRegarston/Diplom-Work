using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Again : MonoBehaviour
{
    public static Rigidbody rb;
    private float speedCircle = 30f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(0f, 0f, vertical * ForMe.speed);
        rb.AddForce(Vector3.forward  + transform.TransformDirection(move) * Time.fixedDeltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            rb.MovePosition(transform.position + transform.forward * -1 * 50f * Time.fixedDeltaTime);
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (ForMe.speed > 701f)
            transform.Rotate(Vector3.up * speedCircle * horizontal * Time.deltaTime);
    }
}
