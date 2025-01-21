using UnityEngine;

public interface IEnemy
{
    float health {  get; set; }
    float damageValue { get;}
    void DealDamage();
    void TakeDamage(float dmgTaken);

    void SetHealth(float h);
    float GetHealth();
}
