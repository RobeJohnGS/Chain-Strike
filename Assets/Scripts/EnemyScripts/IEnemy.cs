using UnityEngine;

public interface IEnemy
{
    //Enemy Health
    float health {  get; set; }
    //Enemy Move Speed
    float moveSpeed { get; }
    //Enemy damage
    float damageValue { get;}
    //Attack Cooldown
    float attackCD { get; set; }
    //Damage Range
    float damageRange { get; set; }
    //AI states enum
    enum EnemyState { CHASE, ATTACK }
    //Current AI state
    EnemyState currentEnemyState { get; set; }
    //Transform of the player to follow
    Transform playerTransform { get; }
    //Deal damage to the player
    void DealDamage();
    //Take damage from the player
    void TakeDamage(TrickScript trick);

    //Enemy Died
    void OnDeath();
    //Set the enemy health
    void SetHealth(float h);
    //Get the enemies health
    float GetHealth();
}
