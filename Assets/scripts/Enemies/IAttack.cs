using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void Raycast(Vector3 _dir, float _distance);
    void PrepairAttack();
    void Attack();

}
