using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class CraftingMenuHandler : MonoBehaviour
{
    public GameObject craftingMenu;
    public FirstPersonController fpc;
    
    //things the menu should check for to pull it up
    void menuCheck()
    {
        //get if menu key pressed
        bool menuKey = Input.GetKeyUp(KeyCode.E);

        //If pressed
        if (menuKey)
        {
            //Check if menu is currently activated
            bool menuActive = craftingMenu.activeInHierarchy;

            if (menuActive) //If so
            {
                //hide the menu
                hideMenu();
            }else
            {   
                //else pull up the menu
                pullUpMenu();
            }
            
        }

    }

    //hides the menu and locks the mouse
    private void hideMenu()
    {
        craftingMenu.SetActive(false);
        fpc.m_MouseLook.SetCursorLock(true);
    }

    //pulls up the menu and enables the mouse cursor
    private void pullUpMenu()
    {
        craftingMenu.SetActive(true);
        fpc.m_MouseLook.SetCursorLock(false);
    }
    
    //Check the menu behavior each frame
    void Update()
    {
        menuCheck();
    }
}
