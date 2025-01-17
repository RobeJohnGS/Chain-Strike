using UnityEngine;

public interface IEnemy
{
    float damageValue { get;}
    void DealDamage();
    void TakeDamage(float dmgTaken);
}
