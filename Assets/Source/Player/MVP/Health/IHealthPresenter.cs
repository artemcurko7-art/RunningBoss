using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthPresenter 
{
    void TakeDamage(int damage);
    void Replenish(int health);
}
