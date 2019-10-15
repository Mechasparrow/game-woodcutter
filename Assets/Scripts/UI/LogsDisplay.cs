using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogsDisplay : MonoBehaviour
{

    private Text displayText;
    private string templateString;

    // Start is called before the first frame update
    private void Start()
    {
        templateString = "Logs: ";
        displayText = GetComponent<Text>();

        updateLogsCount(0);
    }

    public void updateLogsCount(int count)
    {
        displayText.text = templateString + count.ToString();
    }
    
}
