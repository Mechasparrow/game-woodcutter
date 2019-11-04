using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    
    public GameObject leafPrefab;

    public Transform leafPosition;

    private void Start()
    {
        spawnLeaf(leafPosition);   
    }    
    
    private void spawnLeaf(Transform transform)
    {
        GameObject newLeaf = Instantiate(leafPrefab);

        newLeaf.transform.SetParent(transform);
        newLeaf.transform.position = transform.position;
    }
}
