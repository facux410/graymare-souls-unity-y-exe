using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public Box Box;

    Transform _boxPos;

    amel pl;
    SpriteRenderer sr;
    Animator anim;
    LifeEnemy life;

    public bool _startTime;
    public bool _attackAround;

    float _timeAttack;
    float distanceY;
    float timeAttack;

    ManagerScenes scenes;

    Vector3 startpos;

    LayerMask mask;

    public GameObject smoke;

    private void Awake()
    {
        scenes = FindObjectOfType<ManagerScenes>();
        sr = GetComponent<SpriteRenderer>();
        pl = FindObjectOfType<amel>();
        anim = GetComponent<Animator>();
        life = GetComponent<LifeEnemy>();
        StartCoroutine(_attackAreaStart());
        life.Life = 250;
        startpos = transform.position;
    }

    void Update()
    {
        Die();
        AttackAroundBook();
    }

    void Die()
    {
        if (life.Boss_die)
        {
            scenes.NextScene();
        }
    }

    void AttackAroundBook()
    {
        float distance = Vector3.Distance(transform.position, pl.transform.position);
       
        if (distance < 3)
        {
            timeAttack += Time.deltaTime;
            _attackAround = true;
        }
        if (_attackAround && timeAttack>5)
        {
            if (distanceY < 2)
            {
                transform.position += new Vector3(0, transform.position.y *0.5f*Time.deltaTime);
                distanceY += Time.deltaTime;
            }
            else if (distanceY > 2)
            {
                transform.position = startpos;
                var overlap = Physics2D.OverlapCircleAll(transform.position, 4, mask);
                var prefab = Instantiate(smoke);
                prefab.transform.position = transform.position;
                //for (int i = 0; i < overlap.Length; i++)
                //{
                //    if (overlap[i])
                //    {
                //        overlap[i].GetComponent<LifeAmel>().Damage = 30;
                //        overlap[i].GetComponent<LifeAmel>().DamageProcess();
                //    }
                //}
                timeAttack = 0;
                distanceY = 0;
                _attackAround = false;
            }
            else if (distanceY == 0)
            {
                Vector3 newpos = startpos - transform.position;
                newpos.Normalize();
                transform.position += newpos*Time.deltaTime;
            }
               

        }

    }

    void AreaStart()
    {
        anim.SetTrigger("Attack");
        var prefabBox = Instantiate(Box);
        prefabBox.transform.position = pl.transform.position;
        _boxPos = prefabBox.transform;
        prefabBox.start = true;
        _startTime = true;


    }



    IEnumerator _attackAreaStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(8);
            AreaStart();
        }

    }
}
