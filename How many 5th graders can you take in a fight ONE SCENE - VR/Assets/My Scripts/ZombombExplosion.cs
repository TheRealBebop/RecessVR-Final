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
                if (rb != null && nearbyObject.GetComponent<EnemyHealth>().isDead == false)
                {
                }
                health = nearbyObject.gameObject.GetComponent<EnemyHealth>();
                health.TakeDamage(100f);
            }
        }
    }
}