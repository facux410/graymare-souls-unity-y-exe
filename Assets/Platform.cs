using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public Lever[] mylever = new Lever[4];

    public bool isMoving;

    Rigidbody2D rb;

    public float dir;

    public GameObject inv;

    public GameObject feeler;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feeler.SetActive(false);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (mylever[0].Activate[0] == true)
        {
            if(isMoving == false)
            {
                transform.position += new Vector3(1, 0) * Time.deltaTime * 2;
                feeler.SetActive(true);
                Collision19Exit();
                feeler.transform.eulerAngles = new Vector3(0, 0, 270f); 
                isMoving = true;
            }

            transform.position += new Vector3(1, 0) * -dir * Time.deltaTime * 2;
            Debug.Log("0");

        }
      
        if (mylever[1].Activate[1] == true)
        {
            if (isMoving == false)
            {
                transform.position += new Vector3(1, 0) * -dir * Time.deltaTime * 2;
                feeler.SetActive(true);
                Collision19Exit();
                feeler.transform.eulerAngles = new Vector3(0, 0, 90f);
                isMoving = true;
            }

            transform.position += new Vector3(1, 0) * Time.deltaTime * 2;
            Debug.Log("1");

        }

        if (mylever[2].Activate[2] == true)
        {
            if (isMoving == false)
            {
                transform.position += new Vector3(0, 1) * -dir * Time.deltaTime * 2;
                feeler.SetActive(true);
                Collision19Exit();
                feeler.transform.eulerAngles = new Vector3(0, 0, 180f);
                isMoving = true;
            }

            transform.position += new Vector3(0, 1) * Time.deltaTime * 2; ;
            Debug.Log("2");

        }

        if (mylever[3].Activate[3] == true)
        {
            if (isMoving == false)
            {
                transform.position += new Vector3(0, 1) * Time.deltaTime * 2;
                feeler.SetActive(true);
                Collision19Exit();
                feeler.transform.eulerAngles = new Vector3(0, 0, 0);
                isMoving = true;
            }

            transform.position += new Vector3(0, 1) * -dir * Time.deltaTime * 2;
            Debug.Log("3");

        }

    }

    public void CollisionDetected()
    {
        for (int i = 0; i < mylever.Length; i++)
        {
            mylever[i].Activate[i] = false;
        }

        feeler.transform.position = transform.position;
        feeler.SetActive(false);
        isMoving = false;
    }

    public void Collision19()
    {
        inv.SetActive(false);
    }

    public void Collision19Exit()
    {
        inv.SetActive(true);
    }
}
