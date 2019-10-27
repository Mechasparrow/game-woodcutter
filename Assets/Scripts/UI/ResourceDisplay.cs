using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI Behavior for displaying the player's resources
public class ResourceDisplay : MonoBehaviour
{
    
    //Text component
    private Text displayText;

    //Template string to prefix the logs count
    public string templateString;

    // Start is called before the first frame update
    private void Start()
    {
        // Pull the Text UI component
        this.displayText = GetComponent<Text>();

    }

    //UI function to update the UI Text display to show the log count
    public void updateCount(int count, int maxCount)
    {
        //set the UI Text to proper message
        displayText.text = templateString + count.ToString() + "/" + maxCount.ToString();
    }
    
}
