using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombombExplosion : MonoBehaviour
{

    [SerializeField] float blastRadius = 3f;
    [SerializeField] float explosionForce = 10000f;

    ZombombHealth health2;
    EnemyHealth health;

    void Start()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }

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
                Debug.Log("boom bitch");


                //try adding impulse mode to addExplosion
                //try making the rigidbodies Kinematic
            }
            // else if (nearbyObject.CompareTag("Zombomb"))
            // {
            //     Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            //     Debug.Log("RIGIDBODIES COLLECTED");
            //     if (rb != null)
            //     {
            //         // rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            //         rb.AddExplosionForce(explosionForce, transform.position, blastRadius, 0f, ForceMode.Impulse);
            //         Debug.Log("boom");
            //     }
            //     health2 = nearbyObject.gameObject.GetComponent<ZombombHealth>();
            //     health2.TakeDamage(100f);
            //     Debug.Log("boom bitch");
            // }
        }
    }
}