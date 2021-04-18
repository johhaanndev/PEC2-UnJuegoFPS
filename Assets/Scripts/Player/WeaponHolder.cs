using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolder : MonoBehaviour
{
    public int selectedWeapon = 0;

    public Text chamberAmmoText;
    public Text remainingAmmoText;

    public GameObject assaultLogo;
    public GameObject gunLogo;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

        if (selectedWeapon == 0)
        {
            assaultLogo.SetActive(true);
            gunLogo.SetActive(false);
        }

        if (selectedWeapon == 1)
        {
            assaultLogo.SetActive(false);
            gunLogo.SetActive(true);
        }
    }

    // enable gameobject when select weapon
    private void SelectWeapon()
    {
        int index = 0;
        foreach (Transform weapon in transform)
        {
            if (index == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            index++;
        }
    }

}
