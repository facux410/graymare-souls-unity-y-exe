using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform platform;
    public GameObject Target;
    amel amel;
    SpriteRenderer sr;
    Animator anim;
    AudioSource source;
    public AudioClip clip;

    bool StopSound;
    bool InPlatform;

    public LayerMask mask;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        amel = FindObjectOfType<amel>();
        
        
    }

    void Update()
    {
        FeedbackChange();
        Overlap();
       
    }

    void FeedbackChange()
    {
        if (amel.Change == 1/* && !StopSound*/)
        {
            anim.SetBool("Stop", true);
            sr.color = Color.gray;
            //source.clip = clip;
            //if (!source.isPlaying)
            //{
            //    source.Play();
            //    StopSound = true;
            //}
               

        }
        else if(amel.Change == 0)
        {
            anim.SetBool("Stop", false);
            sr.color = Color.white;
            StopSound = false;
        }
           
    }




    void Overlap()
    {
        var physics = Physics2D.OverlapCircleAll(transform.position, 0.7f,mask);

        for (int i = 0; i < physics.Length; i++)
        {
            if (physics[i].gameObject.layer == 14)
            {
              //  InPlatform = true;
                var Pos = new Vector2(physics[i].transform.position.x, physics[i].transform.position.y + 1f);
                transform.position = Pos;
                break;
               
               
              
            }
            else if(physics[i].gameObject.layer == 16 && !InPlatform)
            {
                transform.position = amel.transform.position;
                Debug.Log("entro2");
             //   InPlatform = false;


            }
        }

        

    }     

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<amel>())
        {
            if (collision.gameObject.GetComponent<amel>().Change == 0)
                collision.transform.position = Target.transform.GetChild(1).transform.position;


        }
      
    }


   

}
