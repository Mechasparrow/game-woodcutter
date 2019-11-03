using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTree : MonoBehaviour
{
    public GameObject trunk;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void scaleTrunk(float scale)
    {
        Vector3 trunkScale = trunk.transform.localScale;
        trunkScale.y *= scale;

        trunk.transform.localScale = trunkScale;
    }
    

}
