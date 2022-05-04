using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe_AniCon : MonoBehaviour
{
    //variables
    Animator animator;
    int is_AxeWalkHash;
    int is_AxeWlkBackHash;
    int is_AxeRunHash;
    int is_AxeBlockHash;
    int is_AxeDvFwdHash;
    int is_AxeBckFlipHash;

    //monkey
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("Axe_Idle");
        //hash for smoother animation and cleaner code
        animator = GetComponent<Animator>();
        is_AxeWalkHash = Animator.StringToHash("is_AxeWalk");
        is_AxeWlkBackHash = Animator.StringToHash("is_AxeWlkBack");
        is_AxeRunHash = Animator.StringToHash("is_AxeRun");
        is_AxeBlockHash = Animator.StringToHash("is_AxeBlock");
        is_AxeDvFwdHash = Animator.StringToHash("is_AxeDvFwd");
        is_AxeBckFlipHash = Animator.StringToHash("is_AxeBckFlip");
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------------------------------------------------------
        if (Input.GetButtonDown("Fire1"))
        {
            character.GetComponent<Animator>().Play("Axe_Attack");
        }
        //press 1 to roll
        /*    if (Input.GetButtonDown("DiveKey"))
            {
                character.GetComponent<Animator>().Play("Axe_DvFwd");
            }*/
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

        bool is_AxeWalk = animator.GetBool(is_AxeWalkHash);
        bool AxeWalk = Input.GetKey("d");
        bool is_AxeWlkBack = animator.GetBool(is_AxeWlkBackHash);
        bool AxeWalkbck = Input.GetKey("a");
        bool is_AxeRun = animator.GetBool(is_AxeRunHash);
        bool AxeRun = Input.GetKey("left shift");
        bool is_AxeBlock = animator.GetBool(is_AxeBlockHash);
        bool AxeBlock = Input.GetKey(KeyCode.Mouse1);
        bool is_AxeDvFwd = animator.GetBool(is_AxeDvFwdHash);
        bool Axe_DvFwd = Input.GetKey("left ctrl");
        bool is_AxeBckFlip = animator.GetBool(is_AxeBckFlipHash);
        bool Axe_BckFlip = Input.GetKey("left ctrl");

        //walk animation bool
        if (!is_AxeWalk && AxeWalk)
        {
            animator.SetBool(is_AxeWalkHash, true);
        }
        if (is_AxeWalk && !AxeWalk)
        {
            animator.SetBool(is_AxeWalkHash, false);
        }

        //walkbck animation bool
        if (!is_AxeWlkBack && AxeWalkbck)
        {
            animator.SetBool(is_AxeWlkBackHash, true);
        }
        if (is_AxeWlkBack && !AxeWalkbck)
        {
            animator.SetBool(is_AxeWlkBackHash, false);
        }

        //run animation bool
        if (!is_AxeRun && (is_AxeWalk && AxeRun))
        {
            animator.SetBool(is_AxeRunHash, true);
        }
        if (is_AxeRun && (!is_AxeWalk || !AxeRun))
        {
            animator.SetBool(is_AxeRunHash, false);
        }

        //block animation bool
        if (!is_AxeBlock && AxeBlock)
        {
            animator.SetBool(is_AxeBlockHash, true);
        }
        if (is_AxeBlock && !AxeBlock)
        {
            animator.SetBool(is_AxeBlockHash, false);
        }

        //diveFwd
        if (!is_AxeDvFwd && (is_AxeWalk && Axe_DvFwd))
        {
            animator.SetBool(is_AxeDvFwdHash, true);
        }
        if (is_AxeDvFwd && (!is_AxeWalk || !Axe_DvFwd))
        {
            animator.SetBool(is_AxeDvFwdHash, false);
        }

        //BckFlip
        if (!is_AxeBckFlip && (is_AxeWlkBack && Axe_BckFlip))
        {
            animator.SetBool(is_AxeBckFlipHash, true);
        }
        if (is_AxeBckFlip && (!is_AxeWlkBack || !Axe_BckFlip))
        {
            animator.SetBool(is_AxeBckFlipHash, false);
        }
    }
}
