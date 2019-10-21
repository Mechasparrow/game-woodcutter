using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftLogCabinButton : MonoBehaviour
{
    //Player related
    public PlayerBehavior pb; //reference to player behavior properties and functions

    //Building related variables
    public GameObject building; //building to spawn in
    public Transform buildingLocation; // spawn location for building
    public int log_cost; // cost required to spawn in the building

    //Button to trigger the crafting
    private Button craftButton;

    // Start is called before the first frame update
    void Start()
    {
        craftButton = GetComponent<Button>(); //Get button access
        craftButton.onClick.AddListener(craft); // Add event listener to execute craft() function on click
    }

    //See if the player has the sufficient logs to craft the building
    private bool checkLogCost() 
    {
        return ((pb.logs - log_cost) >= 0);
    }

    //Performs the crafting operation
    void craft()
    {
        //Check if the player has enough logs, if not
        // Abort the craft
        if (!checkLogCost())
        {
            //insufficient logs
            return;
        }

        //Take the logs from the player
        pb.logs -= log_cost;

        //update the UI display for the log count
        pb.updateUILogs();

        //Spawn the building
        GameObject b = Instantiate(building); // Brings it into existence
        b.transform.position = buildingLocation.position; // Teleports it to proper spawn location

    }
    
}
