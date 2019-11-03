using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public GameObject leafs;

    public GameObject leafPrefab;

    public Transform leafPosition;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    
    private void spawnLeaf(Transform transform)
    {
        GameObject newLeaf = Instantiate(leafPrefab);

        newLeaf.transform.SetParent(leafs.transform);
        newLeaf.transform.position = transform.position;
    }
}
