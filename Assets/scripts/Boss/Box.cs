using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    SpriteRenderer sr;

    public float timeChange;
    public float velChange;
    public float maxtime;

    public bool start;
    public bool SpawnAttack;

    public PrefabAttackArea attack;

    void Start()
    {
        
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        BoxChangeColor();
        if (sr.color == Color.black)
            Attack();
    }

    void Attack()
    {
        var prefabAttack = Instantiate(attack);
        prefabAttack.transform.position = transform.position;
        Destroy(gameObject);
       

    }

    void BoxChangeColor()
    {
        if (start)
        {
            timeChange += Time.deltaTime * velChange;
            Debug.Log("Start");
            if (timeChange < 5f)
            {
                sr.color = Color.white;

            }
            else
            {
                timeChange += Time.deltaTime * velChange;
                if ((int)timeChange % 2 != 0)
                    sr.color = Color.black;
                else
                {
                    sr.color = Color.white;

                }

                if (timeChange > 10f)
                {
                    velChange = 4;
                }

                if (timeChange > maxtime)
                {
                    sr.color = Color.black;
                  //  timeChange = 0;

                }
            }
        }
        
    }
}
