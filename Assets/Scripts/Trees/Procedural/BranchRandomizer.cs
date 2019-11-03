using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchRandomizer : MonoBehaviour
{
    private List<GameObject> branches;

    // Start is called before the first frame update
    void Start()
    {

        //grab child branches
        grabChildBranches();

        //pick random branch to display
        displayRandomBranch();
    }

    //Grab all the child branches
    void grabChildBranches()
    {
        branches = new List<GameObject>();

        foreach (Transform child in transform)
        {
            branches.Add(child.gameObject);
        }
    }

    void displayRandomBranch()
    {
        int branchCount = branches.Count;
        int chosenIndex = Mathf.FloorToInt(Random.Range(0, branchCount));

        for (int c = 0; c < branches.Count; c++)
        {
            if (c == chosenIndex)
            {
                branches[c].SetActive(true);
            }
            else
            {
                branches[c].SetActive(false);
            }
        }
    }
    
}
