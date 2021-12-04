using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform finalpos;

    public float jumpForce;
    float t;


    bool stop;

    Vector2 pos;

    void Start()
    {
        pos = finalpos.position;
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }


    void Update()
    {
       

        if (!stop)
        {
            Vector2 startpos = transform.position;
            Vector2 endpos = pos;
            Vector2 height = Vector2.Lerp(startpos, endpos, 0.2f) + Vector2.up * jumpForce;
            Vector2 A = Vector2.Lerp(startpos, height, t);
            Vector2 B = Vector2.Lerp(height, endpos, t);
            transform.position = Vector2.Lerp(A, B, t);

            t += Time.deltaTime;
        }
      

        if (t >= 1)
        {
            stop = true;  
            t = 0;
        }

    }

 

}
