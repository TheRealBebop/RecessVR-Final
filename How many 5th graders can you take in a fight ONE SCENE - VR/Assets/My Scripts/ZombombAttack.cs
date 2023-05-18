using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombombAttack : MonoBehaviour
{
    Player target;
    DisplayDamage player;
    ZombombHealth health;
    // ZombombExplosion explode;
    // GameObject explosion;
    public ParticleSystem explosion;
    [SerializeField] float damage = 70f;

    void Start()
    {
        target = FindObjectOfType<Player>();
        player = FindObjectOfType<DisplayDamage>();
        health = FindObjectOfType<ZombombHealth>();
        // explode = FindObjectOfType<ZombombExplosion>();
        // explosion = GameObject.Find("Zombomb Explosion Effect");
    }

    public void ZombombAttackHitEvent()
    {
        if (target == null)
        {
            return;
        }
        health.Suicide();
        player.GetComponent<DisplayDamage>().ShowDamageImpact();
        target.TakeDamage(damage);
    }

    public void ZombombExplosionEvent()
    {
        explosion.Play();
        // explode.Explode();
    }

    public void ZombombExplosionStopEvent()
    {
        explosion.Stop();
    }
}
