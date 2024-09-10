using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float yMin = -5f;
    private float yMax = 10f;
    private float currentY = 0f;



    private void Update()
    {
        currentY += -0.25f * Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, yMin, yMax);
    }

    private void LateUpdate()
    {
        transform.localRotation = Quaternion.Euler(currentY, 0, 0);
    }
}
