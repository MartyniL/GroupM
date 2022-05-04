using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read_Me : MonoBehaviour
{
    //Animations transitioning into each other have NO EXIT TIME, these are the main animations which
    //will loop.
    //Will need something similar in Animation scrpt.

    //Animations with only one transition will need to be called
    /*if (Input.GetButtonDown("1Key"))
        {
            character.GetComponent<Animator>().Play("Standing Dive Forward");
        }
    */
    //Keep EXIT TIME ON so it transitions back into the main animations
    //These are one time animations, if the player presses a button to attack, roll, etc.
    //death animation will also need to be called the same way, but will need something to reset to a idle animation
    //will need to call the animations that are not connected to the orange idle animation, such as the sword_shield animations
}
