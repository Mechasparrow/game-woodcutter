using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public Animator anim;

    public int logs;
    public int logsMax;

    public LogsDisplay logDisplay;

    private bool canObtainLog;
    private float logTimer = 0.0f;
    private float logTimeDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        logs = 0;
        canObtainLog = true;

        updateUILogs();
    }
    
    public void updateUILogs()
    {
        logDisplay.updateLogsCount(logs, logsMax);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Col");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        string tag = hit.collider.gameObject.tag;
        GameObject go = hit.collider.gameObject;
        if (go.CompareTag("tree_barrier"))
        {
            GameObject tree = go.transform.parent.gameObject.transform.parent.gameObject;
            bool cut = anim.GetCurrentAnimatorStateInfo(0).IsName("Cut");
            if (cut)
            {
                Tree t = tree.GetComponent<Tree>();
                t.beginCutting();
            }
        }else if (go.CompareTag("log") && canObtainLog)
        {
            //Destroy the log
            GameObject Log = go;
            Destroy(Log);

            //increment the log count and update display
            if (logs < logsMax)
            {
                logs++;
            }

            updateUILogs();

            //reset log timer and stats
            resetLogTimer();
            
        }
    }

    void axeControls()
    {
        bool mousePress = Input.GetMouseButtonDown(0);
        if (mousePress)
        {
            anim.SetTrigger("Cut");
        }
    }

    void resetLogTimer()
    {
        canObtainLog = false;
        logTimer = 0.0f;
    }

    void logTimerBehavior()
    {
        if (logTimer > logTimeDuration)
        {
            canObtainLog = true;
        }else
        {
            logTimer += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {

        logTimerBehavior();
        axeControls();

    }
}
