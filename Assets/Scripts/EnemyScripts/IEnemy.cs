using UnityEngine;

public interface IEnemy
{
    //Enemy Health
    float health {  get; set; }
    //Enemy damage
    float damageValue { get;}
    //Deal damage to the player
    void DealDamage();
    //Take damage from the player
    void TakeDamage(float dmgTaken);
    //Set the enemy health
    void SetHealth(float h);
    //Get the enemies health
    float GetHealth();
}
