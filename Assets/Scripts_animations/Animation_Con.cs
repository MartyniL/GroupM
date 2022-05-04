using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Con : MonoBehaviour
{
    //Animations with binds for normal walking (NO WEAPONS)

    //variables
    Animator animator;
    int isWalkHash;
    int isWalkbackHash;
    int isWalkleftHash;
    int isWalkrightHash;
    

    //monkey
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        //hash for smoother animation and cleaner code
        animator = GetComponent<Animator>();
        isWalkHash = Animator.StringToHash("isWalk");
        isWalkbackHash = Animator.StringToHash("isWalkback");
        isWalkleftHash = Animator.StringToHash("isWalkleft");
        isWalkrightHash = Animator.StringToHash("isWalkright");

    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------------------------------------------------------------------
        
        //------------------------------------------------------------------------------------------

        //call bool
        bool isWalk = animator.GetBool(isWalkHash);
        bool walkPressed = Input.GetKey("a");
        bool isWalkback = animator.GetBool(isWalkbackHash);
        bool walkbackPressed = Input.GetKey("d");
        bool isWalkleft = animator.GetBool(isWalkleftHash);
        bool walkleftpressed = Input.GetKey("a");
        bool isWalkright = animator.GetBool(isWalkrightHash);
        bool walkrightpressed = Input.GetKey("d");

        //walk animation bool
        if (!isWalk && walkPressed)
        {
            animator.SetBool(isWalkHash, true);
        }
        if (isWalk && !walkPressed)
        {
            animator.SetBool(isWalkHash, false);
        }

        //walk backward animation bool
        if (!isWalkback && walkbackPressed)
        {
            animator.SetBool(isWalkbackHash, true);
        }
        if (isWalkback && !walkbackPressed)
        {
            animator.SetBool(isWalkbackHash, false);
        }

        //walk fwd left
        if (!isWalkleft && (isWalk && walkleftpressed))
        {
            animator.SetBool(isWalkleftHash, true);
        }
        if (isWalkleft && (!isWalk || !walkleftpressed))
        {
            animator.SetBool(isWalkleftHash, false);
        }
        //walk bck left
        if (!isWalkleft && (isWalkback && walkleftpressed))
        {
            animator.SetBool(isWalkleftHash, true);
        }
        if (isWalkleft && (!isWalkback || !walkleftpressed))
        {
            animator.SetBool(isWalkleftHash, false);
        }

        //walk fwd right
        if (!isWalkright && (isWalk && walkrightpressed))
        {
            animator.SetBool(isWalkrightHash, true);
        }
        if (isWalkright && (!isWalk || !walkrightpressed))
        {
            animator.SetBool(isWalkrightHash, false);
        }
        //walk bck right
        if (!isWalkright && (isWalkback && walkrightpressed))
        {
            animator.SetBool(isWalkrightHash, true);
        }
        if (isWalkright && (!isWalkback || !walkrightpressed))
        {
            animator.SetBool(isWalkrightHash, false);
        }
    }
}
