using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAll : MonoBehaviour
{
    private float xMin = -40.5f;
    private float XMax = 40.5f;
    private float currentX = 0f;

    public Transform player;

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * 0.2f;
        currentX = Mathf.Clamp(currentX, xMin, XMax);

        if (player.rotation.y < 1 && player.rotation.y > -1)
            transform.localRotation = Quaternion.Euler(-89.98f, currentX, 0);
        if (player.rotation.y > 1 && player.rotation.y < -1)
            transform.localRotation = Quaternion.Euler(-89.98f, player.rotation.y * currentX * 1, 0);

    }
}
