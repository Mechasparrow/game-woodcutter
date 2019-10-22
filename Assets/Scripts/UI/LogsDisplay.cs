﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI Behavior for displaying the player's logs
public class LogsDisplay : MonoBehaviour
{
    
    //Text component
    private Text displayText;

    //Template string to prefix the logs count
    private string templateString;

    // Start is called before the first frame update
    private void Start()
    {
        //Initialize the template stinrg to some default
        templateString = "Logs: ";

        // Pull the Text UI component
        displayText = GetComponent<Text>();

    }

    //UI function to update the UI Text display to show the log count
    public void updateLogsCount(int count, int maxCount)
    {
        //set the UI Text to proper message
        displayText.text = templateString + count.ToString() + "/" + maxCount.ToString();
    }
    
}
