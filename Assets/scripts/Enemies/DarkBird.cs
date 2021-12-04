using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBird : Enemy/*, IUpdate*/
{

    protected override void Start()
    {
       // UpdateManager.Instance.AddElementUpdate(this);
        base.Start();

    }

    private void Awake()
    {
       
      
    }

    private void Update()
    {
        Move();
    }

   


    public override void Move()
    {
        base.Move();
    }

    
}
