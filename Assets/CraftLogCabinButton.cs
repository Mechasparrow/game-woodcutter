using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftLogCabinButton : MonoBehaviour
{
    //Player related
    public PlayerBehavior pb;

    //Building related
    public GameObject building;
    public Transform buildingLocation;
    public int log_cost;

    private Button craftButton;

    // Start is called before the first frame update
    void Start()
    {
        craftButton = GetComponent<Button>();
        craftButton.onClick.AddListener(craft);
    }

    private bool checkLogCost()
    {
        return ((pb.logs - log_cost) >= 0);
    }

    void craft()
    {
        if (!checkLogCost())
        {
            //insufficient logs
            return;
        }

        //Take the logs
        pb.logs -= log_cost;
        pb.updateUILogs();

        //Spawn the building
        GameObject b = Instantiate(building);
        b.transform.position = buildingLocation.position;

    }
    
}
