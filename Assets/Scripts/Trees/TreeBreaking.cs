using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deals with Tree breaking animation behavior
public class TreeBreaking : StateMachineBehaviour
{
    //Triggered at the beginning of the tree breaking state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Grab tree and tree behavior component
        GameObject tree = animator.gameObject;
        Tree treeScript = tree.GetComponent<Tree>();

        //If the tree has no durability left
        if (treeScript.durability <= 0)
        {
            //Make the tree fall
            animator.SetBool("treefall", true);
        }
        else
        {
            //If not, don't make the tree fall
            animator.SetBool("treefall", false);
        }
        
    }
    
    //Triggered at the end of the tree breaking state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Grab the tree object
        GameObject tree = animator.gameObject;

        //Grab associated tree behavior script
        Tree treeScript = tree.GetComponent<Tree>();

        //decrease durability of the tree by one
        treeScript.durability -= 1;

    }
    
}
