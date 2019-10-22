using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Deals with general tree behavior
public class Tree : MonoBehaviour
{
    

    //TODO have this take care of the tree breaking durability system

    //Reference to the tree animator controller
    public Animator anim;

    //Durability of the tree
    public int durability;

    public bool checkBreaking()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("breaking");
    }

    //Function to trigger the tree breaking animation
    public void beginCutting()
    {
        if (durability > 0)
        {
            anim.SetTrigger("treebreak");
            durability--;
        }else
        {
            anim.SetTrigger("treefall");
        }
    }
    
}
