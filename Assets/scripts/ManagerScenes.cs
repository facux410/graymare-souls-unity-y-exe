using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{

    int index;


   


    private void Awake()
    {
        Scene current_scene = SceneManager.GetActiveScene();
        index = current_scene.buildIndex;
    }

    void Update()
    {
        Cheat();
    }

    private void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.P))
            SceneManager.LoadScene(++index);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(++index);

    }


}
