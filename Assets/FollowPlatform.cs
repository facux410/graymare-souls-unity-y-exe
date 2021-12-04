using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlatform : MonoBehaviour
{
    Platform plat;

    void Start()
    {
        
    }

    private void Awake()
    {
        plat = FindObjectOfType<Platform>();
    }

    void Update()
    {
        transform.position = plat.transform.position;
    }
}
