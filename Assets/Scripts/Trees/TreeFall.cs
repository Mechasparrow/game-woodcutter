using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deals with Tree Fall Animation behavior
public class TreeFall : StateMachineBehaviour
{

    //Logs Prefab to spawn on tree fall
    public GameObject logs;
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Gameobject tied to animator (Tree)
        GameObject go = animator.gameObject;

        //Top of tree
        GameObject treetop = go.transform.GetChild(1).gameObject;

        //Breakaway animation object
        GameObject breakAway = go.transform.GetChild(2).gameObject;
        
        //Generate random number for logs to spawn
        int log_count = (int)Mathf.Ceil(Random.Range(0, 3));

        //Debug statement to see log count
        //Debug.Log("Log count: " + log_count.ToString());

        //Spawn the appropiate amount of tree logs
        for (int i = 0; i < log_count; i++)
        {
            //Spawn the log
            GameObject log = Instantiate(logs);

            //Teleport log to appropiate position
            log.transform.position = breakAway.transform.position;
        }

        //Destroy Tree parts
        //Leaves stump remaining
        Destroy(breakAway);
        Destroy(treetop);

    }
    
}
