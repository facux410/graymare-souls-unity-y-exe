using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chanchiten : MonoBehaviour
{
    public float areatack;
    public float visionrange;
    public float speed;
    public Vector2[] points = new Vector2[2];
    Rigidbody2D _rb;
    BoxCollider2D _colli;
    public Vector3 inicialposition;
    LifeAmel lifeamel;
    amel amel;
    

    GameObject player;

    Animator anim;

    float distance;

    public float count;
    bool iswalk = false;
    public bool explosion = false;
    SpriteRenderer _spr;

    public GameObject Boarsnd;
    public bool once;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _colli = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        inicialposition = transform.position;
        anim = GetComponent<Animator>();
        amel = GetComponent<amel>();
        _spr = GetComponent<SpriteRenderer>();
        lifeamel = GetComponent<LifeAmel>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        anim.SetBool("iswalk", iswalk);
        explosiones();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, areatack);
        Gizmos.DrawWireSphere(transform.position, visionrange);
    }

    private void Follow()
    {
        
        Vector3 dir = (player.transform.position - transform.position).normalized;
        

        if (Vector3.Distance(transform.position, player.transform.position) < visionrange)
        {

            transform.position += speed * dir * Time.deltaTime;
            iswalk = true;
            anim.SetBool("iswalk", iswalk);
            count += Time.deltaTime;

            if (once == false)
                sonido();
                       
        }
        if (Vector3.Distance(transform.position, player.transform.position) > visionrange)
        {
            iswalk = false;
            anim.SetBool("iswalk", iswalk);


        }

        if (dir.x < 0)
        {
            _spr.flipX = false;
        }
        else
        {
            _spr.flipX = true;
        }

    }

    public void sonido()
    {
        once = true;

        GameObject snd = Instantiate(Boarsnd);
        Destroy(snd, 4f);
    }

    void explosiones()
    {
        if (explosion == true)
        {
            anim.SetBool("explosion", explosion);
            //count = 3.01f;

            _colli.enabled = false;
        }
        if (count >= 3.35f)
        {
                Destroy(gameObject);
                count = 0;
                return;

        }

        if (count >= 3f)
        {
            anim.SetBool("explosion", explosion);
            explosion = true;
            if (count >= 3.35f)
            {
                Destroy(gameObject);
                count = 0;
                return;

            }
        }
    }
}
