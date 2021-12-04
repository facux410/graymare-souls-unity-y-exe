using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStaticEnemy : MonoBehaviour
{
    Rigidbody2D rb;

    public bool RightDir;

    public float dir;
    public float dirUp;

    public float speed;
    public float speedUp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public BulletStaticEnemy Speed(float _speed)
    {
        speed = _speed;
        return this;
    }

    public BulletStaticEnemy SpeedUp(float _speed)
    {
        speedUp = _speed;
        return this;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (RightDir)
            rb.velocity = transform.right * Time.fixedDeltaTime * speed * dir;
        else
            transform.position += new Vector3(0, 1, 0) * speedUp*dirUp * Time.deltaTime;
          //  rb.velocity = transform.up * Time.deltaTime * 50 * dirUp;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<amel>())
        {
            Destroy(gameObject);
        }
    }
}
