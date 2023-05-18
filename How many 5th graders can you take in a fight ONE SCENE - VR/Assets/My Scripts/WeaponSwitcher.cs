using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] InputActionReference switchKey;
    [SerializeField] int currentWeapon/* = 0*/;

    public void Start()
    {
        GameObject.Find("Glock").SetActive(true);
        switchKey.action.performed += changeGun;
    }

    public void changeGun(InputAction.CallbackContext context)
    {
        if (currentWeapon == weapons.Length - 1)
        {
            if (weapons[0].GetComponent<Weapon>().equippedByDefault == true && weapons[0].GetComponent<Weapon>().pickedUp == false)
            {
                currentWeapon = 0;
                foreach (GameObject x in weapons)
                {
                    if (x != weapons[currentWeapon])
                    {
                        x.SetActive(false);
                    }
                }
                weapons[currentWeapon].SetActive(true);
            }
        }
        else if (currentWeapon == 0)
        {
            if (weapons[1].GetComponent<Weapon>().pickedUp == true)
            {
                currentWeapon++;
                foreach (GameObject x in weapons)
                {
                    if (x != weapons[currentWeapon])
                    {
                        x.SetActive(false);
                    }
                }
                weapons[currentWeapon].SetActive(true);
            }
        }
        // else if (currentWeapon == 1)
        // {

        // }
        // else if (currentWeapon == 2)
        // {

        // }
    }




    // [SerializeField] int currentWeapon = 0;

    // void Start()
    // {
    //     SetWeaponActive();
    // }
    // void Update()
    // {
    //     int previousWeapon = currentWeapon;

    //     // ProcessKeyInput();
    //     ProcessScrollWheel();

    //     if (currentWeapon == previousWeapon)
    //     {
    //         SetWeaponActive();
    //     }
    // }

    // private void ProcessScrollWheel()
    // {
    //     if (Input.GetAxis("Mouse ScrollWheel") > 0)
    //     {
    //         if (currentWeapon >= transform.childCount - 1)
    //         {
    //             currentWeapon = 0;
    //         }
    //         else
    //         {
    //             currentWeapon++;
    //         }
    //     }
    //     if (Input.GetAxis("Mouse ScrollWheel") < 0)
    //     {
    //         if (currentWeapon <= 0)
    //         {
    //             currentWeapon = transform.childCount - 1;
    //         }
    //         else
    //         {
    //             currentWeapon--;
    //         }
    //     }
    //

    // private void ProcessKeyInput()
    // {
    //     if (Input.GetKeyDown(KeyCode.Alpha1))
    //     {
    //         currentWeapon = 0;
    //     }
    //     else if (Input.GetKeyDown(KeyCode.Alpha2))
    //     {
    //         currentWeapon = 1;
    //     }
    //     // else if (Input.GetKeyDown(KeyCode.Alpha3))
    //     // {
    //     //     currentWeapon = 2;
    //     // }
    //     // else if (Input.GetKeyDown(KeyCode.Alpha4))
    //     // {
    //     //     currentWeapon = 3;
    //     // }
    // }

    // private void SetWeaponActive()
    // {
    //     int weaponIndex = 0;
    //     foreach (Transform weapon in transform)
    //     {
    //         if (weaponIndex == currentWeapon)
    //         {
    //             weapon.gameObject.SetActive(true);
    //         }
    //         else
    //         {
    //             weapon.gameObject.SetActive(false);
    //         }
    //         weaponIndex++;
    //     }
    // }
}