using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DummyEnemy : MonoBehaviour, IEnemy
{
    public float health { get; set; } = 100f;

    public float damageValue => throw new System.NotImplementedException();

    public float damageRange { get; set; } = 3f;
    public GameObject playerObject => GameObject.FindGameObjectWithTag("Player");

    public IEnemy.EnemyState currentEnemyState { get; set; } = IEnemy.EnemyState.CHASE;

    public float moveSpeed => 3f;

    public float attackCD { get; set; } = 100000f;

    private void Update()
    {
        //Look at the player
        gameObject.transform.LookAt(playerObject.transform.position);
        //If the enemies distance to the player is less than its attack range, it will change its state to attack
        //if the player is farther than the enemies range, it will continue to chase the player
        if(Vector3.Distance(gameObject.transform.position, playerObject.transform.position) < damageRange)
        {
            currentEnemyState = IEnemy.EnemyState.ATTACK;
        }
        else
        {
            currentEnemyState = IEnemy.EnemyState.CHASE;
        }

        switch (currentEnemyState)
        {
            case IEnemy.EnemyState.ATTACK:
                DealDamage();
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
            playerObject.GetComponent<PlayerManager>().comboDmg = 0;
        }
    }

    public void DealDamage()
    {
        Debug.Log("KILLL");
    }

    public float GetHealth()
    {
        return health;
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
    public void OnDeath()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, damageRange);
    }

    
}
