using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public DirectionLevel DirectionEnum;
    
    public Platform platform;

    public bool[] Activate = new bool[4];

    Animator anim;
   

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
      
    }

    public void Direction()
    {
        if(platform.isMoving == false)
        {
            switch (DirectionEnum)
            {
                case DirectionLevel.Left:
                    Activate[0] = true;
                    anim.SetBool("Activate", true);
                    break;
                case DirectionLevel.Right:
                    Activate[1] = true;
                    anim.SetBool("Activate", true);
                    break;
                case DirectionLevel.Top:
                    Activate[2] = true;
                    anim.SetBool("Activate", true);
                    break;
                case DirectionLevel.Down:
                    Activate[3] = true;
                    anim.SetBool("Activate", true);
                    break;

            }
        }
    }

   
}

public enum DirectionLevel
{
   Left,
   Right,
   Top,
   Down
}