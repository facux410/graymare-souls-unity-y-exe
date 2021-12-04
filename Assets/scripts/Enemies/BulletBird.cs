using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBird : MonoBehaviour,IUpdate,IMove
{
    public amel target;
    public Enemy bird;

    Vector3 _dir;

    float LifeTime = 2;

    void Start()
    {
        
    }

    private void Awake()
    {
        UpdateManager.Instance.AddElementUpdate(this);
    }

    public void OnUpdate()
    {
        Move();
        Destroy();
        RotationObj();
    }

    public void Move()
    {
        if(bird != null)
            _dir = target.transform.position - bird.transform.position;
        else
        {
            UpdateManager.Instance.RemoveElementUpdate(this);
            Destroy(gameObject);
        }

        _dir.Normalize();
        transform.position += _dir * Time.deltaTime * 6f;

    }

    void RotationObj()
    {
        Vector3 mydir = target.transform.position - transform.position;
        mydir.Normalize();
        Vector3 myRotation = transform.rotation.eulerAngles;
        myRotation += new Vector3(0, 0, -mydir.x);
        transform.rotation = Quaternion.Euler(myRotation);
    }

    void Destroy()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime < 0)
        {
            LifeTime = 2;
            UpdateManager.Instance.RemoveElementUpdate(this);
            Destroy(gameObject);

        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LifeAmel>())
        {

            UpdateManager.Instance.RemoveElementUpdate(this);
            Destroy(gameObject);
        }
    }


}
