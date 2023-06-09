using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponPickup : MonoBehaviour
{
    public bool weaponPickedUp = false;
    [SerializeField] Weapon gun;
    public UnityEvent pickupDisplay;

    // private void Start()
    // {
    //     weaponEquip = gun;
    // }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // weaponPickedUp = true;
            // Call a function in Weapon.cs to set pickedUp to true
            pickupDisplay.Invoke();
            gun.EquipWeapon();
            Destroy(gameObject);
        }
    }
}
