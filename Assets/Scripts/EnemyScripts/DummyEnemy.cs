using UnityEngine;

public class DummyEnemy : MonoBehaviour, IEnemy
{
    //Enemy Health
    public float health { get => GetHealth(); set => SetHealth(100f); }
    //Enemy damage
    public float damageValue => 1f;
    
    private void OnTriggerEnter(Collider other)
    {
        //If the player has the damage hitbox enabled, the enemy this is attatched to takes the damamage and knockback from the player. 
        if (other.CompareTag("PlayerDamageHB"))
        {
            //Get the ITrick script from the currently activated trip.
            ITrick trick = other.GetComponent<ITrick>();
            if (trick != null)
            {
                TakeDamage(trick.TrickPerformed(1));
            }
            else
            {
                Debug.Log("Trick Not Found");
            }
        }
    }

    //Deal damage to the player
    public void DealDamage()
    {
        throw new System.NotImplementedException();
    }

    //Get the enemy health
    public float GetHealth()
    {
        return health;
    }

    //Set the enemy health
    public void SetHealth(float h)
    {
        health = h;
    }

    //Take damage and apply knockback based on the enemies values.
    public void TakeDamage(float dmgTaken)
    {
        health -= dmgTaken;
    }
}
