using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public List<WeaponObject> weapons = new List<WeaponObject>();
    public List<GameObject> weaponObjects = new List<GameObject>(7);
    public List<Animator> animators = new List<Animator>(7);
    GrappleHook hook;
    public GameObject weaponPos, meleePos;
    int selected;
    AudioSource Gunshot, reload;
    

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        Gunshot = sources[0];
        reload = sources[1];
        selected = 0;
        hook = GetComponent<GrappleHook>();
        for (int i = 1; i < weapons.Count; i++)
        {
            switch(weapons[i].WeaponType)
            {
                case type.Gun:
                    weaponObjects.Add(weapons[i].spawnPrefab(weaponPos.transform));
                    animators.Add(weaponObjects[i].GetComponent<Animator>());
                    weaponObjects[i].SetActive(false);
                    break;
                case type.Bow:
                    weaponObjects.Add(weapons[i].spawnPrefab(weaponPos.transform));
                    animators.Add(weaponObjects[i].GetComponent<Animator>());
                    weaponObjects[i].SetActive(false);
                    break;
                case type.Melee:
                    weaponObjects.Add(weapons[i].spawnPrefab(meleePos.transform));
                    //animators.Add(weaponObjects[i].GetComponent<Animator>());
                    weaponObjects[i].SetActive(false);
                    break;
            }
        }

        for (int i = 1; i < weaponObjects.Count; i++)
        {
            weaponObjects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        getSelected();
        if (selected != 0)
        {
            weapons[selected].Update();
        }

        if(Input.GetMouseButtonDown(0) && selected != 0)
        {
            switch(weapons[selected].WeaponType)
            {
                case type.Gun:
                    if (!weapons[selected].shoot(weaponObjects[selected], Gunshot, true))
                    {
                        //EventManager.triggerAttack();
                        Debug.Log(selected);
                        Debug.Log("reloading");
                        animators[selected].SetTrigger("Reload");
                        StartCoroutine(weapons[selected].cooldown(reload));
                    }
                    else
                    {
                        //EventManager.triggerAttack();
                        animators[selected].SetTrigger("Shoot");
                        StopAllCoroutines();
                        animators[selected].SetTrigger("Shoot");
                    }
                    break;
                case type.Bow:
                    weapons[selected].shoot(weaponObjects[selected], Gunshot, true);
                    break;
                case type.Melee:
                    if(!weapons[selected].shoot(weaponObjects[selected], Gunshot, true))
                    {
                        EventManager.triggerAttack(20.0f);
                        //StartCoroutine(weapons[selected].cooldown(reload));
                    }
                    else
                    {
                        

                        //animators[selected].SetTrigger("Shoot");
                        //StopAllCoroutines();
                        //animators[selected].SetTrigger("Shoot");
                    }
                    break;
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            switch(weapons[selected].WeaponType)
            {
                case type.Bow:
                    weapons[selected].shoot(weaponObjects[selected], Gunshot, false);
                    break;
            }
            
        }
    }
    void changeSelection(int select)
    {
        weaponObjects[selected].SetActive(false);
        selected = select;
        weaponObjects[selected].SetActive(true);
    }
    void getSelected()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeSelection(0);
            hook.setSelected(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeSelection(1);
            hook.setSelected(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            changeSelection(2);
            hook.setSelected(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            changeSelection(3);
            hook.setSelected(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            changeSelection(4);
            hook.setSelected(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            changeSelection(5);
            hook.setSelected(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            changeSelection(6);
            hook.setSelected(false);
        }
    }

    private void OnEnable()
    {
        EventManager.OnAttack += test;
        EventManager.OnAIAttack += test2;
    }
    void test(float damage)
    {
        Debug.Log("Playerattacking");
    }

    void test2(float damage)
    {
        Debug.Log("AI Attacking");
    }
}