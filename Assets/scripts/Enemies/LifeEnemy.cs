using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemy : MonoBehaviour, IUpdate, IReceiveDamage
{

    public int Life = 100;

    SpriteRenderer sr;

    float currentTime;
    float maxtime = 2;
    float velFeedback = 6;

    public GameObject birdDead;
    public GameObject rabbitDead;
    public End end;

    bool isAttacked;
    public bool Boss_die;

    void Start()
    {
        UpdateManager.Instance.AddElementUpdate(this);
    }

    private void Awake()
    {

        sr = GetComponent<SpriteRenderer>();
    }


    public void OnUpdate()
    {
        if (isAttacked)
            FeedbackDamage();
        Die();
    }

    public void Die()
    {
        if (Life <= 0)
        {
            if(this.gameObject.HasComponent<Boss>())
            {
                Boss_die = true;

            }

            if(this.gameObject.HasComponent<DarkBird>())
            {
                GameObject snd = Instantiate(birdDead);
                Destroy(snd, 1f);
            }

            if (this.gameObject.HasComponent<EvilBunny>())
            {
                GameObject snd = Instantiate(rabbitDead);
                Destroy(snd, 1f);
            }

            if(Boss_die == false)
            {
                UpdateManager.Instance.RemoveElementUpdate(this);
                Destroy(gameObject);
            }
            else
            {
                end.Finale = true;
                UpdateManager.Instance.RemoveElementUpdate(this);
                Destroy(gameObject);
                
            }
        }
    }

    public void FeedbackDamage()
    {
        if (currentTime > maxtime)
        {
            sr.color = Color.white;
            currentTime = 0;
            isAttacked = false;
        }
        else
        {
            currentTime += Time.deltaTime * velFeedback;
            if ((int)currentTime % 2 != 0)
                sr.color = Color.red;
            else
            {
                sr.color = Color.white;
            }
        }
    }

    public void TakeDamage(int Damage)
    {
        isAttacked = true;
        Life -= Damage;
    }

}
