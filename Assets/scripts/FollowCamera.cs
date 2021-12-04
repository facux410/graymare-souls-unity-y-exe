using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    amel Target;

    public float speed;
 
    void Start()
    {
        
    }

    private void Awake()
    {
        Target = FindObjectOfType<amel>();
    }


    void Update()
    {
        Follow();   
    }

    void Follow()
    {
        Vector3 _dir = Target.transform.position - transform.position;
        _dir.z = 0;
        transform.position += _dir * Time.deltaTime * speed;
    }
}
