﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //Animator for player actions
    public Animator anim;

    //Player logs attributes
    public int logs; // how many is being held
    public int logsMax; // max amount that can be held at a given time

    public LogsDisplay logDisplay; // UI reference to log display game object

    // Makes sure that the player does not "pick up" logs that do not exist
    private bool canObtainLog; // Can the player pickup a log
    private float logTimer = 0.0f;
    private float logTimeDuration = 1.0f;

    private bool canExecuteCut;
    private float cutTimer = 0.0f;
    private float cutTimeDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //initiate (wooden) log system
        logs = 0;
        canObtainLog = true;

        //update the logs display
        updateUILogs();
    }
    
    //updates the logDisplay component with logs and max amount of logs that can be carried
    public void updateUILogs()
    {
        logDisplay.updateLogsCount(logs, logsMax);
    }

    //Checks if the player has collided with something while moving
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Get the gameobject tag of the hit object
        string tag = hit.collider.gameObject.tag;

        //filter down to essential collided gameobject
        GameObject go = hit.collider.gameObject;

        //Check if a tree was hit
        if (go.CompareTag("tree_barrier"))
        {
            //Rename it to a tree itself (hierachy traversal)
            GameObject tree = go.transform.parent.gameObject.transform.parent.gameObject;

            //Check if player in cutting animation
            bool cut = anim.GetCurrentAnimatorStateInfo(0).IsName("Cut");

            //If cutting with axe
            if (cut && canExecuteCut)
            {
                //begin cutting down the tree and associated animations
                Tree t = tree.GetComponent<Tree>();
                if (!t.checkBreaking())
                {
                    Debug.Log("break!");
                    t.beginCutting();
                    resetCutTimer();
                }
            }

        }

        //If the player collided with a log and can pick one up
        else if (go.CompareTag("log") && canObtainLog)
        {
            // TL;DR pickup the log and add it to inventory

            //Destroy the log
            GameObject Log = go;
            Destroy(Log);

            //increment the log count 
            if (logs < logsMax)
            {
                logs++;
            }

            //update the log display
            updateUILogs();

            //reset log timer and stats
            resetLogTimer();
            
        }
    }

    //Controls the axe
    void axeControls()
    {
        //check for mouse press
        bool mousePress = Input.GetMouseButtonDown(0);

        if (mousePress)
        {
            //Trigger axe cutting anim on mouse press
            anim.SetTrigger("Cut");
        }
    }

    //Resets the log timer when log is obtained
    void resetLogTimer()
    {
        canObtainLog = false;
        logTimer = 0.0f;
    }

    void resetCutTimer()
    {
        canExecuteCut = false;
        cutTimer = 0.0f;
    }

    //Behavior for the log timer
    void logTimerBehavior()
    {
        //log timer passed required time elapsed
        if (logTimer > logTimeDuration)
        {
            //player can now obtain log again
            canObtainLog = true;
        }else
        {
            //If not, keep incrementing the log timer
            logTimer += Time.deltaTime;
        }
    }
    
    //Behavior for the cut timer
    void cutTimerBehavior()
    {
        //cut timer passed required time elapsed
        if (cutTimer > cutTimeDuration)
        {
            //player can now cut again
            canExecuteCut = true;
        }
        else
        {
            //If not, keep incrementing the cut timer
            cutTimer += Time.deltaTime;
        }
    }

    //Frame game loop function
    void Update()
    {
        //Call looped behaviors
        logTimerBehavior();
        cutTimerBehavior();
        axeControls();

    }
}
