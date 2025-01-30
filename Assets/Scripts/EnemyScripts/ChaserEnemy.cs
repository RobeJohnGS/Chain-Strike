using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class ChaserEnemy : MonoBehaviour, IEnemy
{
    public float health { get; set; } = 25f;

    public float moveSpeed => 3f;

    public float damageValue => 5f;

    public float damageRange { get; set; } = 2f;
    public IEnemy.EnemyState currentEnemyState { get; set; } = IEnemy.EnemyState.CHASE;

    public GameObject playerObject => GameObject.FindGameObjectWithTag("Player");

    public float attackCD { get; set; } = 1.5f;

    private void Update()
    {
        //Look at the player
        gameObject.transform.LookAt(playerObject.transform.position);
        //If the enemies distance to the player is less than its attack range, it will change its state to attack
        //if the player is farther than the enemies range, it will continue to chase the player
        if (Vector3.Distance(gameObject.transform.position, playerObject.transform.position) < damageRange)
        {
            currentEnemyState = IEnemy.EnemyState.ATTACK;
        }
        else
        {
            currentEnemyState = IEnemy.EnemyState.CHASE;
        }
        
        //Attack cooldown
        attackCD -= Time.deltaTime;

        switch (currentEnemyState)
        {
            case IEnemy.EnemyState.ATTACK:
                if (attackCD <= 0)
                {
                    DealDamage();
                }
                break;

            case IEnemy.EnemyState.CHASE:
                gameObject.transform.position += gameObject.transform.forward * moveSpeed * Time.deltaTime;
                break;
        }

        if (health <= 0)
        {
            OnDeath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerDamageHB"))
        {
            TakeDamage(other.gameObject.GetComponent<TrickScript>(), playerObject.GetComponent<PlayerManager>().comboDmg);
            playerObject.GetComponent<PlayerManager>().ResetComboScore(0f);
        }
    }

    public void DealDamage()
    {
        playerObject.GetComponent<PlayerManager>().OnTakeDamage(damageValue);
        Debug.Log("Dealt: " + damageValue + " damage");
        attackCD = 1.5f;
    }

    public float GetHealth()
    {
        return health;
    }

    public void OnDeath()
    {
        Debug.Log(gameObject.name + " died");
        Destroy(gameObject);
    }

    public void SetHealth(float h)
    {
        health = h;
    }

    public void TakeDamage(TrickScript trick, float comboDmg)
    {
        SetHealth(health - (trick.trickData.trickDmg + comboDmg));
        Vector3 knockbackDir = gameObject.transform.position - playerObject.transform.position;
        gameObject.GetComponent<Rigidbody>().AddForce(knockbackDir.normalized * trick.trickData.trickKnockback, ForceMode.Impulse);
        Debug.Log("Took " + (trick.trickData.trickDmg + comboDmg) + " damage");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, damageRange);
    }
}
