using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new shotgun", menuName = "weapons/EnemyShotgun")]
public class EnemyShotgun : WeaponObject
{
    public GameObject bullet;
    public AudioClip ReloadEnd;
    public void Awake()
    {
        WeaponType = type.Gun;
        reloading = false;
        loaded = true;
        ammo = 99999;

    }
    public override IEnumerator cooldown(AudioSource source)
    {
        if (!reloading)
        {
            source.clip = Reload;
            source.Play();
            yield return new WaitForSeconds(reloadTime);
            source.clip = ReloadEnd;
            source.Play();
            ammo = 99999;
        }

    }


    public override bool shoot(GameObject gun, AudioSource source, bool ignore)
    {
        if (loaded)
        {
            source.clip = Shoot;
            source.Play();
            Vector3 gunRotation = gun.transform.eulerAngles;
            //Debug.Log(gunRotation);
            if (ammo == 0)
            {
                loaded = false;
            }
            for (int i = 0; i < bullets; i++)
            {
                Instantiate(bullet, gun.transform.Find("GunTip").transform.position, Quaternion.Euler(gunRotation + new Vector3(0f, 0f, Random.Range(-maxSpread, maxSpread))));
            }


            return loaded;
        }
        else
        {
            return loaded;
        }
    }

    public override void Update()
    {

    }
}
