using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    
    public GameObject leafPrefab;

    public Transform leafPosition;

    private void Start()
    {
        spawnLeaf(leafPosition, 1, 4);   
    }

    private void spawnLeaf(Transform transform, float minSize, float maxSize)
    {
        float leafoSize = Random.Range(minSize, maxSize);

        GameObject newLeaf = Instantiate(leafPrefab);

        newLeaf.transform.SetParent(transform);
        newLeaf.transform.localScale = Vector3.one * leafoSize;

        newLeaf.transform.position = transform.position;
    }
}
