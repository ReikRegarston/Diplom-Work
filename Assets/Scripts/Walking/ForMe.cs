using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ForMe : MonoBehaviour
{
    private float checkVer;
    private bool wasShoot = false;

    public Transform fitcha;
    public static float speed = 700f, startMove = 1;

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        transform.position = new Vector3(fitcha.position.x - 0.05f, fitcha.position.y + 1.1f, fitcha.position.z);

        if (Input.GetButtonDown("Fire1"))
        {
            TankRotatation(3.5f, -1);
            wasShoot = true;
            StartCoroutine(CheckShoot(wasShoot));

        }

        if (vertical == 1 || vertical == -1)
            checkVer = vertical;

        if (vertical != 0)
        {
            StartCoroutine(HowSpeed());
            TankRotatation(startMove, 0);
        }

        if (speed >= 850)
            speed = 850;
        if (speed < 700)
            speed = 700;

        if (Again.rb.velocity == Vector3.zero && wasShoot == false)
        {
            StopCoroutine(HowSpeed());
            TankRotatation(startMove, 0);
            startMove = 0;
        }

    }

    private void LateUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        transform.position = new Vector3(fitcha.position.x - 0.05f, fitcha.position.y + 1.1f, fitcha.position.z);
        if (vertical == 0 && speed != 700f)
        {
            float num = Again.rb.velocity.magnitude;
            StopCoroutine(HowSpeed());
            speed--;
            if (transform.rotation.x > 0 && checkVer == -1)
            {
                TankRotatation(startMove, num);
            }
            if (transform.rotation.x < 0 && checkVer == 1)
            {
                TankRotatation(startMove, -num);
            }
        }

    }

    IEnumerator HowSpeed()
    {
        yield return new WaitForSeconds(1f);
        speed += 0.5f;
        startMove += 0.25f;
        if (startMove >= 3.75f)
            startMove = 3.50f;
    }

    IEnumerator CheckShoot(bool bullet)
    {
        while(bullet == true) 
        {
            yield return new WaitForSeconds(2f);
            wasShoot = false;
        }
    }

    private void TankRotatation(float tankRotation, float needSlow)
    {
        float vertical = Input.GetAxis("Vertical");
        if (needSlow == 0)
            needSlow = vertical;

        transform.Rotate(Vector3.left * tankRotation * needSlow * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(Math.Clamp(tankRotation * needSlow * -1, -3.5f, 3.5f),
            transform.rotation.y,
            transform.rotation.z);
    }
}
