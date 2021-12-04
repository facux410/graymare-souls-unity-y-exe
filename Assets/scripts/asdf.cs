using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdf : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public float timerspawn;

    public GameObject[] Enemies;

    public Transform[] pos;

    public float maxTime;

    void Start()
    {
       // maxTime = Random.Range(0, 8);
    }

    // Update is called once per frame
    void Update()
    {
        
        Spawns();
    }

    void Spawns()
    {
        timerspawn += Time.deltaTime;
        if (timerspawn > maxTime)
        {
            var prefab = Instantiate(Enemies[Random.Range(0, Enemies.Length)]);
            prefab.transform.position = pos[Random.Range(0, pos.Length)].position;
            maxTime = Random.Range(7, 20);
            timerspawn = 0;
        }
        //if (timerspawn >= 30)
        //{
        //    timerspawn = 0;
        //    Instantiate(spawn1, transform.position, Quaternion.identity);
        //}
        //else if (timerspawn >= 5 && timerspawn <=5.01f)
        //{
        //    Instantiate(spawn2, transform.position, Quaternion.identity);
        //}
        //else if (timerspawn >= 17 && timerspawn <=17.02f)
        //{
        //    Instantiate(spawn3, transform.position, Quaternion.identity);
        //}
    }
}
