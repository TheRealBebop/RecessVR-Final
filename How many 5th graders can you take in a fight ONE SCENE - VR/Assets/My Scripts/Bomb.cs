using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    [SerializeField] float blastRadius = 3f;
    [SerializeField] float explosionForce = 10000f;
    [SerializeField] float delay = 1f;
    Rigidbody rig;
    ZombombHealth health2;
    EnemyHealth health;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        Invoke("Explode", delay);
    }

    // Update is called once per frame
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        Debug.Log("BOOOOOOOOOM");
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Enemy"))
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                Debug.Log("RIGIDBODIES COLLECTED");
                if (rb != null)
                {
                    // NavMeshAgent nm = nearbyObject.GetComponent<NavMeshAgent>();
                    // nm.enabled = false;
                    rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
                    // rb.AddExplosionForce(explosionForce, transform.position, blastRadius, 0f, ForceMode.Impulse);
                    Debug.Log("boom");
                }
                health = nearbyObject.gameObject.GetComponent<EnemyHealth>();
                health.TakeDamage(100f);
            }
        }
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Invoke("Destroy", 2f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

}
