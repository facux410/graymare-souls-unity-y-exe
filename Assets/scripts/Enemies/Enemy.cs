using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour,IMove,IAttack,IAttackRange
{

    Rigidbody2D rb;
    Animator Anim;
    SpriteRenderer sprite;

    public amel Target;

    public LayerMask Mymask;

    public RaycastHit2D[] ray;

    public float TimeAttackRangeBird;

    public float TimeAttackRangeRabbit;
    public bool RabbitMove = true;
    bool RabbitAttak;

    public BulletBird bulletBird;
    public Scratch scratch;

    public GameObject Firesnd;
    public GameObject Readysnd;
    public GameObject Scratchsnd;

    protected virtual void Start()
    {
        Target = FindObjectOfType<amel>();
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(10, 11, true);
    }


    public virtual void MoveRabbit()
    {

        float Myradius = 8f;
        Vector3 _dirToTarget = Target.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, Target.transform.position);

        var Overlap = Physics2D.OverlapCircle(transform.position, Myradius, Mymask);

        if (Overlap)
        {
            TimeAttackRangeRabbit = Mathf.Clamp(TimeAttackRangeRabbit + Time.deltaTime, 0f, 0.35f);

            if(RabbitMove == true)
            {
                if (distance < 7.5f && distance > 2.8f)
                {
                    rb.velocity = (_dirToTarget / distance) * Time.fixedDeltaTime * 230;
                    AngleAnim(_dirToTarget);
                }
                else if (distance <= 2.8f)
                {
                    RabbitMove = false;
                    rb.velocity = Vector3.zero;
                    AngleAnim(_dirToTarget);
                    Anim.SetFloat("Speed", 2);

                    GameObject snd = Instantiate(Readysnd);
                    Destroy(snd, 1f);

                    Invoke("Attack", 0.7f);
                }
                else
                {
                    Anim.Play("Stand");
                    rb.velocity = Vector3.zero;
                }
            }
            
        }

        if(RabbitAttak == true && TimeAttackRangeRabbit > 0.32f && distance <= 1.6f)
        {
            TimeAttackRangeRabbit = 0;

            GameObject snd = Instantiate(Scratchsnd);
            Destroy(snd, 1f);

            Scratch prefab = Instantiate(scratch);
            prefab.transform.position = Target.transform.position;
        }
    }

    public void PrepairAttack()
    {

    }

    public void Attack()
    {
        RabbitAttak = true;

        Vector3 _dirToTarget = Target.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, Target.transform.position);

        rb.AddForce((_dirToTarget / distance) * 380000 * Time.fixedDeltaTime, ForceMode2D.Impulse);
        AngleAnim(_dirToTarget);
        Anim.SetFloat("Speed", 1);

        Invoke("EndAttack", 1.2f);
    }

    public void EndAttack()
    {
        RabbitAttak = false;

        rb.velocity = Vector3.zero;
        Anim.Play("Stand");

        Invoke("ResumeMove", 1.9f);
    }

    public void ResumeMove()
    {
        RabbitMove = true;
    }

    public virtual void Move()  //Bird
    {
        sprite.color = new Color(1f, 1f - TimeAttackRangeBird / 4, 1f - TimeAttackRangeBird / 2, 1f);

        float Myradius = 6;
        Vector3 _dirToTarget = Target.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, Target.transform.position);

        var Overlap = Physics2D.OverlapCircle(transform.position, Myradius,Mymask);

        if (Overlap)
        {
            transform.position += _dirToTarget * Time.deltaTime * 0.8f;
            AngleAnim(_dirToTarget);

            if (distance < 5)
            {


                PrepairRange();

             
            }

        }
        else
        {
            TimeAttackRangeBird = Mathf.Clamp(TimeAttackRangeBird - Time.deltaTime * 1.2f, 0f, 2f);
        }

    }

    public void Raycast(Vector3 _dir , float _distance)
    {
      

        ray = Physics2D.RaycastAll(transform.position, _dir, _distance, Mymask);

      
        foreach (var hit in ray)
        {
            if (hit.collider != null)
            {
                if (hit.collider.transform.parent.GetComponent<amel>())
                {
                   
                    //PrepairAttack();

                }
               
                    
            }
          
           
        }


         Debug.DrawRay(transform.position, transform.right * 5 * 1);




    }


    public void PrepairRange()
    {
        TimeAttackRangeBird += Time.deltaTime * 0.8f;

        if (TimeAttackRangeBird > 2)
        {
            TimeAttackRangeBird = 0;

            GameObject snd = Instantiate(Firesnd);
            Destroy(snd, 1f);

            BulletBird prefab = Instantiate(bulletBird);
            prefab.transform.position = transform.position;
            prefab.target = Target;
            prefab.bird = this;
            prefab.Move();
        }

    }


    public void AngleAnim(Vector3 _dirToTarget)
    {
        float Angle = Mathf.Abs(Mathf.Rad2Deg * Mathf.Atan(_dirToTarget.y / _dirToTarget.x));

        if (Angle > 45)
        {
            if (_dirToTarget.y > 0)
            {
                //Debug.Log("Arriba");
                Anim.Play("RunUp");
                sprite.flipX = false;
            }
            else
            {
                //Debug.Log("Abajo");
                Anim.Play("RunDown");
                sprite.flipX = false;
            }
        }
        else
        {
            if (_dirToTarget.x > 0)
            {
                //Debug.Log("Derecha");
                Anim.Play("RunSide");
                sprite.flipX = false;
            }
            else
            {
                //Debug.Log("Izquierda");
                Anim.Play("RunSide");
                sprite.flipX = true;
            }
        }
    }
}
