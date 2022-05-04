using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new bow", menuName = "weapons/bow")]
public class Bow : WeaponObject
{
    public GameObject arrowPrefab, arrowProjectile;
    public GameObject arrow, gun;
    public bool Drawing, drawTimerActive;
    public float maxDrawStrength, drawstrength, drawTime;
    public void Awake()
    {
        WeaponType = type.Bow;
        reloading = false;
        loaded = true;
        ammo = 1;
    }
    public override void Update()
    {
        if(drawTimerActive)
        {
            drawstrength += Time.deltaTime * 2;
            drawTime += Time.deltaTime;
            if (drawTime >= maxDrawStrength)
            {
                drawTimerActive = false;
            }
        }

    }
    public override IEnumerator cooldown(AudioSource source)
    {
        yield return 0;
    }

    public override bool shoot(GameObject _gun, AudioSource source, bool buttonDown)
    {
        gun = _gun;
        if(buttonDown)
        {
            Draw();
        }
        else
        {
            Release();
        }
        return true;
    }
    public void Draw()
    {
        Vector3 gunRotation = gun.transform.eulerAngles;
        arrow = Instantiate(arrowPrefab, gun.transform.Find("GunTip").transform.position, Quaternion.Euler(gunRotation + new Vector3(0f, 0f, Random.Range(-maxSpread, maxSpread))), gun.transform);
        drawstrength = 0f;
        drawTime = 0f;
        Drawing = true;
        drawTimerActive = true;
    }
    public void Release()
    {
        
        Drawing = false;
        drawTimerActive = false;
        Destroy(arrow);
        arrow = null;
        Vector3 gunRotation = gun.transform.eulerAngles;
        Instantiate(arrowProjectile, gun.transform.Find("GunTip").transform.position, Quaternion.Euler(gunRotation + new Vector3(0f, 0f, Random.Range(-maxSpread, maxSpread))));
        drawstrength = 0f;
        drawTime = 0f;
    }
}
