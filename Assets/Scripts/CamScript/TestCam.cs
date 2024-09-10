using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    private float yMin = -5f;
    private float yMax = 42.7f;
    private float xMin = -60.5f;
    private float XMax = 60.5f;
    private float currentX = 0f;
    private float currentY = 0f;

    public Transform player;


    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * 0.2f;
        currentY += -0.2f * Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, yMin, yMax);
        currentX = Mathf.Clamp(currentX, xMin, XMax);

        if(player.rotation.y < 1 && player.rotation.y > -1)
            transform.localRotation = Quaternion.Euler(currentY, currentX, 0);
        if (player.rotation.y > 1 && player.rotation.y < -1)
            transform.localRotation = Quaternion.Euler(currentY, player.rotation.y * currentX * 1, 0);
    }
}
