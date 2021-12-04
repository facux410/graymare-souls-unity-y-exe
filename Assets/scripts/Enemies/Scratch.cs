using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch : MonoBehaviour,IUpdate
{
    Animator S_Anim;

    public BoxCollider2D Coll;
    public bool truestart;

    void Start()
    {
        S_Anim = GetComponent<Animator>();
        Coll = GetComponent<BoxCollider2D>();
        truestart = true;
    }

    private void Awake()
    {
        UpdateManager.Instance.AddElementUpdate(this);
    }

    public void OnUpdate()
    {
        if (truestart == true)
        {
            if (S_Anim.GetCurrentAnimatorStateInfo(0).IsName("Done"))
            {
                Destruct();
            }
        }
    }

    public void Destruct()
    {
        UpdateManager.Instance.RemoveElementUpdate(this);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LifeAmel>() && truestart == true)
        {
            Coll.enabled = false;
            
        }
    }
}
