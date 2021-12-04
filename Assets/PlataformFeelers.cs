using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformFeelers : MonoBehaviour
{
    public Platform platform;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            platform.CollisionDetected();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            platform.CollisionDetected();
        }

        if (collision.gameObject.layer == 19)
        {
            platform.CollisionDetected();
            platform.Collision19();
        }
    }

}
