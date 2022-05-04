using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_AniCon : MonoBehaviour
{
    //variables
    Animator animator;
    int is_BowWalkHash;
    int is_BowWalkbckHash;
    int is_BowRunHash;
    int is_BowDvFwdHash;
    int is_BowBckFlipHash;
    int is_Bow_AimWalkFwdHash;
    int is_Bow_AimWalkBckHash;
    int is_Bow_IdleAimHash;

    //monkey
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("Bow_Idle");
        //hash for smoother animation and cleaner code
        animator = GetComponent<Animator>();
        is_BowWalkHash = Animator.StringToHash("is_BowWalk");
        is_BowWalkbckHash = Animator.StringToHash("is_BowWalkBck");
        is_BowRunHash = Animator.StringToHash("is_BowRun");
        is_BowDvFwdHash = Animator.StringToHash("is_BowDvFwd");
        is_BowBckFlipHash = Animator.StringToHash("is_BowBckFlip");
        is_Bow_AimWalkFwdHash = Animator.StringToHash("is_Bow_AimWalkFwd");
        is_Bow_AimWalkBckHash = Animator.StringToHash("is_Bow_AimWalkBck");
        is_Bow_IdleAimHash = Animator.StringToHash("is_BowIdleAim");
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------------------------------------------------------
     /*   if (Input.GetButtonDown("Fire1"))
        {
            character.GetComponent<Animator>().Play("Sword_shield_Attack_1");
        }*/
        //press r-ctrl to roll
        /*   if (Input.GetButtonDown("DiveKey"))
           {
               character.GetComponent<Animator>().Play("Sword_Shield_DvFwd");
           }*/
        //press 2 to death animation
        if (Input.GetButtonDown("DeathKey"))
        {
            character.GetComponent<Animator>().Play("Death Animation");
        }
        /*    if (Input.GetButtonDown("3KeyBackFlip"))
            {
                character.GetComponent<Animator>().Play("Sword_Shield_BckFlp");
            }*/
        if (Input.GetButtonDown("Jump2"))
        {
            character.GetComponent<Animator>().Play("Bow_Jump");
        }
        //----------------------------------------------------------------------------------------

        bool is_BowWalk = animator.GetBool(is_BowWalkHash);
        bool Bow_Walk = Input.GetKey("d");
        bool is_BowWalkbck = animator.GetBool(is_BowWalkbckHash);
        bool Bow_WalkBck = Input.GetKey("a");
        bool is_BowRun = animator.GetBool(is_BowRunHash);
        bool Bow_Run = Input.GetKey("left shift");
        bool is_BowDvFwd = animator.GetBool(is_BowDvFwdHash);
        bool Bow_DvFwd = Input.GetKey("left ctrl");
        bool is_BowBckFlip = animator.GetBool(is_BowBckFlipHash);
        bool Bow_BckFlip = Input.GetKey("left ctrl");
        bool is_Bow_AimWalkFwd = animator.GetBool(is_Bow_AimWalkFwdHash);
        bool Bow_AimWalkFwd = Input.GetKey(KeyCode.Mouse0);
        bool is_Bow_AimWalkBck = animator.GetBool(is_Bow_AimWalkBckHash);
        bool Bow_AimWalkBck = Input.GetKey(KeyCode.Mouse0);
        bool is_Bow_AimIdle = animator.GetBool(is_Bow_IdleAimHash);
        bool Bow_AimIdle = Input.GetKey(KeyCode.Mouse0);

        //walk animation bool
        if (!is_BowWalk && Bow_Walk)
        {
            animator.SetBool(is_BowWalkHash, true);
        }
        if (is_BowWalk && !Bow_Walk)
        {
            animator.SetBool(is_BowWalkHash, false);
        }

        //walkbck animation bool
        if (!is_BowWalkbck && Bow_WalkBck)
        {
            animator.SetBool(is_BowWalkbckHash, true);
        }
        if (is_BowWalkbck && !Bow_WalkBck)
        {
            animator.SetBool(is_BowWalkbckHash, false);
        }

        //run animation bool
        if (!is_BowRun && (is_BowWalk && Bow_Run))
        {
            animator.SetBool(is_BowRunHash, true);
        }
        if (is_BowRun && (!is_BowWalk || !Bow_Run))
        {
            animator.SetBool(is_BowRunHash, false);
        }

        //diveFwd
        if (!is_BowDvFwd && (is_BowWalk && Bow_DvFwd))
        {
            animator.SetBool(is_BowDvFwdHash, true);
        }
        if (is_BowDvFwd && (!is_BowWalk || !Bow_DvFwd))
        {
            animator.SetBool(is_BowDvFwdHash, false);
        }

        //BckFlip
        if (!is_BowBckFlip && (is_BowWalkbck && Bow_BckFlip))
        {
            animator.SetBool(is_BowBckFlipHash, true);
        }
        if (is_BowBckFlip && (!is_BowWalkbck || !Bow_BckFlip))
        {
            animator.SetBool(is_BowBckFlipHash, false);
        }

        //Aim_Fwd
        if (!is_Bow_AimWalkFwd && (is_BowWalk && Bow_AimWalkFwd))
        {
            animator.SetBool(is_Bow_AimWalkFwdHash, true);
        }
        if (is_Bow_AimWalkFwd && (!is_BowWalk || !Bow_AimWalkFwd))
        {
            animator.SetBool(is_Bow_AimWalkFwdHash, false);
        }

        //Aim_Bck
        if (!is_Bow_AimWalkBck && (is_BowWalkbck && Bow_AimWalkBck))
        {
            animator.SetBool(is_Bow_AimWalkBckHash, true);
        }
        if (is_Bow_AimWalkBck && (!is_BowWalkbck || !Bow_AimWalkBck))
        {
            animator.SetBool(is_Bow_AimWalkBckHash, false);
        }

        //Aim_Idle
        if (!is_Bow_AimIdle && Bow_AimIdle)
        {
            animator.SetBool(is_Bow_IdleAimHash, true);
        }
        if (is_Bow_AimIdle && !Bow_AimIdle)
        {
            animator.SetBool(is_Bow_IdleAimHash, false);
        }
    }
}
