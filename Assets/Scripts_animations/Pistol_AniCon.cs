using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_AniCon : MonoBehaviour
{
    //variables
    Animator animator;
    int is_PistolWalkHash;
    int is_PistolWalkBckHash;
    int is_PistolRunHash;
    int is_PistolDvFwdHash;
    int is_PistolBckFlipHash;

    //monkey
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("Pistol Idle");
        //hash for smoother animation and cleaner code
        animator = GetComponent<Animator>();
        is_PistolWalkHash = Animator.StringToHash("is_PistolWalk");
        is_PistolWalkBckHash = Animator.StringToHash("is_PistolWalkBck");
        is_PistolRunHash = Animator.StringToHash("is_PistolRun");
        is_PistolDvFwdHash = Animator.StringToHash("is_PistolDvFwd");
        is_PistolBckFlipHash = Animator.StringToHash("is_PistolBckFlip");
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------------------------------------------------------
        //press 2
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
            character.GetComponent<Animator>().Play("Pistol Jump");
        }
        //----------------------------------------------------------------------------------------

        bool is_PistolWalk = animator.GetBool(is_PistolWalkHash);
        bool PistolWalk = Input.GetKey("d");
        bool is_PistolWalkBck = animator.GetBool(is_PistolWalkBckHash);
        bool PistolWalkBck = Input.GetKey("a");
        bool is_PistolRun = animator.GetBool(is_PistolRunHash);
        bool PistolRun = Input.GetKey("left shift");
        bool is_PistolDvFwd = animator.GetBool(is_PistolDvFwdHash);
        bool Pistol_DvFwd = Input.GetKey("left ctrl");
        bool is_PistolBckFlip = animator.GetBool(is_PistolBckFlipHash);
        bool Pistol_BckFlip = Input.GetKey("left ctrl");

        //walk animation bool
        if (!is_PistolWalk && PistolWalk)
        {
            animator.SetBool(is_PistolWalkHash, true);
        }
        if (is_PistolWalk && !PistolWalk)
        {
            animator.SetBool(is_PistolWalkHash, false);
        }

        //walkbck animation bool
        if (!is_PistolWalkBck && PistolWalkBck)
        {
            animator.SetBool(is_PistolWalkBckHash, true);
        }
        if (is_PistolWalkBck && !PistolWalkBck)
        {
            animator.SetBool(is_PistolWalkBckHash, false);
        }

        //run animation bool
        if (!is_PistolRun && (is_PistolWalk && PistolRun))
        {
            animator.SetBool(is_PistolRunHash, true);
        }
        if (is_PistolRun && (!is_PistolWalk || !PistolRun))
        {
            animator.SetBool(is_PistolRunHash, false);
        }

        //diveFwd
        if (!is_PistolDvFwd && (is_PistolWalk && Pistol_DvFwd))
        {
            animator.SetBool(is_PistolDvFwdHash, true);
        }
        if (is_PistolDvFwd && (!is_PistolWalk || !Pistol_DvFwd))
        {
            animator.SetBool(is_PistolDvFwdHash, false);
        }

        //BckFlip
        if (!is_PistolBckFlip && (is_PistolWalkBck && Pistol_BckFlip))
        {
            animator.SetBool(is_PistolBckFlipHash, true);
        }
        if (is_PistolBckFlip && (!is_PistolWalkBck || !Pistol_BckFlip))
        {
            animator.SetBool(is_PistolBckFlipHash, false);
        }
    }
}
