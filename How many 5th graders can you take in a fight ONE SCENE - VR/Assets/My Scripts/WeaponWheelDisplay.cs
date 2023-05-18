using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponWheelDisplay : MonoBehaviour
{
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetAmmoAmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }
}
