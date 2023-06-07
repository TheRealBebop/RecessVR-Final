using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    // [SerializeField] MeshRenderer mesh;
    [SerializeField] GameObject mesh;
    [SerializeField] float blastRadius = 3f;
    [SerializeField] float delay = 1f;
    Rigidbody rig;
    ZombombHealth health2;
    EnemyHealth health;
    Player playa;
    bool played = false;

    void Start()
    {
        playa = GetComponent<Player>();
        Invoke("Explode", delay);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }

    // Update is called once per frame
    public void Explode()
    {
        // mesh.enabled = false;
        explosionEffect.Play();
        mesh.SetActive(false);
        Kill();
        played = true;
        Invoke("Stop", 2f);
        // Destroy(this.gameObject);
    }

    private void Kill()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Enemy"))
            {
                Debug.Log(nearbyObject.gameObject.name);
                health = nearbyObject.gameObject.GetComponent<EnemyHealth>();
                health.TakeDamage(100f);
            }
        }
    }

    public void Stop()
    {
        Destroy(gameObject);
    }
}
// score++;
// playa = GetComponent<Player>();
// playa.AddToScore();
// playa.AddToScore(score);
// if (nearbyObject.CompareTag("Enemy"))
// {
//     // Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
//     // Debug.Log("RIGIDBODIES COLLECTED");
//     // if (rb != null)
//     // {
//     //     // NavMeshAgent nm = nearbyObject.GetComponent<NavMeshAgent>();
//     //     // nm.enabled = false;
//     //     rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
//     //     // rb.AddExplosionForce(explosionForce, transform.position, blastRadius, 0f, ForceMode.Impulse);
//     //     Debug.Log("boom");
//     // }
//     float time = 1.3f;
//     do
//     {
//         time = time - Time.deltaTime;
//     }
//     while (time > 0f);
//     // if (time == 0f)
//     // {
//     // }
// }
// Invoke("Kill", 1f);
