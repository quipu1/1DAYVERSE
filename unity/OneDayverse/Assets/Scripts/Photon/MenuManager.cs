using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{   
    public static MenuManager Instance;

    void Awake()
    {
        Instance = this;
    }
    
    [SerializeField] Menu[] menus;
    public void OpenMenu(string menuName)
    {
        for(int i = 0; i < menus.Length; i++)
        {   
           if(menus[i].menuName == menuName)
           {   
               menus[i].Open();
           }
           else if (menus[i].open)
           {
               CloseMenu(menus[i]);
           }

        }  
    }
    public void OpenMenu(Menu menu)
    {
        for(int i = 0; i < menus.Length; i++)
        {
           if (menus[i].open)
           {    
               CloseMenu(menus[i]);
           }

        }  
        Debug.Log(menu);
        menu.Open();
    }
    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }

}
