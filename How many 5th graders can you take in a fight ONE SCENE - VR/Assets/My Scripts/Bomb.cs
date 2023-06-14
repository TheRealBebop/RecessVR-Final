using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    // [SerializeField] MeshRenderer mesh;
    [SerializeField] GameObject mesh;
    [SerializeField] float blastRadius = 3f;
    [SerializeField] float delay = 1f;
    Player playa;
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
    public void Explode()
    {
        explosionEffect.Play();
        mesh.SetActive(false);
        Kill();
        Invoke("Stop", 2f);
    }
    private void Kill()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Enemy"))
            {
                Debug.Log(nearbyObject.gameObject.name);
                nearbyObject.gameObject.GetComponent<EnemyHealth>().TakeDamage(100f);
            }

            if (nearbyObject.CompareTag("Zombomb"))
            {
                Debug.Log(nearbyObject.gameObject.name);
                nearbyObject.gameObject.GetComponent<ZombombHealth>().TakeDamage(100f);
            }

            if (nearbyObject.CompareTag("Debris"))
            {
                Destroy(nearbyObject);
            }
        }
    }
    public void Stop()
    {
        Destroy(gameObject);
    }
}