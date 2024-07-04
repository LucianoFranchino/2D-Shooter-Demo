using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public GameObject[] guns;
    public int activeWeaponI { get; private set; }

    private void Start()
    {
        activeWeaponI = 0;
    }

    private void Update()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1 + i))
            {
                SwitchWeapons(i);
            }
        }
    }

    private void SwitchWeapons(int weaponIndex)
    {
        if (weaponIndex != activeWeaponI && weaponIndex >= 0 && weaponIndex < guns.Length)
        {
            guns[activeWeaponI].SetActive(false); 
            activeWeaponI = weaponIndex;
            guns[activeWeaponI].SetActive(true);
        }
    }

    public void ActivateWeapon(int weaponIndex)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(i == weaponIndex);
        }
    }

}
