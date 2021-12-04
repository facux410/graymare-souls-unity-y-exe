using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeAmel : MonoBehaviour,IReceiveDamage
{
    amel Player;

    public float _life;
    public int Damage;
    int _maxLife = 100;

    float currentTime;
    public float maxtime;
    public float velFeedback;

    bool isAttacked;
    bool CanPassToDeath;

    public GameObject hurtsnd;

    SpriteRenderer sp;

    public Image HP;
    public GameObject StateW;
    public GameObject StateM;

    public chanchiten kami;

    void Start()
    {
        _life = _maxLife;
    }

    private void Awake()
    {
        
        sp = GetComponent<SpriteRenderer>();
        Player = GetComponent<amel>();
        kami = GetComponent<chanchiten>();

        CanPassToDeath = true;

        HP = GameObject.Find("Graymore Lifebar_Red").GetComponent<Image>();
        StateW = GameObject.Find("Graymore Lifebar_Warrior");
        StateM = GameObject.Find("Graymore Lifebar_Mage");
    }

    private void Update()
    {
        if (isAttacked)
            FeedbackDamage();

        HP.fillAmount = ((float)_life) / _maxLife;

        if (_life <= 0 && CanPassToDeath == true)
        {
            CanPassToDeath = false;
            Die();
        }

        if (Player.Change == 1)
        {
            StateW.SetActive(true);
            StateM.SetActive(false);
        }
        else
        {
            StateM.SetActive(true);
            StateW.SetActive(false);
        }
    }

  
    public void Die()
    {
        Player.Dead();

        Invoke("Reload", 0.5f);
    }

    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }


    public void TakeDamage(int damage)
    {
        _life -= damage;
    }

    public void FeedbackDamage()
    {
        if (currentTime > maxtime)
        {
            sp.color = Color.white;
            currentTime = 0;
            isAttacked = false;
        }
        else
        {
            currentTime += Time.deltaTime * velFeedback;
            if ((int)currentTime % 2 != 0)
                sp.color = Color.red;
            else
            {
                sp.color = Color.white;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletBird>())
        {
            Damage = 20;
            DamageProcess();
        }

        if (collision.gameObject.GetComponent<Scratch>())
        {
            Damage = 8;
            DamageProcess();
        }

        if (collision.gameObject.GetComponent<BulletStaticEnemy>())
        {
            Damage = 10;
            DamageProcess();
        }

        if (collision.gameObject.GetComponent<PrefabAttackArea>())
        {
            Damage = 15;
            DamageProcess();
        }

        
        if (collision.gameObject.GetComponent<chanchiten>())
        {
            Damage = 40;
            DamageProcess();
            kami = collision.gameObject.GetComponent<chanchiten>();
            kami.explosion = true;
            
        }

    }

    public void DamageProcess()
    {
        isAttacked = true;

        GameObject snd = Instantiate(hurtsnd);
        Destroy(snd, 1f); 

        TakeDamage(Damage);
        HP.fillAmount = _life / 100;
    }
}
