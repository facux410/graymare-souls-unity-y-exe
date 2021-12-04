using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    int damage = 25;
    float time = 4;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Move(float dir,float dirup)
    {
        rb.AddForce(new Vector2(300*dir, 300*dirup));
        if (dir == -1)
        {
            Rotate(-90);
        }
        if (dirup == 1)
            Rotate(180);
        if (dir == 1)
            Rotate(90);
        if (dirup == -1)
            Rotate(360);

            
    }


    void Rotate(float value)
    {
        Vector3 myRotation = transform.rotation.eulerAngles;
        myRotation = new Vector3(0, 0, value);
        transform.rotation = Quaternion.Euler(myRotation);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LifeEnemy>())
        {
            var enemy = collision.gameObject.GetComponent<LifeEnemy>();
            var a = collision.gameObject.GetComponent<chanchiten>();
            if (a)
            {
               
                a.explosion = true;
                a.count = 4;
               // damage = 200;
            }
            else
                enemy.TakeDamage(damage);

            Destroy(gameObject);

           

          
        }
    }

}
