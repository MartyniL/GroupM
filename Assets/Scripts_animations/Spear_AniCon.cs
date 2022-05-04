using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_AniCon : MonoBehaviour
{
    //variables
    Animator animator;
    int is_SpearWalkHash;
    int is_SpearWalkBckHash;
    int is_SpearRunHash;
    int is_SpearDvFwdHash;
    int is_SpearBckFlipHash;

    //monkey
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("Spear_Idle");
        //hash for smoother animation and cleaner code
        animator = GetComponent<Animator>();
        is_SpearWalkHash = Animator.StringToHash("is_SpearWalk");
        is_SpearWalkBckHash = Animator.StringToHash("is_SpearWalkBck");
        is_SpearRunHash = Animator.StringToHash("is_SpearRun");
        is_SpearDvFwdHash = Animator.StringToHash("is_SpearDvFwd");
        is_SpearBckFlipHash = Animator.StringToHash("is_SpearBckFlip");
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------------------------------------------------------
        if (Input.GetButtonDown("Fire1"))
        {
            character.GetComponent<Animator>().Play("Spear_AttackStab");
        }
        //press 1 to roll
        if (Input.GetButtonDown("Fire2"))
            {
                character.GetComponent<Animator>().Play("Spear_Slash");
            }
        //press 2 to death animation
        if (Input.GetButtonDown("DeathKey"))
        {
            character.GetComponent<Animator>().Play("Death Animation");
        }
        /*   if (Input.GetButtonDown("3KeyBackFlip"))
           {
               character.GetComponent<Animator>().Play("Axe_BckFlp");
           }*/
        if (Input.GetButtonDown("Jump2"))
        {
            character.GetComponent<Animator>().Play("Axe_Jump");
        }
        //----------------------------------------------------------------------------------------

        bool is_SpearWalk = animator.GetBool(is_SpearWalkHash);
        bool SpearWalk = Input.GetKey("d");
        bool is_SpearWalkBck = animator.GetBool(is_SpearWalkBckHash);
        bool SpearWalkBck = Input.GetKey("a");
        bool is_SpearRun = animator.GetBool(is_SpearRunHash);
        bool SpearRun = Input.GetKey("left shift");
        bool is_SpearDvFwd = animator.GetBool(is_SpearDvFwdHash);
        bool Spear_DvFwd = Input.GetKey("left ctrl");
        bool is_SpearBckFlip = animator.GetBool(is_SpearBckFlipHash);
        bool Spear_BckFlip = Input.GetKey("left ctrl");

        //walk animation bool
        if (!is_SpearWalk && SpearWalk)
        {
            animator.SetBool(is_SpearWalkHash, true);
        }
        if (is_SpearWalk && !SpearWalk)
        {
            animator.SetBool(is_SpearWalkHash, false);
        }

        //walkbck animation bool
        if (!is_SpearWalkBck && SpearWalkBck)
        {
            animator.SetBool(is_SpearWalkBckHash, true);
        }
        if (is_SpearWalkBck && !SpearWalkBck)
        {
            animator.SetBool(is_SpearWalkBckHash, false);
        }

        //run animation bool
        if (!is_SpearRun && (is_SpearWalk && SpearRun))
        {
            animator.SetBool(is_SpearRunHash, true);
        }
        if (is_SpearRun && (!is_SpearWalk || !SpearRun))
        {
            animator.SetBool(is_SpearRunHash, false);
        }

        //diveFwd
        if (!is_SpearDvFwd && (is_SpearWalk && Spear_DvFwd))
        {
            animator.SetBool(is_SpearDvFwdHash, true);
        }
        if (is_SpearDvFwd && (!is_SpearWalk || !Spear_DvFwd))
        {
            animator.SetBool(is_SpearDvFwdHash, false);
        }

        //BckFlip
        if (!is_SpearBckFlip && (is_SpearWalkBck && Spear_BckFlip))
        {
            animator.SetBool(is_SpearBckFlipHash, true);
        }
        if (is_SpearBckFlip && (!is_SpearWalkBck || !Spear_BckFlip))
        {
            animator.SetBool(is_SpearBckFlipHash, false);
        }
    }
}
