using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class amel : MonoBehaviour, IUpdate, IAttack
{
    Rigidbody2D _rb;
    Animator _anim;
    SpriteRenderer _spr;
    public float _speed;
    bool up;
    bool _isDead;
    public bool iswalk;
    public int Change;
    bool Return;
    public float count;
    bool Atack = false;
    public Sprite[] images = new Sprite[4];

    int ComboNumber = 1;
    public bool CanAttack = true;

    public float rangedash;
    public LayerMask Mymask;
    RaycastHit2D[] ray;
    bool shoot = false;
    public float timeshoot;


    public Vector2 Direction;
    float Distance = 1;

    int Damage = 20;

    public float Sdir;
    public float Sdirup;

    private Vector3 lastmove;
    public Vector2 poschild;
    private Vector2 startScale;
    Vector3 scaleNew;
    Vector3 startRotation;

    public GameObject PtclAttack;
    public GameObject BasicSlash;
    public GameObject DashAttack;
    public GameObject PushAttack;
    public ParticleSystem particleDash;

    public Transform spawnArrow;

    public float staminedash;
    public Image dashbar;
    bool DasH;
    bool _isDashing;

    public Transform bezierdChild;

    ManagerScenes managerscenes;

    bool respawn;
    float ScaleX = 0.07f;
    float ScaleY = 0.07f;

    public GameObject attack1snd;
    public GameObject attack2snd;

    public List<Key> keys = new List<Key>();

    public List<Transform> fallRespawn = new List<Transform>();

    public Arrow Arrow;
    public float countatack;

    private void Awake()
    {
        
        startScale = transform.localScale;
        startRotation = transform.rotation.eulerAngles;

        Invoke("UpdateNOW", 0.3f);
    }

    public void UpdateNOW()
    {
        UpdateManager.Instance.AddElementUpdate(this);
    }

    public void Dead()
    {
        _isDead = true;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
        managerscenes = FindObjectOfType<ManagerScenes>();

        poschild = bezierdChild.localPosition;

        dashbar = GameObject.Find("Graymore Lifebar_Green").GetComponent<Image>();
        rangedash = 900;
    }



    public void OnUpdate()
    {
      
        //para que la pausa funcione este es el nuevo update
        if (_isDead == false)
        {
            if(_isDashing == false)
            {
                Move();
                change();
                dash();
                atackarco();
            }

            

            _anim.SetBool("return", up);
            atack();
            _anim.SetBool("atack", Atack);
            dashbar.fillAmount = staminedash / 100;
            _anim.SetBool("shoot", shoot);
            Respawn();
            //  dashbar.fillAmount = staminedash / 100;
            _anim.SetBool("dash", DasH);

           
        }
    }


    

    private void Move()
    {
        var dir = Input.GetAxisRaw("Horizontal");
        var dirup = Input.GetAxisRaw("Vertical");

        Direction = new Vector2(Sdir, Sdirup);
        Return = false;
        _rb.velocity = new Vector2(dir * _speed, dirup * _speed);
        // _rb.velocity = new Vector2(dir * _speed, _rb.velocity.y);
        iswalk = true;
        _anim.SetFloat("move H", Mathf.Abs(dir));
        _anim.SetBool("iswalk", iswalk);
        _anim.SetFloat("move Up", dirup);
        _anim.SetFloat("move Dw", Mathf.Abs(dirup));


        if (dir < 0)
        {
            Sdir = -1;
            Sdirup = 0;
            _spr.flipX = true;
            iswalk = true;
            bezierdChild.localPosition = new Vector2(-poschild.x, 0);

        }
        else if (dir > 0)
        {
            Sdir = 1;
            Sdirup = 0;
            _spr.flipX = false;
            iswalk = true;
            bezierdChild.localPosition = new Vector2(poschild.x, 0);

        }
        else if (dir == 0f)
        {
            iswalk = false;
            if (iswalk == false)
            {
                Return = true;
                _anim.SetBool("return", Return);

            }


        }

        if (dirup < 0)
        {
            Sdirup = -1;
            Sdir = 0;
            _anim.SetFloat("move Dw", Mathf.Abs(dirup));
            bezierdChild.localPosition = new Vector2(0, -poschild.x);


        }
        else if (dirup > 0)
        {
            Sdirup = 1;
            Sdir = 0;
            _anim.SetFloat("move Up", dirup);
            bezierdChild.localPosition = new Vector2(0, poschild.x);

        }
        else
            iswalk = false;






    }
    private void change()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            Change++;
            _anim.SetInteger("change", Change);

            Sdirup = -1;
            Sdir = 0;
        }

        if (Change == 2)
            Change = 0;

        return;



    }
    private void atack()
    {



        if (Input.GetKeyDown(KeyCode.Space) && Change == 1 && CanAttack == true)
        {
            switch (ComboNumber)
            {
                case 1:
                    Damage = 15;

                    Raycast(Direction, Distance);
                    Atack = true;

                    GameObject snd11 = Instantiate(attack1snd);
                    Destroy(snd11, 1f);

                    CanAttack = false;
                    ComboNumber = 2;
                    Invoke("ResetAttack", 0.15f);
                    Invoke("ResetCombo", 0.6f);
                    break;

                case 2:
                    Damage = 15;

                    Raycast(Direction, Distance);
                    Atack = true;

                    GameObject snd12 = Instantiate(attack1snd);
                    Destroy(snd12, 1f);

                    CancelInvoke("ResetCombo");
                    CanAttack = false;
                    ComboNumber = 3;
                    Invoke("ResetAttack", 0.15f);
                    Invoke("ResetCombo", 0.6f);
                    break;
                case 3:                         //Combo Basico
                    Damage = 30;

                    Raycast(Direction, Distance);
                    Atack = true;

                    GameObject fxB = Instantiate(BasicSlash);
                    fxB.transform.position = transform.position;
                    fxB.transform.right = fxB.transform.position - (transform.position - new Vector3(Sdir, Sdirup, 0));

                    GameObject snd21 = Instantiate(attack2snd);
                    Destroy(snd21, 1f);

                    CancelInvoke("ResetCombo");
                    CanAttack = false;
                    Invoke("ResetAttack", 0.7f);
                    Invoke("ResetCombo", 0.1f);
                    break;
                case 4:                         //Combo Dash
                    Damage = 40;

                    Raycast(Direction, Distance);
                    Atack = true;

                    GameObject fxD = Instantiate(DashAttack);
                    fxD.transform.position = transform.position;
                    fxD.transform.right = fxD.transform.position - (transform.position - new Vector3(Sdir, Sdirup, 0));

                    GameObject snd22 = Instantiate(attack2snd);
                    Destroy(snd22, 1f);

                    CancelInvoke("ResetCombo");
                    Invoke("ResetCombo", 0f);
                    break;
                case 5:                         //Combo Arco
                    Damage = 15;

                    Raycast(Direction, Distance);
                    Atack = true;

                    GameObject fxS = Instantiate(PushAttack);
                    fxS.transform.position = transform.position;
                    fxS.transform.right = fxS.transform.position - (transform.position - new Vector3(Sdir, Sdirup, 0));

                    GameObject snd23 = Instantiate(attack2snd);
                    Destroy(snd23, 1f);

                    _rb.AddForce((Direction * rangedash) * -1 * Time.fixedDeltaTime, ForceMode2D.Impulse);
                    _isDashing = true;

                    CancelInvoke("ResetCombo");
                    Invoke("ResetCombo", 0f);
                    Invoke("dashmovement", 0.1f);
                    break;

            }
           
        }
        
        else
            Atack = false;

    }

    void ResetAttack()
    {
        CanAttack = true;
    }

    void ResetCombo()
    {
        ComboNumber = 1;
    }


    public void Raycast(Vector3 _dir, float _distance)
    {
        ray = Physics2D.RaycastAll(transform.position, _dir, _distance, Mymask);
        Debug.DrawRay(transform.position, Direction, Color.magenta);


        foreach (var hit in ray)
        {

            if (hit.collider.GetComponent<LifeEnemy>())
            {

                LifeEnemy enemyhealth = hit.collider.GetComponent<LifeEnemy>();
                enemyhealth.TakeDamage(Damage);

                GameObject Ptcls = Instantiate(PtclAttack);
                Ptcls.transform.position = hit.collider.transform.position;

               
            }
            else if (hit.collider.GetComponent<Lever>())
            {
                Lever newlever = hit.collider.GetComponent<Lever>();
                newlever.Direction();
            }
            


        }



    }

    public void PrepairAttack()
    {

    }

    public void Attack()
    {
        

    }

    public void atackarco()
    {
        

        if (Input.GetKeyDown(KeyCode.X) && Change == 1 && shoot ==false && staminedash >= 15f)
        {
            shoot = true;
        }
        else if (Input.GetKeyDown(KeyCode.X) && Change == 1 && shoot == false && staminedash < 15f)
        {
            Invoke("DashbarBlink", 0.01f);
            Invoke("DashbarBlinkUndo", 0.7f);
            Invoke("DashbarBlink", 1.2f);
            Invoke("DashbarBlinkUndo", 2f);
        }

        if (shoot == true )
        {
            timeshoot+= 1f * Time.deltaTime;
            if (timeshoot >=0.2f)
            {
                shoot = false;
                timeshoot = 0;

                staminedash -= 15f;

                var prefabArrow = Instantiate(Arrow);
                prefabArrow.transform.position = spawnArrow.position;
               // prefabArrow.transform.rotation = transform.rotation;
                prefabArrow.Move(Sdir,Sdirup);

                ComboNumber = 5;                        
                Invoke("ResetCombo", 0.7f);             
            }

        }
    }

    
    public void dash()

    {
        lastmove = Direction;
        DasH = false;

        if(Change == 1 && Input.GetKeyDown(KeyCode.Z) && staminedash >= 20f)
        {
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                _rb.AddForce(lastmove * rangedash * Time.fixedDeltaTime, ForceMode2D.Impulse);
                //var prefabparticle = Instantiate(particleDash);
                //prefabparticle.transform.position = transform.position;
                staminedash -= 20f;
                DasH = true;
                _isDashing = true;

                ComboNumber = 4;                        //esto permite
                Invoke("ResetCombo", 0.7f);             //el combo del dash
                Invoke("dashmovement", 0.1f);
                //holi
            }
        }
        else if(Change == 1 && Input.GetKeyDown(KeyCode.Z) && staminedash <20f)
        {
            Invoke("DashbarBlink", 0.01f);
            Invoke("DashbarBlinkUndo", 0.7f);
            Invoke("DashbarBlink", 1.2f);
            Invoke("DashbarBlinkUndo", 2f);
        }
        

        if (staminedash <= 100)
        {
            staminedash += 2.8f * Time.deltaTime;
        }
        return;
    }

    void dashmovement()
    {
        if (_isDashing == true)
        {
            _isDashing = false;

            if (Sdir == 1)
            {
                _anim.Play("warrior iddle lf");
                _spr.flipX = false;
            }    
            else if (Sdir == -1)
            {
                _anim.Play("warrior iddle lf");
                _spr.flipX = true;
            }
            if (Sdirup == 1)
                _anim.Play("idle up warr");
            else if (Sdirup == -1)
                _anim.Play("warrior idle");
        }
            
        else
            _isDashing = true;
    }

    void DashbarBlink()
    {
        dashbar.color = new Color(1f, 0.5f, 0, 1f); 
    }

    void DashbarBlinkUndo()
    {
        dashbar.color = new Color(1f, 1f, 1f, 1f);
    }

    void Respawn()
    {
        if (respawn)
        {
         
            scaleNew.x = Mathf.Clamp(scaleNew.x, 0, startScale.x);
            scaleNew.y = Mathf.Clamp(scaleNew.y, 0, startScale.y);

            scaleNew -= new Vector3(ScaleX, ScaleY);
            transform.localScale = scaleNew;
            _rb.velocity = new Vector3(_rb.velocity.x * 0, _rb.velocity.y * 0);

            Vector3 myRotation = transform.rotation.eulerAngles;
            myRotation += new Vector3(0, 0, 15);
            transform.rotation = Quaternion.Euler(myRotation);

            if (scaleNew.x <= 0)
            {
                transform.position = fallRespawn[0].position;
                transform.localScale = startScale;
                transform.rotation =Quaternion.Euler(startRotation);
                respawn = false;
            }
        }
        else
            scaleNew = startScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 17)
        {
           
            respawn = true;
        }
        if (collision.gameObject.layer == 18)
        {
            fallRespawn.RemoveAt(0);
            fallRespawn.Add(collision.transform);
        }
        
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 15)
            managerscenes.NextScene();

        if (collision.gameObject.GetComponent<CloseDoor>())
        {
            if (collision.gameObject.GetComponent<CloseDoor>().openThisDoor == true)
                managerscenes.NextScene();
        }
        if (collision.gameObject.GetComponent<Key>())
            keys.Add(collision.gameObject.GetComponent<Key>());
    }


}

