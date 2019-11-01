using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Behavior associated with player
public class PlayerBehavior : MonoBehaviour
{
    //Animator for player actions
    public Animator anim;

    //Player logs attributes
    public int logs; // how many is being held
    public int logsMax; // max amount that can be held at a given time

    //Player fruits attributes
    public int fruits;
    public int fruitsMax;

    private ResourceDisplay logDisplay; // UI reference to log display behavior
    private  ResourceDisplay fruitDisplay; // UI reference to fruit display behavior

    // Makes sure that the player does not "pick up" logs that do not exist
    private bool canObtainLog; // Can the player pickup a log
    private float logTimer = 0.0f; //Timer to track time elapsed since last log obtained
    private float logTimeDuration = 1.0f; //Duration to wait before obtaining additional logs

    //Ditto as previous 3 variables with variation
    // Makes sure that the player does not accidently "cut" twice

    //TODO switch this over to a raycasting system

    private bool canExecuteCut; //Can the player execute the cutting action
    private float cutTimer = 0.0f; //Delay before player can cut again
    private float cutTimeDuration = 1.0f; // Time required before player can cut again

    // Start is called before the first frame update
    void Start()
    {
        //initiate (wooden) log system
        logs = 0;
        canObtainLog = true;

        //Retrieve the UI display behaviors
        logDisplay = GameObject.Find("LogsDisplay").GetComponent<ResourceDisplay>();
        fruitDisplay = GameObject.Find("FruitsDisplay").GetComponent<ResourceDisplay>();

        //update the logs display
        updateUILogs();
    }
    
    //updates the logDisplay component with logs and max amount of logs that can be carried
    public void updateUILogs()
    {
        logDisplay.updateCount(logs, logsMax);
        fruitDisplay.updateCount(fruits, fruitsMax);
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

            //If cutting with axe and allowed to cut
            if (cut && canExecuteCut)
            {
                //begin cutting down the tree and associated animations
                Tree t = tree.GetComponent<Tree>();

                //Check if the tree is not already being broken
                if (!t.checkBreaking())
                {
                    //If so
                    // Send a cut event to the selected tree.

                    //trigger beginCutting behavior in the tree
                    //Lower durablity
                    //Switches to breaking animation
                    // Refer to Tree.cs
                    t.beginCutting();

                    //Reset the cut timer, prevents player from cutting tree too fast.
                    resetCutTimer();


                    //Debug statement
                    //Debug.Log("break!");

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
            
        }else if (go.CompareTag("fruit") && canObtainLog)
        {
            // TL;DR pickup the fruit and add it to inventory

            //Destroy the Fruit
            GameObject Fruit = go;
            Destroy(Fruit);

            //increment the log count 
            if (fruits < fruitsMax)
            {
                fruits++;
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

    //Resets the cut timer when player cuts
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

    void rayCastShit()
    {
        Transform transform = Camera.main.transform;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
    }

    //Frame game loop function
    void Update()
    {
        //Call looped behaviors
        logTimerBehavior();
        cutTimerBehavior();
        axeControls();
        
        rayCastShit();
    }
}
