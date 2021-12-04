using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timesound : MonoBehaviour
{
    public float timetolifesound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timetolifesound);
    }
}
