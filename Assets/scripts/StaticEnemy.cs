using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : Enemy
{
    public BulletStaticEnemy prefabBullet;

    public Transform spawnBullet;

    RaycastHit2D[] myray;

    public Vector2 direction;

    public float distance;
    public float TimeCoroutine;
    private float timer;

    bool startShoot;


    public float speed;
    public float speedUp;

    protected override void Start()
    {
        base.Start();
    }

    private void Awake()
    {
        //StartCoroutine(ShootCorutine());

        
    }

    void Update()
    {
        timer += Time.deltaTime;
        DetectAmel(direction, distance);
    }

    void Shoot()
    {
        var prefab = Instantiate(prefabBullet);
        prefab.Speed(speed).SpeedUp(speedUp);
        prefab.dir = direction.x;
        prefab.dirUp = direction.y;
        prefab.transform.position = spawnBullet.position;
        if (direction.x == 1)
            prefab.RightDir = true;


    }

    void DetectAmel(Vector2 _dir,float _distance)
    {
        myray = Physics2D.RaycastAll(transform.position, _dir, _distance, Mymask);
        Debug.DrawRay(transform.position, _dir*distance, Color.magenta);
        foreach (var hit in myray)
        {
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<amel>())
                {
                   
                    if (timer >= TimeCoroutine)
                    {
                        Shoot();
                        timer = 0;

                    }

                   


                }


            }


        }
    }

    IEnumerator ShootCorutine()
    {
        while (startShoot)
        {
           
            yield return new WaitForSeconds(TimeCoroutine);
            startShoot = false;
        }
    }
}
