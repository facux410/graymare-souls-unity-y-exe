using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBunny : Enemy/*, IUpdate*/
{

    protected override void Start()
    {
        //UpdateManager.Instance.AddElementUpdate(this);
        base.Start();

    }

    private void Awake()
    {


    }

    private void Update()
    {
        MoveRabbit();
    }

    

    public override void MoveRabbit()
    {
        base.MoveRabbit();
    }


}
