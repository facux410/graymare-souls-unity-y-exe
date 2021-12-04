using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateManager : MonoBehaviour
{

    public Image Gradiant;

    Menu Mymenu;

    static UpdateManager _instance;
    public static UpdateManager Instance
    {
        get { return _instance; }
        private set { }
    }

    List<IUpdate> allUpdateElements = new List<IUpdate>();
    List<IUpdate> Restart_game = new List<IUpdate>();

    private void Awake()
    {
        _instance = this;
        Mymenu = FindObjectOfType<Menu>();
        
    }

    void Update()
    {
        

        if (allUpdateElements.Count >= 0)
        {
            for (int i = 0; i < allUpdateElements.Count; i++)
            {
                allUpdateElements[i].OnUpdate();
               // Debug.Log(allUpdateElements[i]);
               
            }
        }
      //  PauseGame();
       
    }

    
   public void PauseGame()
   {
        
        Debug.Log(allUpdateElements[0]);
        int number = allUpdateElements.Count;
       
        for (int i = 0; i < allUpdateElements.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (allUpdateElements.Count >= 0)
                {
                    // Restart_game.Add(allUpdateElements[i]);
                    Restart_game.AddRange(allUpdateElements);
                    // allUpdateElements.RemoveRange(0, number);
                 
                    allUpdateElements.RemoveAt(i);
                    Debug.Log("entrar");
                    Mymenu.Pause(true);
                   
                   
                }
                   
            }

        }
        if (Input.GetKeyDown(KeyCode.Y) && Restart_game.Count > 0 )
        {
            allUpdateElements.AddRange(Restart_game);
            Restart_game.RemoveRange(0, Restart_game.Count);
            Debug.Log("salir");
            Mymenu.Pause(false);
        }


   }


    public void AddElementUpdate(IUpdate element)
    {
        if (!allUpdateElements.Contains(element))
            allUpdateElements.Add(element);
    }

    public void RemoveElementUpdate(IUpdate element)
    {
        if (allUpdateElements.Contains(element))
            allUpdateElements.Remove(element);

      
    }
}
