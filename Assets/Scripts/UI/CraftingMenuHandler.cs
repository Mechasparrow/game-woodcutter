using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class CraftingMenuHandler : MonoBehaviour
{
    public GameObject craftingMenu;
    public FirstPersonController fpc;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void menuCheck()
    {
        bool menuKey = Input.GetKeyUp(KeyCode.E);

        if (menuKey)
        {
            switch (craftingMenu.activeInHierarchy)
            {
                case true:
                    craftingMenu.SetActive(false);
                    fpc.m_MouseLook.SetCursorLock(true);
                    break;
                default:
                    craftingMenu.SetActive(true);
                    fpc.m_MouseLook.SetCursorLock(false);
                    break;
                    
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        menuCheck();
    }
}
