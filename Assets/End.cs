using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class End : MonoBehaviour
{
    public bool Finale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Finale == true)
        {
            Invoke("ByeBye", 1.2f);
        }
    }

    void ByeBye()
    {
        SceneManager.LoadScene("Win");
    }
}
