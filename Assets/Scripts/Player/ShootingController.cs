using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    public AudioSource assaultFireSound;
    public AudioSource gunFireSound;
    public AudioSource reloadSound;

    public int assaultDamage = 25;
    public int gunDamage = 10;
    public GameObject weapons;
    private WeaponHolder weaponHolder;

    private AssaultRifle assaultRifle = new AssaultRifle();
    public Transform assaultFirePoint;
    private Gun gun = new Gun();
    public Transform gunFirePoint;

    public LayerMask enemyLayer;

    public Text chamberAmmoText;
    public Text remainingAmmoText;

    private int substractAssault;
    private int substractGun;

    public GameObject BulletSparks;
    public GameObject FireParticles;

    private void Start()
    {
        weaponHolder = weapons.gameObject.GetComponent<WeaponHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponHolder.selectedWeapon == 0)
        {
            chamberAmmoText.text = assaultRifle.currentChamberAmmo.ToString();
            remainingAmmoText.text = "/" + assaultRifle.currentTotalAmmo.ToString();
        }
        if (weaponHolder.selectedWeapon == 1)
        {
            chamberAmmoText.text = gun.currentChamberAmmo.ToString();
            remainingAmmoText.text = "/" + gun.currentTotalAmmo.ToString();
        }

        
        if (Input.GetMouseButtonDown(0))
        {
            if (weaponHolder.selectedWeapon == 0)
            {
                AssaultAmmoManagement();
                substractAssault = assaultRifle.totalChamberAmmo - assaultRifle.currentChamberAmmo;
            }

            if (weaponHolder.selectedWeapon == 1)
            {
                GunAmmoManagement();
                substractGun = gun.totalChamberAmmo - gun.currentChamberAmmo;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (weaponHolder.selectedWeapon == 0)
            {
                AssaultReload();
            }

            if (weaponHolder.selectedWeapon == 1)
            {
                GunReload();
            }
        }
        
    }

    private void AssaultAmmoManagement()
    {
        chamberAmmoText.text = assaultRifle.currentChamberAmmo.ToString();
        remainingAmmoText.text = "/" + assaultRifle.currentTotalAmmo.ToString();

        if (assaultRifle.currentChamberAmmo > 0)
        {
            assaultRifle.currentChamberAmmo--;
            AssaultFire();

            assaultFireSound.Play();
        }
        else
        {
            if (assaultRifle.currentTotalAmmo > 0)
            {
                // reload
                AssaultReload();
            }
        }
    }

    private void AssaultFire()
    {
        Instantiate(FireParticles, assaultFirePoint);
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                //Debug.Log("EnemyHit");
                hit.collider.gameObject.GetComponent<EnemyAI>().Hit(assaultDamage);
            }

            if (hit.collider.gameObject.CompareTag("Projector"))
            {
                //Debug.Log("Projector hit");
                hit.collider.gameObject.GetComponent<Projector>().Hit(assaultDamage / 2);
            }

            GameObject.Instantiate(BulletSparks, 
                                    hit.point + hit.normal * 0.01f, 
                                    Quaternion.FromToRotation(Vector3.forward, -hit.normal));
        }
    }

    private void AssaultReload()
    {
        if (assaultRifle.currentTotalAmmo <= 0)
        {
            // Write message "No ammunition" in center of screen
        }
        else
        {
            if (assaultRifle.currentChamberAmmo == assaultRifle.totalChamberAmmo)
            {
                Debug.Log("Full ammo, won't reload");
            }
            else
            {
                reloadSound.Play();
                //Debug.Log("Reload");
                if (assaultRifle.currentTotalAmmo <= assaultRifle.totalChamberAmmo)
                {

                    if (substractAssault >= assaultRifle.currentTotalAmmo)
                    {
                        assaultRifle.currentChamberAmmo += assaultRifle.currentTotalAmmo;
                        assaultRifle.currentTotalAmmo = 0;
                    }
                    else
                    {
                        assaultRifle.currentTotalAmmo -= substractAssault;
                        assaultRifle.currentChamberAmmo += substractAssault;
                    }
                    substractAssault = 0;
                }
                else
                {
                    assaultRifle.currentTotalAmmo -= substractAssault;
                    assaultRifle.currentChamberAmmo += substractAssault;
                }
            }
        }
    }

    private void GunAmmoManagement()
    {
        chamberAmmoText.text = gun.currentChamberAmmo.ToString();
        remainingAmmoText.text = "/" + gun.currentTotalAmmo.ToString();

        if (gun.currentChamberAmmo > 0)
        {
            //Debug.Log("Still ammo");
            gun.currentChamberAmmo--;

            GunFire();

            gunFireSound.Play();
        }
        else
        {
            if (gun.currentTotalAmmo > 0)
            {
                // reload
                GunReload();
            }
        }
    }

    private void GunFire()
    {
        Instantiate(FireParticles, gunFirePoint);
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit))
        {
            //Debug.Log("Gun Shoot");
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<EnemyAI>().Hit(gunDamage);
            }

            if (hit.collider.gameObject.CompareTag("Projector"))
            {
                //Debug.Log("Projector hit");
                hit.collider.gameObject.GetComponent<Projector>().Hit(gunDamage / 2);
            }

            GameObject.Instantiate(BulletSparks,
                                    hit.point + hit.normal * 0.01f,
                                    Quaternion.FromToRotation(Vector3.forward, -hit.normal));
        }
    }

    private void GunReload()
    {
        
        if (gun.currentTotalAmmo <= 0)
        {
            // Write message "No ammunition" in center of screen
        }
        else
        {
            if (gun.currentChamberAmmo == gun.totalChamberAmmo)
            {
                Debug.Log("Full ammo, won't reload");
            }
            else
            {
                reloadSound.Play();
                if (gun.currentTotalAmmo <= gun.totalChamberAmmo)
                {

                    if (substractGun >= gun.currentTotalAmmo)
                    {
                        gun.currentChamberAmmo += gun.currentTotalAmmo;
                        gun.currentTotalAmmo = 0;
                    }
                    else
                    {
                        gun.currentTotalAmmo -= substractGun;
                        gun.currentChamberAmmo += substractGun;
                    }
                }
                else
                {
                    gun.currentTotalAmmo -= substractGun;
                    gun.currentChamberAmmo += substractGun;
                    
                }
                substractGun = 0;
            }
        }
    }

    public void AddAmmo(int assaultAmmo, int gunAmmo)
    {
        assaultRifle.currentTotalAmmo += assaultAmmo;
        gun.currentTotalAmmo += gunAmmo;
    }
}

public class AssaultRifle
{
    public int currentTotalAmmo;
    public int currentChamberAmmo;
    public int totalChamberAmmo;

    public AssaultRifle()
    {
        currentTotalAmmo = 30;
        totalChamberAmmo = 30;
        currentChamberAmmo = totalChamberAmmo;
    }
}

public class Gun
{
    public int currentTotalAmmo;
    public int currentChamberAmmo;
    public int totalChamberAmmo;

    public Gun()
    {
        currentTotalAmmo = 21;
        totalChamberAmmo = 7;
        currentChamberAmmo = totalChamberAmmo;
    }
}
