using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    int index;
    int _allOptions = 4;



    public Image[] ElementsMenu;

   
    

    private void Awake()
    {
        Scene current_scene = SceneManager.GetActiveScene();
        index = current_scene.buildIndex;

        Cursor.visible = false;
        
    }

    private void Update()
    {
       

        
    }

   
    public void Pause(bool Ispause)
    {
        

        for (int i = 0; i < ElementsMenu.Length; i++)
        {
        
            ElementsMenu[i].gameObject.SetActive(Ispause);
            
        }
    }
   

   public void Resume()
   { Pause(false); }

    public void LoadLevelOne()
    { SceneManager.LoadScene("this"); }

    public void LoadMenu()
    { SceneManager.LoadScene("Menu"); }
   
    public void Exit()
    {Application.Quit();}

    public void Back()
    { SceneManager.LoadScene(--index);}
  
    public void LoadOptions()
    {}

    public void LoadCredits()
    { SceneManager.LoadScene("Credits"); }

    public void RestartLevel()
    { SceneManager.LoadScene(index); }
   
}
