using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public Animator anim;

    public int durability;

    public void beginCutting()
    {
        anim.SetTrigger("treebreak");
    }
    
}
