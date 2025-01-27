using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class ChaserEnemy : MonoBehaviour, IEnemy
{
    public float health { get; set; } = 25f;

    public float moveSpeed => 3f;

    public float damageValue => 5f;

    public float damageRange { get; set; } = 2f;
    public IEnemy.EnemyState currentEnemyState { get; set; } = IEnemy.EnemyState.CHASE;

    public Transform playerTransform => GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    private void Update()
    {
        //Look at the player
        gameObject.transform.LookAt(playerTransform.position);
        //If the enemies distance to the player is less than its attack range, it will change its state to attack
        //if the player is farther than the enemies range, it will continue to chase the player
        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) < damageRange)
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
            TakeDamage(other.gameObject.GetComponent<TrickScript>());
        }
    }

    public void DealDamage()
    {
        Debug.Log("Dealt: " + damageValue + " damage");
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

    public void TakeDamage(TrickScript trick)
    {
        SetHealth(health - trick.trickData.trickDmg);
        Vector3 knockbackDir = gameObject.transform.position - playerTransform.position;
        gameObject.GetComponent<Rigidbody>().AddForce(knockbackDir.normalized * (-trick.trickData.trickKnockback * 25), ForceMode.Impulse);
        Debug.Log("Took " + trick.trickData.trickDmg + " damage");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, damageRange);
    }
}
