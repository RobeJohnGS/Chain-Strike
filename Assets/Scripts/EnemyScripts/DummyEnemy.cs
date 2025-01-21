using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DummyEnemy : MonoBehaviour, IEnemy
{
    public float health { get; set; } = 100f;

    public float damageValue => throw new System.NotImplementedException();

    public float damageRange { get; set; } = 5f;

    public Transform playerTransform => GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    public IEnemy.EnemyState currentEnemyState { get; set; } = IEnemy.EnemyState.CHASE;

    public float moveSpeed => 3f;

    private void Update()
    {
        //Look at the player
        gameObject.transform.LookAt(playerTransform.position);
        //If the enemies distance to the player is less than its attack range, it will change its state to attack
        //if the player is farther than the enemies range, it will continue to chase the player
        if(Vector3.Distance(gameObject.transform.position, playerTransform.position) < damageRange)
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
        throw new System.NotImplementedException();
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float h)
    {
        health = h;
    }

    public void TakeDamage(TrickScript trick)
    {
        SetHealth(health - trick.trickData.trickDmg);
        gameObject.GetComponent<Rigidbody>().AddForce((gameObject.transform.forward * -1) * trick.trickData.trickKnockback, ForceMode.Impulse);
        Debug.Log("Took " + trick.trickData.trickDmg + " damage");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, damageRange);
    }
}
