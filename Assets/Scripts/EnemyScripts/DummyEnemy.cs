using UnityEngine;

public class DummyEnemy : MonoBehaviour, IEnemy
{
    public float health { get => GetHealth(); set => SetHealth(100f); }

    public float damageValue => 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerDamageHB"))
        {
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

    public void TakeDamage(float dmgTaken)
    {
        health -= dmgTaken;
    }
}
