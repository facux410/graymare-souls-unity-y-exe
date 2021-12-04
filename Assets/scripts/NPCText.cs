using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCText : MonoBehaviour
{
    public float radius;

    public amel Player;

    public GameObject Greybox;
    public Text myText;

    public string textNPC;


    private void Start()
    {
        Player = FindObjectOfType<amel>();
    }

    void Update()
    {
        SpawnText();        
    }


    void SpawnText()
    {
        float dist = Vector3.Distance(Player.transform.position, transform.position);
        
        if(dist < 3)
        {
            if(dist < 2)
            {
                Greybox.gameObject.SetActive(true);
                myText.text = textNPC;
            }
            else
            {
                Greybox.gameObject.SetActive(false);
            }

        }

    }
}
