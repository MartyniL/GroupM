using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "new Sword", menuName = "weapons/sword")]

public class SwordAndShield : WeaponObject
{
    private void Awake()
    {
        
    }
    public override IEnumerator cooldown(AudioSource source)
    {
        yield return new WaitForSeconds(reloadTime);
        ammo = 1;
        loaded = true;
    }

    public override bool shoot(GameObject weapon, AudioSource source, bool buttonUp)
    {
        if (loaded)
        {
            ammo--;
            if (ammo == 0)
            {
                loaded = false;
                return false;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Update()
    {
        
    }
}
