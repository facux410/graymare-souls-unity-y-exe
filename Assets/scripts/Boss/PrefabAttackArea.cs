using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabAttackArea : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DestroyThis());
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<amel>())
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyThis()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.4f);
            Destroy(gameObject);
        }
    }
}
