using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    [SerializeField] public bool equippedByDefault = true;
    [SerializeField] public bool pickedUp = false;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject grenade;
    [SerializeField] float range;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] InputActionReference fireActionReference;
    [SerializeField] public int ammo;
    [SerializeField] TextMeshProUGUI ammoText;
    public bool canShoot = true;
    public AudioSource gunshotSound;
    public bool triggerPressed = false;
    private void OnEnable()
    {
        canShoot = true;
    }

    private void Start()
    {
        fireActionReference.action.performed += OnFired;
        gunshotSound = GetComponent<AudioSource>();
        // fire.performed += OnFired;
        // fire.canceled += OnFired;
        // fire.Enable();
        // ammoSlot = GetComponent<Ammo>();
    }
    public void OnFired(InputAction.CallbackContext context)
    {
        triggerPressed = true; /*context.ReadValueAsButton();*/
        Debug.Log("trigger pressed");
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        Debug.Log("coroutine running");
        canShoot = true;
        if (ammo > 0 && canShoot == true)
        {
            PlayMuzzleFlash();
            gunshotSound.Play();
            Launch();
            ammo--;
        }
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    public void EquipWeapon()
    {
        pickedUp = true;
    }
    void Update()
    {
        DisplayAmmo();
    }

    public void IncreaseAmmo(int bombAmmo)
    {
        ammo += bombAmmo;
    }

    private void DisplayAmmo()
    {
        ammoText.text = ammo.ToString();
    }

    // Update is called once per frame
    public void Launch()
    {
        GameObject grenadeInstance = Instantiate(grenade, spawnPoint.position, spawnPoint.rotation);
        grenadeInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
    }
}
