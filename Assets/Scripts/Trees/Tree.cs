using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Deals with general tree behavior
public class Tree : MonoBehaviour
{
    
    //Log to spawn
    public GameObject log;

    //Reference to the tree animator controller
    public Animator anim;

    //Durability of the tree
    public int durability;

    //boolean function that checks if the player is currently breaking the tree
    public bool checkBreaking()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("breaking");
    }

    //Function to trigger the tree breaking animation
    public void beginCutting()
    {
        //if the durability is greater than 0,
        if (durability > 0)
        {
            //then switch to tree breaking animation
            anim.SetTrigger("treebreak");

            //decrease the durability by one
            durability--;
        }
        //if not (durability is <= 0)
        else
        {
            //Trigger the trees falling animation
            anim.SetTrigger("treefall");
        }
    }
    
}
