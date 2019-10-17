using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : StateMachineBehaviour
{

    public GameObject logs;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject go = animator.gameObject;
        GameObject treetop = go.transform.GetChild(1).gameObject;
        GameObject breakAway = go.transform.GetChild(2).gameObject;


        //Spawn logs
        int log_count = 0;
        log_count = (int)Mathf.Ceil(Random.Range(0, 3));

        Debug.Log("Log count: " + log_count.ToString());

        for (int i = 0; i < log_count; i++)
        {
            GameObject log = Instantiate(logs);
            log.transform.position = breakAway.transform.position;
        }

        //Destroy Tree parts
        Destroy(breakAway);
        Destroy(treetop);

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
