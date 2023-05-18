using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    // public GameObject pickupCanvas;
    Ammo GunAmmo;

    void Start()
    {
        // pickupCanvas.SetActive(true);
        // finalText.text = "+" + ammoAmount.ToString() + pickupText.text;
        GunAmmo = FindObjectOfType<Ammo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GunAmmo.IncreaseCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
            // StartCoroutine(DisplayPickupCanvas());
        }
    }

    IEnumerator DisplayPickupCanvas()
    {
        // pickupCanvas.SetActive(true);
        yield return new WaitForSeconds(3f);
        // pickupCanvas.SetActive(false);
    }
}