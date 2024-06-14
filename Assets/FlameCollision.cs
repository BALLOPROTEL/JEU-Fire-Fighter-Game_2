using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCollision : MonoBehaviour
{
    public float explosionForce = 50f;
    public float explosionRadius = 2f;

    void OnCollisionEnter(Collision collision)
    {
        // Vérifiez si la collision concerne une brique avec le tag "Destructible"
        if (collision.gameObject.CompareTag("Destructible"))
        {
            Explode(collision.contacts[0].point);
        }
    }

    void Explode(Vector3 explosionPoint)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPoint, explosionRadius);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Destructible"))
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.AddExplosionForce(explosionForce, explosionPoint, explosionRadius);
                }
            }
        }
    }
}
