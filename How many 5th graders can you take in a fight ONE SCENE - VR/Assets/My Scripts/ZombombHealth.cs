using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombombHealth : MonoBehaviour
{
    [SerializeField] public float hitPoints = 100f;

    // [SerializeField] public float healthPoints = 100f;
    // NavMeshAgent navMeshAgent;
    [SerializeField] ParticleSystem zombieBlood;
    Player gameSession;
    [SerializeField] ParticleSystem explosion;
    ZombombExplosion explode;
    // EnemyAI ai;
    public bool isDead = false;
    ParticleSystem tempexplosion;

    private void Start()
    {
        // ai = FindObjectOfType<EnemyAI>();
        // zombieBlood = GetComponent<ParticleSystem>();
        gameSession = FindObjectOfType<Player>();
        explode = FindObjectOfType<ZombombExplosion>();
        // navMeshAgent = GetComponent<NavMeshAgent>();
        // GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // private void Update()
    // {
    //     if (isDead == true)
    //     {
    //         explosion.Play(true);
    //     }
    // }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        BroadcastMessage("OnDamageTaken");
        zombieBlood.Play(true);
        if (hitPoints <= 0)
        {
            explosion.Play(true);
            Die();
            gameSession.AddToScore();
            Debug.Log(gameObject.name + " has been killed");
        }
    }

    public void Suicide()
    {
        hitPoints = 0f;
        if (isDead)
        {
            return;
        }
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        explode.Explode();
        // tempexplosion.Play();
        // navMeshAgent.enabled = false;
        // ai.enabled = false;
    }
}
