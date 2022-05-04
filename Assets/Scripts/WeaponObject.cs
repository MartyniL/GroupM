using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum type
{
    Gun,
    Bow,
    Melee
};

public abstract class WeaponObject : ScriptableObject
{
    public type WeaponType;
    public float bulletDamage;
    public int bullets;
    public float reloadTime, spawnDist;
    public bool loaded, reloading;
    public int ammo;
    public float maxSpread;
    public GameObject WeaponPrefab;
    public Vector3 initialRotation;
    public AudioClip Shoot, Reload;

    public abstract void Update();

    public abstract bool shoot(GameObject gun, AudioSource source, bool buttonUp);

    public abstract IEnumerator cooldown(AudioSource source);

    public GameObject spawnPrefab(Transform _transform)
    {
        return Instantiate(WeaponPrefab, _transform.position + new Vector3(spawnDist, 0f, 0f), Quaternion.Euler(initialRotation), _transform);
    }
}
