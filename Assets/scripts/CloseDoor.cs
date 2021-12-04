using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseDoor : MonoBehaviour
{

    amel player;
    Animator anim;

    public int NumberOfKeys;
    public bool openThisDoor;

    public string text;

    public Text myText;

    private void Awake()
    {
        player = FindObjectOfType<amel>();
        anim = GetComponent<Animator>();
        myText.text = text;
        myText.gameObject.SetActive(false);
        
    }


    void Update()
    {
        OpenDoor();
    }

    void OpenDoor()
    {
        if (player.keys.Count == NumberOfKeys)
        {
            anim.SetTrigger("Open");
            openThisDoor = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<amel>())
        {
            myText.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<amel>())
        {
            myText.gameObject.SetActive(false);
        }
    }
}
