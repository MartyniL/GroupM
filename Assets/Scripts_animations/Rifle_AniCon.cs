using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle_AniCon : MonoBehaviour
{
    //variables
    Animator animator;
    int is_RifleWalkHash;
    int is_RifleWalkBckHash;
    int is_RifleRunHash;
    int is_RifleDvFwdHash;
    int is_RifleBckFlipHash;

    //monkey
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("Rifle Aiming Idle");
        //hash for smoother animation and cleaner code
        animator = GetComponent<Animator>();
        is_RifleWalkHash = Animator.StringToHash("is_RifleWalk");
        is_RifleWalkBckHash = Animator.StringToHash("is_RifleWalkBck");
        is_RifleRunHash = Animator.StringToHash("is_RifleRun");
        is_RifleDvFwdHash = Animator.StringToHash("is_RifleDvFwd");
        is_RifleBckFlipHash = Animator.StringToHash("is_RifleBckFlip");
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------------------------------------------------------
        //press 2 to death animation
        if (Input.GetButtonDown("DeathKey"))
        {
            character.GetComponent<Animator>().Play("Death Animation");
        }
        /*   if (Input.GetButtonDown("3KeyBackFlip"))
           {
               character.GetComponent<Animator>().Play("Axe_BckFlp");
           }*/
        if (Input.GetButtonDown("Jump"))
        {
            character.GetComponent<Animator>().Play("Rifle Jump");
        }
        //----------------------------------------------------------------------------------------

        bool is_RifleWalk = animator.GetBool(is_RifleWalkHash);
        bool RifleWalk = Input.GetKey("d");
        bool is_RifleWalkBck = animator.GetBool(is_RifleWalkBckHash);
        bool RifleWalkBck = Input.GetKey("a");
        bool is_RifleRun = animator.GetBool(is_RifleRunHash);
        bool RifleRun = Input.GetKey("left shift");
        bool is_RifleDvFwd = animator.GetBool(is_RifleDvFwdHash);
        bool Rifle_DvFwd = Input.GetKey("left ctrl");
        bool is_RifleBckFlip = animator.GetBool(is_RifleBckFlipHash);
        bool Rifle_BckFlip = Input.GetKey("left ctrl");

        //walk animation bool
        if (!is_RifleWalk && RifleWalk)
        {
            animator.SetBool(is_RifleWalkHash, true);
        }
        if (is_RifleWalk && !RifleWalk)
        {
            animator.SetBool(is_RifleWalkHash, false);
        }

        //walkbck animation bool
        if (!is_RifleWalkBck && RifleWalkBck)
        {
            animator.SetBool(is_RifleWalkBckHash, true);
        }
        if (is_RifleWalkBck && !RifleWalkBck)
        {
            animator.SetBool(is_RifleWalkBckHash, false);
        }

        //run animation bool
        if (!is_RifleRun && (is_RifleWalk && RifleRun))
        {
            animator.SetBool(is_RifleRunHash, true);
        }
        if (is_RifleRun && (!is_RifleWalk || !RifleRun))
        {
            animator.SetBool(is_RifleRunHash, false);
        }

        //diveFwd
        if (!is_RifleDvFwd && (is_RifleWalk && Rifle_DvFwd))
        {
            animator.SetBool(is_RifleDvFwdHash, true);
        }
        if (is_RifleDvFwd && (!is_RifleWalk || !Rifle_DvFwd))
        {
            animator.SetBool(is_RifleDvFwdHash, false);
        }

        //BckFlip
        if (!is_RifleBckFlip && (is_RifleWalkBck && Rifle_BckFlip))
        {
            animator.SetBool(is_RifleBckFlipHash, true);
        }
        if (is_RifleBckFlip && (!is_RifleWalkBck || !Rifle_BckFlip))
        {
            animator.SetBool(is_RifleBckFlipHash, false);
        }
    }
}
