using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Pistol", menuName = "weapons/EnemyPistol")]
public class EnemyPistol : WeaponObject
{
    public GameObject bullet;
    private void Awake()
    {
        WeaponType = type.Gun;
        reloading = false;
        loaded = true;
        ammo = 15;
    }
    public override IEnumerator cooldown(AudioSource source)
    {
        if (!reloading)
        {
            reloading = true;
            source.clip = Reload;
            source.Play();
            yield return new WaitForSeconds(reloadTime);
            ammo = 15;
            loaded = true;
            reloading = false;
        }
    }

    public override bool shoot(GameObject gun, AudioSource source, bool ignore)
    {
        if (loaded)
        {
            source.clip = Shoot;
            source.Play();
            Vector3 gunRotation = gun.transform.eulerAngles;
            Instantiate(bullet, gun.transform.Find("GunTip").transform.position, Quaternion.Euler(gunRotation + new Vector3(0f, 0f, Random.Range(-maxSpread, maxSpread))));
            //ammo--;
            if (ammo == 0)
            {
                //loaded = false;
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
