using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new shotgun", menuName = "weapons/shotgun")]
public class Shotgun : WeaponObject
{
    public GameObject bullet;
    public AudioClip ReloadEnd;
    public void Awake()
    {
        WeaponType = type.Gun;
        reloading = false;
        loaded = true;
        ammo = 2;
        
    }
    public override IEnumerator cooldown(AudioSource source)
    {
        if (!reloading)
        {
            source.clip = Reload;
            source.Play();
            reloading = true;
            yield return new WaitForSeconds(reloadTime);
            ammo = 2;
            loaded = true;
            source.clip = ReloadEnd;
            source.Play();
            reloading = false;
        }
        
    }


    public override bool shoot(GameObject gun, AudioSource source, bool ignore)
    {
        if(loaded)
        {
            source.clip = Shoot;
            source.Play();
            Vector3 gunRotation = gun.transform.eulerAngles;
            ammo--;
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
