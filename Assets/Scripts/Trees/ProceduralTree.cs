using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTree : MonoBehaviour
{
    public GameObject trunk;
    public GameObject leafs;

    public GameObject leafPrefab;

    public Transform[] leafPositions;

    // Start is called before the first frame update
    void Start()
    {
        scaleTrunk(1.5f);

        foreach (Transform leafPos in leafPositions)
        {
            spawnLeaf(leafPos);
        }
    }
    
    void scaleTrunk(float scale)
    {
        Vector3 trunkScale = trunk.transform.localScale;
        trunkScale.y *= scale;

        trunk.transform.localScale = trunkScale;
    }

    void spawnLeaf(Transform transform)
    {
        GameObject newLeaf = Instantiate(leafPrefab);
        
        newLeaf.transform.SetParent(leafs.transform);
        newLeaf.transform.position = transform.position;
    }

}
