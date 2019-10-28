using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTree : MonoBehaviour
{
    public GameObject trunk;

    public GameObject leafPrefab;

    public Transform leafPos;

    // Start is called before the first frame update
    void Start()
    {
        scaleTrunk(0.5f);
        spawnLeaf(leafPos);
    }

    // Update is called once per frame
    void Update()
    {

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
        newLeaf.transform.SetParent(transform);

        newLeaf.transform.localScale = new Vector3(4, 4, 4);
        newLeaf.transform.position = transform.position;
    }

}
