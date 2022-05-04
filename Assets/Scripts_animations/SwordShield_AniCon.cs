using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordShield_AniCon : MonoBehaviour
{
    //variables
    Animator animator;
    int is_swrd_shld_WalkHash;
    int is_SwrdShld_WalkbckHash;
    int is_SwordShld_RunHash;
    int is_SwordShld_BlockHash;
    int is_SwordDiveFwdHash;
    int is_Sword_BckFlipHash;

    //monkey
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("Sword_Shield_Idle");
        //hash for smoother animation and cleaner code
        animator = GetComponent<Animator>();
        is_swrd_shld_WalkHash = Animator.StringToHash("is_swrd_shld_Walk");
        is_SwrdShld_WalkbckHash = Animator.StringToHash("is_SwrdShld_Walkbck");
        is_SwordShld_RunHash = Animator.StringToHash("is_SwordShld_Run");
        is_SwordShld_BlockHash = Animator.StringToHash("is_SwordShld_Block");
        is_SwordDiveFwdHash = Animator.StringToHash("is_SwordDiveFwd");
        is_Sword_BckFlipHash = Animator.StringToHash("is_Sword_BckFlip");
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------------------------------------------------------
        if (Input.GetButtonDown("Fire1"))
        {
            character.GetComponent<Animator>().Play("Sword_shield_Attack_1");
        }
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
            character.GetComponent<Animator>().Play("Sword_Shield_Jump");
        }
        //----------------------------------------------------------------------------------------

        bool is_swrd_shld_Walk = animator.GetBool(is_swrd_shld_WalkHash);
        bool swrd_shldWalk = Input.GetKey("d");
        bool is_SwrdShld_Walkbck = animator.GetBool(is_SwrdShld_WalkbckHash);
        bool swrd_shldWalkbck = Input.GetKey("a");
        bool is_SwrdShld_Run = animator.GetBool(is_SwordShld_RunHash);
        bool swrd_shldRun = Input.GetKey("left shift");
        bool is_SwrdShld_Block = animator.GetBool(is_SwordShld_BlockHash);
        bool swrd_shldBlock = Input.GetKey(KeyCode.Mouse1);
        bool is_SwordDiveFwd = animator.GetBool(is_SwordDiveFwdHash);
        bool Sword_DiveFwd = Input.GetKey("left ctrl");
        bool is_Sword_BckFlip = animator.GetBool(is_Sword_BckFlipHash);
        bool Sword_BckFlip = Input.GetKey("left ctrl");

        //walk animation bool
        if (!is_swrd_shld_Walk && swrd_shldWalk)
        {
            animator.SetBool(is_swrd_shld_WalkHash, true);
        }
        if (is_swrd_shld_Walk && !swrd_shldWalk)
        {
            animator.SetBool(is_swrd_shld_WalkHash, false);
        }

        //walkbck animation bool
        if (!is_SwrdShld_Walkbck && swrd_shldWalkbck)
        {
            animator.SetBool(is_SwrdShld_WalkbckHash, true);
        }
        if (is_SwrdShld_Walkbck && !swrd_shldWalkbck)
        {
            animator.SetBool(is_SwrdShld_WalkbckHash, false);
        }

        //run animation bool
        if (!is_SwrdShld_Run && (is_swrd_shld_Walk && swrd_shldRun))
        {
            animator.SetBool(is_SwordShld_RunHash, true);
        }
        if (is_SwrdShld_Run && (!is_swrd_shld_Walk || !swrd_shldRun))
        {
            animator.SetBool(is_SwordShld_RunHash, false);
        }

        //block animation bool
        if (!is_SwrdShld_Block && swrd_shldBlock)
        {
            animator.SetBool(is_SwordShld_BlockHash, true);
        }
        if (is_SwrdShld_Block && !swrd_shldBlock)
        {
            animator.SetBool(is_SwordShld_BlockHash, false);
        }

        //diveFwd
        if (!is_SwordDiveFwd && (is_swrd_shld_Walk && Sword_DiveFwd))
        {
            animator.SetBool(is_SwordDiveFwdHash, true);
        }
        if (is_SwordDiveFwd && (!is_swrd_shld_Walk || !Sword_DiveFwd))
        {
            animator.SetBool(is_SwordDiveFwdHash, false);
        }

        //BckFlip
        if (!is_Sword_BckFlip && (is_SwrdShld_Walkbck && Sword_BckFlip))
        {
            animator.SetBool(is_Sword_BckFlipHash, true);
        }
        if (is_Sword_BckFlip && (!is_SwrdShld_Walkbck || !Sword_BckFlip))
        {
            animator.SetBool(is_Sword_BckFlipHash, false);
        }
    }
}
