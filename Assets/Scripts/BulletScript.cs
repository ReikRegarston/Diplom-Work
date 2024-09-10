using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private bool hit = true;
    private Rigidbody rb;
    private Vector3 effect;

    public ParticleSystem explotion;
    public float power = 50, radiusEx = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hit == true)
        {
            hit = false;
            effect = transform.position;
            Instantiate(explotion, effect, Quaternion.identity);
            Collider[] hitCollider = Physics.OverlapSphere(effect, radiusEx);
            foreach (Collider hit in hitCollider)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(power, effect, radiusEx, 3f, ForceMode.Impulse);
            }
            Destroy(gameObject);
        }
    }
}
