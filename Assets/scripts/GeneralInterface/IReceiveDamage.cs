using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReceiveDamage
{
    void TakeDamage(int Damage);
    void Die();
    void FeedbackDamage();

}
