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

    //Function to trigger the tree breaking animation
    public void beginCutting()
    {
        anim.SetTrigger("treebreak");
    }
    
}
