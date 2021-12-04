using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Destroy());
    }


    IEnumerator Destroy()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
      
    }
}
