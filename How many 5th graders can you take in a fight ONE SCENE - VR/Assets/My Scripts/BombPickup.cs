using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombPickup : MonoBehaviour
{
    [SerializeField] int Ammo;
    GrenadeLauncher Launcher;
    public UnityEvent pickupDisplay;

    void Start()
    {
        Launcher = FindObjectOfType<GrenadeLauncher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupDisplay.Invoke();
            Launcher.IncreaseAmmo(Ammo);
            Destroy(gameObject);
            // StartCoroutine(DisplayPickupCanvas());
        }
    }
}
